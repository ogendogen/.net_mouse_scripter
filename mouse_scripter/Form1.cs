using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using Hotkeys;

namespace mouse_scripter
{
    public partial class Form1 : Form
    {
        private Hotkeys.GlobalHotkey ghk;
        private Hotkeys.GlobalHotkey stop_key;
        private bool key_detection;
        //private Script script;
        private bool tracking;
        //private Cursor cursor;
        private Script skrypt;
        public Form1()
        {
            InitializeComponent();
            Init();
            //MyMouse.SetCursorPos(971, 68);
            //MyMouse.RightMouseClick();
        }

        private void Init()
        {
            key_detection = false;
            tracking = false;
            if (stop_key != null) stop_key.Unregiser();
            stop_key = null;
            skrypt = new Script(this.script_box.Lines, this.Cursor);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            //this.Cursor = new Cursor(Cursor.Current.Handle);
            //ghk = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F10, this);
        }

        private void TrackPosition()
        {
            this.label6.Text = "Pozycja = {" + Cursor.Position.X + "," + Cursor.Position.Y + "}";
            if (this.checkBox1.Checked) System.Windows.Forms.Clipboard.SetText(Cursor.Position.X + "," + Cursor.Position.Y);
        }

        private void HandleStopKey()
        {
            skrypt.setRunningState(false); // zatrzymaj skrypt
            skrypt.setKeyStopInformation(true); // daj informacje że skrypt zatrzymany przez klawisz
        }

	    protected override void WndProc(ref Message m)
	    {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
            {
                int id = m.WParam.ToInt32();
                if (id == 0) TrackPosition();
                else if (id == 1) HandleStopKey();
            }
            //if (m.Msg == Hotkeys.Constants.stopkey_id) 
	        base.WndProc(ref m);
	    }

        /*
         *  this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X + 300, Cursor.Position.Y);
            */

        public bool verify_script()
        {
            string[] lines = this.script_box.Lines;
            if (lines == null || lines.Length == 0 || lines[0].Contains("your script here...")) throw new Exception("Skrypt jest pusty !");

            Match output = null;
            this.logs.Clear();

            bool result = true;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "left_click")
                {
                    if (i == 0) this.logs.AppendText("[WARNING] Click command in first line. No pointer position defined.\n");
                    continue;
                }
                output = Regex.Match(lines[i], @"goto\(\d{1,4}\,\d{1,4}\)");
                if (output.Success) continue;
                output = null;

                output = Regex.Match(lines[i], @"delay\(\d+\)");
                if (output.Success)
                {
                    if (i + 1 == lines.Length) this.logs.AppendText("[WARNING] Delay command in last line. Use break option on screen instead\n");
                    continue;
                }
                output = null;

                output = Regex.Match(lines[i], @"dragndrop\(\d{1,4}\,\d{1,4}\,\d{1,4}\,\d{1,4}\)");
                if (output.Success) continue;
                output = null;

                if (lines[i] == "") continue;

                this.logs.AppendText("[ERROR] Unrecognised command at line " + i + "\n");
                result = false;
            }

            if (this.logs.Text == null) this.logs.AppendText("[INFORMATION] Script is OK");
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (verify_script())
                {
                    MessageBox.Show("Skrypt jest poprawny!", "Powodzenie!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    skrypt.setLines(this.script_box.Lines);
                    logs.AppendText("[INFORMATION] Script is OK\n");
                }
                else MessageBox.Show("Skrypt zawiera błędy !", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.delayButton6.Checked) this.textBox1.Enabled = true;
            else this.textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e) // start skryptu
        {
            if (this.script_box.Text == "")
            {
                MessageBox.Show("Skrypt jest pusty !", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            skrypt.setLines(this.script_box.Lines);
            if (!skrypt.verify_script(this.logs)) 
            {
                MessageBox.Show("W skrypcie są błędy !", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!skrypt.code_script(this.logs))
            {
                MessageBox.Show("Problem z zakodowaniem skryptu !", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.delayButton6.Checked && this.textBox1.Text == "0")
            {
                DialogResult result = MessageBox.Show("Ustawiłeś przerwę na 0 sekund. Czy chodziło ci o opcję 'Bez przerwy' ?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;

                this.delayButton4.Checked = true;
                this.delayButton6.Checked = false;
                this.textBox1.Text = "";
            }

            bool is_delay = false;
            if (this.limitButton3.Checked) // nieskonczonosc razy
            {
                for (int i = 0; i < this.script_box.Lines.Count(); i++)
                {
                    if (this.script_box.Lines[i].Contains("delay"))
                    {
                        is_delay = true;
                        break;
                    }
                }

                if (!is_delay) // inf + brak delaya w skrypcie
                {
                    if (this.delayButton4.Checked) // #1
                    {
                        MessageBox.Show("Przy takiej konfiguracji skrypt musi zawierać przynajmniej jedno polecenie 'delay'. W przeciwnym wypadku nie będziesz w stanie zatrzymać skryptu!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (!this.delayButton4.Checked && !this.limitButton1.Checked) // #2
                    {
                        DialogResult result = MessageBox.Show("Próbujesz wykonywać skrypt w nieskończoność, który nie zawiera opóźnień 'delay'! Akcje mogą wykonywać się za szybko i nie dawać efektu. Czy chcesz kontynuować ?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No) return;
                    }
                }
            }

            if (!is_delay && this.delayButton4.Checked && !this.limitButton1.Checked) // bez przerwy, skrypt bez delay => na wypadek gdyby wpisane było np. 100 razy, wtedy to nie daje efektu
            {
                DialogResult result = MessageBox.Show("Próbujesz wykonywać skrypt w nieskończoność, który nie zawiera opóźnień 'delay'! Akcje mogą wykonywać się za szybko i nie dawać efektu. Czy chcesz kontynuować ?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }

            if (limitButton3.Checked && label5.Text == "brak")
            {
                DialogResult result;
                if (is_delay)
                {
                    result = MessageBox.Show("UWAGA! Uruchamiasz skrypt nieograniczoną ilość razy i nie przypisałeś klawisza stopu! Może wystąpić problem z zatrzymaniem skryptu! Czy chcesz koontynuować ?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Próbujesz uruchomić skrypt, którego nie da się zatrzymać w żaden sposób !\nWykonaj jedna z czynności:\n1. Ustaw ograniczona ilość wykonań\n2. Ustaw klawisz zatrzymujący\n3. Użyj delay w kodzie", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (result == DialogResult.No) return;
            }
            //skrypt.setRunningState(true);

            int limit = 1;
            if (this.limitButton1.Checked) limit = 1;
            else if (this.limitButton2.Checked) limit = Decimal.ToInt32(this.numericUpDown1.Value);//(int)this.numericUpDown1.Value;
            else if (this.limitButton3.Checked) limit = 0; // inf

            int delay_during_break = 0;
            if (this.delayButton4.Checked) delay_during_break = 0;
            else if (this.delayButton5.Checked) delay_during_break = 1;
            else if (this.delayButton6.Checked) int.TryParse(this.textBox1.Text, out delay_during_break);

            this.WindowState = FormWindowState.Minimized;
            try
            {
                skrypt.start(this.logs, delay_during_break, limit);
            }
            catch(NullReferenceException exp)
            {
                MessageBox.Show(exp.ToString(), "Wyjątek !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.ToString(), "Wyjątek !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void script_box_Click(object sender, EventArgs e)
        {
            if (this.script_box.Text == "your script here...") this.script_box.Text = "";
        }

        private void button3_Click(object sender, EventArgs e) // rejestracja klawisza
        {
            this.label5.Text = "<klawisz>";
            key_detection = true;
        }

        private void button4_Click(object sender, EventArgs e) // przełącznik śledzenia
        {
            if (!tracking)
            {
                tracking = true;
                ghk = new GlobalHotkey(Constants.NOMOD, Keys.F4, 0, this);
                ghk.Register();
                MessageBox.Show("Nacisnij F4 aby zapisac pozycje", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.button4.Text = "Wyłącz śledzenie kursora";
            }
            else
            {
                tracking = false;
                ghk.Unregiser();
                ghk = null;
                this.button4.Text = "Włącz śledzenie kursora";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (key_detection)
            {
                if (stop_key != null)
                {
                    stop_key.Unregiser();
                    stop_key = null;
                }
                stop_key = new GlobalHotkey(Constants.NOMOD, e.KeyCode, 1, this);
                stop_key.Register();
                this.label5.Text = Char.ToString((char)e.KeyValue);
                key_detection = false;
            }
            //else if (!key_detection) // && Script.isRunning()
            //{

//            }
        }

        private void oMnieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutme = new AboutBox1();
            aboutme.ShowDialog();
            //int width = SystemInformation.VirtualScreen.Width;
            //int height = SystemInformation.VirtualScreen.Height;
            //aboutme.Location = new Point(SystemInformation.VirtualScreen.Width, 50);
            //aboutme.Location.X = SystemInformation.VirtualScreen.Width;
        }

        private void instrukcjaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Instruction instrukcja = new Instruction();
            instrukcja.ShowDialog();
        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz rozpocząć pracę od nowa ?\n", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            Init();
            this.limitButton1.Checked = true;
            this.limitButton2.Checked = false;
            this.limitButton3.Checked = false;

            this.delayButton4.Checked = false;
            this.delayButton5.Checked = true;
            this.delayButton6.Checked = false;

            this.label5.Text = "brak";
            this.checkBox1.Checked = false;

            this.logs.Clear();
            this.script_box.Clear();
            this.script_box.Text = "your script here...";
        }

        private void skryptToolStripMenuItem_Click(object sender, EventArgs e) // wczytaj skrypt
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Wybierz plik z skryptem";
            ofd.Multiselect = false;
            ofd.Filter = "Mouse Script|*.ms|Text File|*.txt";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = ofd.FileName;
                StreamReader reader = new StreamReader(filename);
                this.logs.Clear();
                this.script_box.Clear();
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    this.script_box.AppendText(line + "\n");
                }
            }
        }

        private void skryptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Zapisz skrypt jako...";
            sfd.DefaultExt = "ms";
            sfd.Filter = "Mouse Script|*.ms|Text File|*.txt";
            sfd.FileName = "mouse_script";
            sfd.SupportMultiDottedExtensions = false;
            DialogResult result = sfd.ShowDialog();
            StreamWriter writer = null;
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                try
                {
                    writer = new StreamWriter(sfd.FileName);
                    int size = this.script_box.Lines.Count();
                    for (int i = 0; i<size; i++)
                    {
                        writer.WriteLine(this.script_box.Lines[i]);
                        //if (i + 1 != size) writer.WriteLine(this.script_box.Lines[i]);
                        //else writer.Write(this.script_box.Lines[i]);
                    }
                    writer.Close();
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void konfiguracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int delay = 0;
            if (this.delayButton4.Checked) delay = 0;
            else if (this.delayButton5.Checked) delay = 1;
            else if (this.delayButton6.Checked)
            {
                try
                {
                    delay = int.Parse(this.textBox1.Text);
                }
                catch (FormatException exp)
                {
                    MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int limit = 1;
            if (this.limitButton1.Checked) limit = 1;
            else if (this.limitButton2.Checked)
            {
                try
                {
                    limit = Decimal.ToInt32(this.numericUpDown1.Value);
                }
                catch (OverflowException exp)
                {
                    MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (this.limitButton3.Checked) limit = 0;

            char stop_key;
            try
            {
                stop_key = this.stop_key.getKey();
            }
            catch(NullReferenceException)
            {
                stop_key = (char)0;
            }
            
            SaveCFG savecfg = new SaveCFG();
            savecfg.setData(delay, stop_key, limit);
            savecfg.Show();
        }

        private void konfiguracjaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Config|*.cfg";
            ofd.Title = "Otwórz konfigurację";
            DialogResult result = ofd.ShowDialog();
            if (result != DialogResult.OK) return;

            FileStream file = null;
            BinaryReader breader = null;

            int delay, limit;
            char stop_key;
            string script_path;

            try
            {
                file = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                breader = new BinaryReader(file);

                delay = breader.ReadInt32();
                stop_key = breader.ReadChar();
                limit = breader.ReadInt32();
                script_path = breader.ReadString();

                breader.Close();
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (PathTooLongException exp)
            {
                MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(FileNotFoundException exp)
            {
                MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(IOException exp)
            {
                MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (delay)
            {
                case 0: // nothing
                    this.delayButton4.Checked = true;
                    this.delayButton5.Checked = false;
                    this.delayButton6.Checked = false;
                    this.textBox1.Enabled = false;
                    this.textBox1.Text = "";
                    break;
                case 1:
                    this.delayButton4.Checked = false;
                    this.delayButton5.Checked = true;
                    this.delayButton6.Checked = false;
                    this.textBox1.Enabled = false;
                    this.textBox1.Text = "";
                    break;
                default:
                    this.delayButton4.Checked = false;
                    this.delayButton5.Checked = false;
                    this.delayButton6.Checked = true;
                    this.textBox1.Enabled = true;
                    this.textBox1.Text = delay.ToString();
                    break;
            }

            switch (limit)
            {
                case 0: // inf
                    this.limitButton1.Checked = false;
                    this.limitButton2.Checked = false;
                    this.limitButton3.Checked = true;
                    this.numericUpDown1.Value = 5;
                    break;
                case 1:
                    this.limitButton1.Checked = true;
                    this.limitButton2.Checked = false;
                    this.limitButton3.Checked = false;
                    this.numericUpDown1.Value = 5;
                    break;
                default:
                    this.limitButton1.Checked = false;
                    this.limitButton2.Checked = true;
                    this.limitButton3.Checked = false;
                    this.numericUpDown1.Value = limit;
                    break;
            }

            if (script_path != "null")
            {
                try
                {
                    StreamReader reader = new StreamReader(script_path);
                    this.logs.Clear();
                    this.script_box.Clear();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        this.script_box.AppendText(line + "\n");
                    }
                }
                catch(ArgumentException exp)
                {
                    MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch(IOException exp)
                {
                    MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (stop_key == (char)0)
            {
                this.label5.Text = "brak";
                this.stop_key.Unregiser();
                this.stop_key = null;
            }
            else
            {
                if (this.stop_key == null) this.stop_key = new GlobalHotkey(Constants.NOMOD, (Keys)char.ToUpper(stop_key), 1, this);
                else
                {
                    this.stop_key.Unregiser();
                    this.stop_key = null;
                    this.stop_key = new GlobalHotkey(Constants.NOMOD, (Keys)char.ToUpper(stop_key), 1, this);
                }
                this.stop_key.Register();
                this.label5.Text = char.ToUpper(stop_key).ToString();
            }
        }
    }
}
