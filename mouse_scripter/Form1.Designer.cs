namespace mouse_scripter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.script_box = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.limitButton1 = new System.Windows.Forms.RadioButton();
            this.limitButton2 = new System.Windows.Forms.RadioButton();
            this.limitButton3 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.delayButton6 = new System.Windows.Forms.RadioButton();
            this.delayButton5 = new System.Windows.Forms.RadioButton();
            this.delayButton4 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skryptToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.konfiguracjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyjdźToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrukcjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oMnieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konfiguracjaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // script_box
            // 
            this.script_box.AllowDrop = true;
            this.script_box.BackColor = System.Drawing.Color.Black;
            this.script_box.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.script_box.ForeColor = System.Drawing.Color.Lime;
            this.script_box.Location = new System.Drawing.Point(0, 27);
            this.script_box.Multiline = true;
            this.script_box.Name = "script_box";
            this.script_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.script_box.Size = new System.Drawing.Size(265, 355);
            this.script_box.TabIndex = 0;
            this.script_box.Text = "your script here...";
            this.script_box.Click += new System.EventHandler(this.script_box_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sprawdź poprawność skryptu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(0, 388);
            this.logs.Multiline = true;
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logs.Size = new System.Drawing.Size(725, 78);
            this.logs.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sekwencja uruchamiania:";
            // 
            // limitButton1
            // 
            this.limitButton1.AutoSize = true;
            this.limitButton1.Checked = true;
            this.limitButton1.Location = new System.Drawing.Point(274, 97);
            this.limitButton1.Name = "limitButton1";
            this.limitButton1.Size = new System.Drawing.Size(44, 17);
            this.limitButton1.TabIndex = 4;
            this.limitButton1.TabStop = true;
            this.limitButton1.Text = "Raz";
            this.limitButton1.UseVisualStyleBackColor = true;
            // 
            // limitButton2
            // 
            this.limitButton2.AutoSize = true;
            this.limitButton2.Location = new System.Drawing.Point(274, 121);
            this.limitButton2.Name = "limitButton2";
            this.limitButton2.Size = new System.Drawing.Size(14, 13);
            this.limitButton2.TabIndex = 5;
            this.limitButton2.TabStop = true;
            this.limitButton2.UseVisualStyleBackColor = true;
            // 
            // limitButton3
            // 
            this.limitButton3.AutoSize = true;
            this.limitButton3.Location = new System.Drawing.Point(274, 144);
            this.limitButton3.Name = "limitButton3";
            this.limitButton3.Size = new System.Drawing.Size(126, 17);
            this.limitButton3.TabIndex = 6;
            this.limitButton3.TabStop = true;
            this.limitButton3.Text = "Nieskończoność razy";
            this.limitButton3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(295, 118);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "razy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Przerwa między końcem a początkiem:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.delayButton6);
            this.panel1.Controls.Add(this.delayButton5);
            this.panel1.Controls.Add(this.delayButton4);
            this.panel1.Location = new System.Drawing.Point(277, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 100);
            this.panel1.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(4, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // delayButton6
            // 
            this.delayButton6.AutoSize = true;
            this.delayButton6.Location = new System.Drawing.Point(4, 51);
            this.delayButton6.Name = "delayButton6";
            this.delayButton6.Size = new System.Drawing.Size(103, 17);
            this.delayButton6.TabIndex = 2;
            this.delayButton6.Text = "Własna wartość";
            this.delayButton6.UseVisualStyleBackColor = true;
            this.delayButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // delayButton5
            // 
            this.delayButton5.AutoSize = true;
            this.delayButton5.Checked = true;
            this.delayButton5.Location = new System.Drawing.Point(4, 27);
            this.delayButton5.Name = "delayButton5";
            this.delayButton5.Size = new System.Drawing.Size(122, 17);
            this.delayButton5.TabIndex = 1;
            this.delayButton5.TabStop = true;
            this.delayButton5.Text = "Sekundowa przerwa";
            this.delayButton5.UseVisualStyleBackColor = true;
            // 
            // delayButton4
            // 
            this.delayButton4.AutoSize = true;
            this.delayButton4.Location = new System.Drawing.Point(4, 4);
            this.delayButton4.Name = "delayButton4";
            this.delayButton4.Size = new System.Drawing.Size(82, 17);
            this.delayButton4.TabIndex = 0;
            this.delayButton4.Text = "Bez przerwy";
            this.delayButton4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(529, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 92);
            this.button2.TabIndex = 12;
            this.button2.Text = "START";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(529, 144);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Zarejestruj klawisz stopu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Zarejestrowany klawisz:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "brak";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(529, 227);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Włącz śledzenie kursora";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(526, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Pozycja = {0,0}";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(529, 257);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(155, 17);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Kopiuj pozycje do schowka";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.instrukcjaToolStripMenuItem,
            this.oMnieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowyToolStripMenuItem,
            this.wczytajToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.wyjdźToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // nowyToolStripMenuItem
            // 
            this.nowyToolStripMenuItem.Name = "nowyToolStripMenuItem";
            this.nowyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nowyToolStripMenuItem.Text = "Nowy";
            this.nowyToolStripMenuItem.Click += new System.EventHandler(this.nowyToolStripMenuItem_Click);
            // 
            // wczytajToolStripMenuItem
            // 
            this.wczytajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skryptToolStripMenuItem,
            this.konfiguracjaToolStripMenuItem1});
            this.wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            this.wczytajToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wczytajToolStripMenuItem.Text = "Wczytaj";
            // 
            // skryptToolStripMenuItem
            // 
            this.skryptToolStripMenuItem.Name = "skryptToolStripMenuItem";
            this.skryptToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.skryptToolStripMenuItem.Text = "Skrypt";
            this.skryptToolStripMenuItem.Click += new System.EventHandler(this.skryptToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skryptToolStripMenuItem1,
            this.konfiguracjaToolStripMenuItem});
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            // 
            // skryptToolStripMenuItem1
            // 
            this.skryptToolStripMenuItem1.Name = "skryptToolStripMenuItem1";
            this.skryptToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.skryptToolStripMenuItem1.Text = "Skrypt";
            this.skryptToolStripMenuItem1.Click += new System.EventHandler(this.skryptToolStripMenuItem1_Click);
            // 
            // konfiguracjaToolStripMenuItem
            // 
            this.konfiguracjaToolStripMenuItem.Name = "konfiguracjaToolStripMenuItem";
            this.konfiguracjaToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.konfiguracjaToolStripMenuItem.Text = "Konfiguracja";
            this.konfiguracjaToolStripMenuItem.Click += new System.EventHandler(this.konfiguracjaToolStripMenuItem_Click);
            // 
            // wyjdźToolStripMenuItem
            // 
            this.wyjdźToolStripMenuItem.Name = "wyjdźToolStripMenuItem";
            this.wyjdźToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wyjdźToolStripMenuItem.Text = "Wyjdź";
            this.wyjdźToolStripMenuItem.Click += new System.EventHandler(this.wyjdźToolStripMenuItem_Click);
            // 
            // instrukcjaToolStripMenuItem
            // 
            this.instrukcjaToolStripMenuItem.Name = "instrukcjaToolStripMenuItem";
            this.instrukcjaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.instrukcjaToolStripMenuItem.Text = "Instrukcja";
            this.instrukcjaToolStripMenuItem.Click += new System.EventHandler(this.instrukcjaToolStripMenuItem_Click_1);
            // 
            // oMnieToolStripMenuItem
            // 
            this.oMnieToolStripMenuItem.Name = "oMnieToolStripMenuItem";
            this.oMnieToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.oMnieToolStripMenuItem.Text = "O mnie";
            this.oMnieToolStripMenuItem.Click += new System.EventHandler(this.oMnieToolStripMenuItem_Click);
            // 
            // konfiguracjaToolStripMenuItem1
            // 
            this.konfiguracjaToolStripMenuItem1.Name = "konfiguracjaToolStripMenuItem1";
            this.konfiguracjaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.konfiguracjaToolStripMenuItem1.Text = "Konfiguracja";
            this.konfiguracjaToolStripMenuItem1.Click += new System.EventHandler(this.konfiguracjaToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 466);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.limitButton3);
            this.Controls.Add(this.limitButton2);
            this.Controls.Add(this.limitButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.script_box);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Mouse Scripter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox script_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox logs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton limitButton1;
        private System.Windows.Forms.RadioButton limitButton2;
        private System.Windows.Forms.RadioButton limitButton3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton delayButton6;
        private System.Windows.Forms.RadioButton delayButton5;
        private System.Windows.Forms.RadioButton delayButton4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrukcjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oMnieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skryptToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wyjdźToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konfiguracjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konfiguracjaToolStripMenuItem1;
    }
}

