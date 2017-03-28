using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace mouse_scripter
{
    public partial class Instruction : Form
    {
        private struct Commands
        {
            public string[] syntax;
            public string[] desc;
            public string[] example;
        }

        private Commands cmd_goto;
        private Commands cmd_left_click;
        private Commands cmd_delay;
        private Commands cmd_dragndrop;

        private void prepareDescription()
        {
            // goto
            cmd_goto = new Commands();
            cmd_goto.syntax = new string[4];
            cmd_goto.desc = new string[4];
            cmd_goto.example = new string[4];
            cmd_goto.syntax[0] = "goto(x,y) - x,y są liczbami dodatnimi, reprezentują pozycję na ekranie.";
            cmd_goto.syntax[1] = "X i Y zaczynamy liczyć od zera, nie mogą być większe niż rozdzielczość.";
            cmd_goto.syntax[2] = "Aktualną pozycję kursora możemy pobrać za pomocą narzędzia w aplikacji.";
            cmd_goto.desc[0] = "Polecenie przesuwa kursor na daną pozycję (X,Y)";
            cmd_goto.example[0] = "goto(300,400) // przesuwa kursor na pozycje X = 300, Y = 400.";
            cmd_goto.example[1] = "goto(0,0) // przesuwa kursor w górny lewy róg ekranu.";
            cmd_goto.example[2] = "goto(-50, -100) // błędne polecenie, pozycja nie może być ujemna!";

            // left_click
            cmd_left_click = new Commands();
            cmd_left_click.syntax = new string[4];
            cmd_left_click.desc = new string[4];
            cmd_left_click.example = new string[4];
            cmd_left_click.syntax[0] = "left_click - polecenie nie przyjmuje żadnych wartości.";
            cmd_left_click.syntax[1] = "Polecenie zawsze używamy w ten sam sposób.";
            cmd_left_click.desc[0] = "Polecenie klika w miejsce w którym aktualnie znajduje się kursor.";
            cmd_left_click.desc[1] = "UWAGA! Wcześniej należy ustawić kursor za pomocą goto(x,y)";
            cmd_left_click.example[0] = "goto(100,200) // przesun kursor na pozycje 100,200";
            cmd_left_click.example[1] = "left_click // kliknij w miejscu 100,200";

            // delay
            cmd_delay = new Commands();
            cmd_delay.syntax = new string[4];
            cmd_delay.desc = new string[4];
            cmd_delay.example = new string[4];
            cmd_delay.syntax[0] = "delay(x) - x jest liczbą dodatnią, określa ilość sekund.";
            cmd_delay.desc[0] = "Polecenie zatrzymuje skrypt na określoną ilość sekund.";
            cmd_delay.desc[1] = "Ilość sekund określamy w nawiasie.";
            cmd_delay.example[0] = "delay(5) // zatrzyma skrypt na 5 sekund";
            cmd_delay.example[1] = "delay(0) // dopuszczalne, jednak bezużyteczne";
            cmd_delay.example[2] = "delay(-3) // błąd! czas nie może być ujemny !";

            // dragndrop
            cmd_dragndrop = new Commands();
            cmd_dragndrop.syntax = new string[4];
            cmd_dragndrop.desc = new string[4];
            cmd_dragndrop.example = new string[4];
            cmd_dragndrop.syntax[0] = "dragndrop(x1,y1,x2,y2) - wszystkie wartości są liczbami dodatnimi.";
            cmd_dragndrop.syntax[1] = "Każda wartość reprezentuje pozycję na ekranie.";
            cmd_dragndrop.syntax[2] = "Są liczone od zera, nie mogą być większe niż rozdzielczość";
            cmd_dragndrop.desc[0] = "Polecenie wykonuje przeciągnięcie np. ikony";
            cmd_dragndrop.desc[1] = "Przeciąganie zaczyna się w pozycji startowej (x1,y1)";
            cmd_dragndrop.desc[2] = "Myszka jest \"puszczana\" w pozycji końcowej (x2,y2)";
            cmd_dragndrop.desc[3] = "Polecenie nie wymaga wcześniejszego ustawienia kursora!";
            cmd_dragndrop.example[0] = "dragndrop(150,150,300,400) // przeciąga z pozycji(150,150) na pozycję (300,400)";
            cmd_dragndrop.example[1] = "dragndrop(100,100,-50,200) // błąd! jedna liczba jest ujemna";
        }

        public Instruction()
        {
            InitializeComponent();
            prepareDescription();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = this.comboBox1.SelectedIndex;
            this.comboBox2.SelectedIndex = id;
            switch(id)
            {
                case 0:
                    this.textBox1.Lines = cmd_goto.syntax;
                    this.textBox2.Lines = cmd_goto.desc;
                    this.textBox3.Lines = cmd_goto.example;
                    break;
                case 1:
                    this.textBox1.Lines = cmd_left_click.syntax;
                    this.textBox2.Lines = cmd_left_click.desc;
                    this.textBox3.Lines = cmd_left_click.example;
                    break;
                case 2:
                    this.textBox1.Lines = cmd_delay.syntax;
                    this.textBox2.Lines = cmd_delay.desc;
                    this.textBox3.Lines = cmd_delay.example;
                    break;
                case 3:
                    this.textBox1.Lines = cmd_dragndrop.syntax;
                    this.textBox2.Lines = cmd_dragndrop.desc;
                    this.textBox3.Lines = cmd_dragndrop.example;
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = this.comboBox2.SelectedIndex;
            this.comboBox1.SelectedIndex = id;
            switch (id)
            {
                case 0:
                    this.textBox1.Lines = cmd_goto.syntax;
                    this.textBox2.Lines = cmd_goto.desc;
                    this.textBox3.Lines = cmd_goto.example;
                    break;
                case 1:
                    this.textBox1.Lines = cmd_left_click.syntax;
                    this.textBox2.Lines = cmd_left_click.desc;
                    this.textBox3.Lines = cmd_left_click.example;
                    break;
                case 2:
                    this.textBox1.Lines = cmd_delay.syntax;
                    this.textBox2.Lines = cmd_delay.desc;
                    this.textBox3.Lines = cmd_delay.example;
                    break;
                case 3:
                    this.textBox1.Lines = cmd_dragndrop.syntax;
                    this.textBox2.Lines = cmd_dragndrop.desc;
                    this.textBox3.Lines = cmd_dragndrop.example;
                    break;
            }
        }
    }
}
