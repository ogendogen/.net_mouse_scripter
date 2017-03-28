using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mouse_scripter
{
    public partial class SaveCFG : Form
    {
        public SaveCFG()
        {
            InitializeComponent();
        }

        public void setData(int delay, char key, int breakk)
        {
            this.delay = delay;
            this.key = key;
            this.breakk = breakk;
        }

        private int delay;
        private char key;
        private int breakk;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Wybierz plik z skryptem";
            ofd.Multiselect = false;
            ofd.Filter = "Mouse Script|*.ms|Text File|*.txt";
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = ofd.FileName;
                string[] parts = path.Split('\\');
                this.textBox1.Text = parts.Last();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                MessageBox.Show("Skrypt ładowany z konfiguracji powinnien znajdować się w tym samym folderze co aplikacja.", "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.button2.Enabled = true;
                this.textBox1.Enabled = true;
            }
            else
            {
                this.button2.Enabled = false;
                this.textBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string scriptpath = this.textBox1.Text;
            if (scriptpath == "") scriptpath = "null";
            else
            {
                string[] parts = scriptpath.Split('\\');
                scriptpath = parts.Last(); // sama nazwa pliku, bez ścieżki
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Config|*.cfg";
            sfd.FileName = "MyMouseConfig";
            sfd.Title = "Zapisz konfiguracje jako...";
            DialogResult result = sfd.ShowDialog();
            if (result != DialogResult.OK && result != DialogResult.Yes) return;

            BinaryWriter bwriter = null;
            FileStream file = null;
            try
            {
                file = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                bwriter = new BinaryWriter(file);
                bwriter.Write(this.delay);
                bwriter.Write(this.key);
                bwriter.Write(this.breakk);
                bwriter.Write(scriptpath);
                MessageBox.Show("Konfiguracja zapisana jako " + sfd.FileName, "Powodzenie!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(ArgumentException exp)
            {
                MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (PathTooLongException exp)
            {
                MessageBox.Show(exp.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                if (file != null) file.Close();
                if (bwriter != null) bwriter.Close();
            }
        }
    }
}
