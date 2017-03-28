using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Hotkeys;

namespace mouse_scripter
{
    class Script
    {
        public struct Data_Pack
        {
            public int x;
            public int y;
            public int new_x;
            public int new_y;
            public int delay;
        }
        private string[] lines;
        private int[] actions; // 0 = LPM, 1 = goto, 2 = delay, 3 = goto
        private Data_Pack[] data;
        private Cursor cursor; // odnosnik do kursora
        //private Hotkeys.GlobalHotkey stop_key; // uchwyt do hotkeya zatrzymujacego skrypt
        //private int break_time; // czas przerwy między kolejnymi krokami pętli
        private int counter; // licznik
        private bool is_running; // czy skrypt chodzi ?
        private bool is_stopped_by_key; // czy skrypt zatrzymany przez klawisz ?
        //private MyMouse mouse;
        
        public Script()
        {
            this.lines = null;
            this.actions = null;
            this.data = null;
            this.cursor = null;
            this.counter = 0;
            this.is_running = false;
            this.is_stopped_by_key = false;
            //this.mouse = null;
        }

        public Script(string[] lines, Cursor cursor)
        {
            this.lines = lines;
            this.cursor = cursor;
            this.actions = null;
            this.data = null;
            this.cursor = null;
            this.counter = 0;
            this.is_running = false;
            this.is_stopped_by_key = false;
            //this.stop_key = stop_key;
            //this.mouse = new MyMouse(cursor);
        }

        public string toString()
        {
            string output = "Data.delay = ";
            for (int i = 0; i < actions.Length; i++) output += this.data[i].delay+"|";
            return output;
        }

        public void setRunningState(bool state)
        {
            this.is_running = state;
        }

        public void setLines(string[] lines)
        {
            this.lines = lines;
        }

        public void setActions(int[] actions)
        {
            this.actions = actions;
        }
        
        public void setData(int index, int x=0, int y=0, int delay=1, int new_x=0, int new_y=0)
        {
            Data_Pack datapack = new Data_Pack();
            datapack.x = x;
            datapack.y = y;
            datapack.delay = delay;
            datapack.new_x = new_x;
            datapack.new_y = new_y;
            data[index] = datapack;
        }

        public bool code_script(TextBox logs) // zakoduj skrypt w pamięci, zakładam że skrypt jest poprawny składniowo
        {
            if (!verify_script(logs)) return false;
            int tab_size = lines.Length;
            if (this.data == null || data.Count() != tab_size) data = new Data_Pack[tab_size];
            if (this.actions == null || actions.Count() != tab_size) actions = new int[tab_size];
            for (int i=0; i<lines.Length; i++)
            {
                if (lines[i].Contains("left_click"))
                {
                    Data_Pack datapack = new Data_Pack();
                    datapack.x = 0;
                    datapack.y = 0;
                    datapack.delay = 0;
                    data[i] = datapack;
                    actions[i] = 0;
                }
                else if (lines[i].Contains("goto"))
                {
                    string line = lines[i];
                    string x = "", y = "";
                    bool read_x = false, read_y = false;
                    for (int j = 0; j < line.Length; j++)
                    {
                        if (line[j] == '(')
                        {
                            read_x = true;
                            continue;
                        }
                        else if (line[j] == ',')
                        {
                            read_x = false;
                            read_y = true;
                            continue;
                        }
                        else if (line[j] == ')') break;

                        if (read_x) x += line[j];
                        else if (read_y) y += line[j];

                        Data_Pack datapack = new Data_Pack();
                        //data[i] = new Data_Pack();
                        int.TryParse(x, out datapack.x);
                        int.TryParse(y, out datapack.y);
                        datapack.delay = 0;
                        data[i] = datapack;
                    }
                    actions[i] = 1;
                }
                else if (lines[i].Contains("delay")) // delay(12)
                {
                    string time = "";
                    string line = lines[i];
                    StringBuilder str_builder = new StringBuilder();
                    for (int j = 0; j < line.Length; j++) if (Char.IsNumber(line[j])) str_builder.Append(line[j]);

                    time = str_builder.ToString();
                    actions[i] = 2;
                    Data_Pack datapack = new Data_Pack();
                    try
                    {
                        datapack.delay = int.Parse(time);
                    }
                    catch(ArgumentNullException exp)
                    {
                        MessageBox.Show(exp.Message);
                        return false;
                    }
                    catch(FormatException exp)
                    {
                        MessageBox.Show(exp.Message);
                        return false;
                    }
                    catch(OverflowException exp)
                    {
                        MessageBox.Show(exp.Message);
                        return false;
                    }
                    datapack.delay *= 1000;
                    datapack.x = 0;
                    datapack.y = 0;
                    data[i] = datapack;
                }
                else if (lines[i].Contains("dragndrop"))
                {
                    string line = lines[i];
                    string x = "", y = "", new_x = "", new_y = "";
                    bool is_x = false, is_y = false, is_new_x = false, is_new_y = false;
                    for (int j=0; j<line.Length; j++)
                    {
                        if (line[j] == '(')
                        {
                            is_x = true;
                            continue;
                        }
                        if (is_x)
                        {
                            if (line[j] == ',')
                            {
                                is_x = false;
                                is_y = true;
                                continue;
                            }
                            x += line[j];
                        }
                        else if (is_y)
                        {
                            if (line[j] == ',')
                            {
                                is_y = false;
                                is_new_x = true;
                                continue;
                            }
                            y += line[j];
                        }
                        else if (is_new_x)
                        {
                            if (line[j] == ',')
                            {
                                is_new_x = false;
                                is_new_y = true;
                                continue;
                            }
                            new_x += line[j];
                        }
                        else if (is_new_y)
                        {
                            if (line[j] == ')')
                            {
                                is_new_y = false;
                                break;
                            }
                            new_y += line[j];
                        }
                    }

                    Data_Pack datapack = new Data_Pack();
                    int.TryParse(x, out datapack.x);
                    int.TryParse(y, out datapack.y);
                    int.TryParse(new_x, out datapack.new_x);
                    int.TryParse(new_y, out datapack.new_y);
                    datapack.delay = 0;

                    data[i] = datapack;
                    actions[i] = 3;
                }
            }
            return true;
        }

        public bool verify_script(TextBox logs) // zweryfikuj skrypt
        {
            //string[] lines = this.script_box.Lines;
            if (lines == null || lines[0] == "your script here...") return false;

            Match output = null;
            logs.Clear();

            bool result = true;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "left_click")
                {
                    if (i == 0) logs.AppendText("[WARNING] Click command in first line. No pointer position defined.\n");
                    continue;
                }
                output = Regex.Match(lines[i], @"goto\(\d{1,4}\,\d{1,4}\)");
                if (output.Success) continue;
                output = null;

                output = Regex.Match(lines[i], @"delay\(\d+\)");
                if (output.Success) continue;
                output = null;

                output = Regex.Match(lines[i], @"dragndrop\(\d{1,4}\,\d{1,4}\,\d{1,4}\,\d{1,4}\)");
                if (output.Success) continue;
                output = null;

                if (lines[i] == "") continue;

                logs.AppendText("[ERROR] Unrecognised command at line " + i + "\n");
                result = false;
            }

            if (result) logs.AppendText("[INFORMATION] Script is OK\n");
            return result;
        }

        public async void start(TextBox logs, int delay_during_break, int limit=0) // 0 = inf
        {
            if (!verify_script(logs)) return;
            if (lines == null || actions == null || data == null) throw new NullReferenceException("Jedna z tablic jest pusta !");
            if (is_running) throw new Exception("Skrypt już chodzi !");

            this.is_running = true;
            delay_during_break *= 1000;
            this.counter = 0;
            logs.AppendText("[INFORMATION] Script is running... \n");
            //while(is_running ^ counter != limit ^ limit != 0)
            this.is_stopped_by_key = false;
            while (is_running && (counter < limit || limit == 0))
            {
                //Debug.WriteLine("counter = {0}, limit = {1}", counter, limit);
                for (int i=0; i<actions.Count(); i++)
                {
                    switch(actions[i])
                    {
                        case 0:
                            MyMouse.LeftMouseClick();
                            break;
                        case 1:
                            MyMouse.SetCursorPos(data[i].x, data[i].y);
                            break;
                        case 2:
                            //Thread.Sleep(data[i].delay);
                            await Task.Delay(data[i].delay);
                            break;
                        case 3:
                            MyMouse.DragNDrop(data[i].x, data[i].y, data[i].new_x, data[i].new_y);
                            break;
                    }
                }
                if (delay_during_break > 0) await Task.Delay(delay_during_break);
                this.counter++;
            }
            if (this.is_stopped_by_key) logs.AppendText("[INFORMATION] Script is stopped by hotkey \n");
            else logs.AppendText("[INFORMATION] Script is stopped \n");
            this.is_running = false;
            return;
        }

        public bool isRunning()
        {
            return this.is_running;
        }

        public void setKeyStopInformation(bool info)
        {
            this.is_stopped_by_key = info;
        }

        public void clear()
        {
            this.lines = null;
            this.actions = null;
            this.data = null;
        }
    }
}
