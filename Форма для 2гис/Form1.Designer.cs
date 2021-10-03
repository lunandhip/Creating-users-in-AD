namespace Форма_для_2гис
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FormFIO = new System.Windows.Forms.TextBox();
            this.FormAnswer = new System.Windows.Forms.TextBox();
            this.FormNomerVn = new System.Windows.Forms.TextBox();
            this.FormMobNomer = new System.Windows.Forms.TextBox();
            this.FormLeader = new System.Windows.Forms.TextBox();
            this.FormDate = new System.Windows.Forms.TextBox();
            this.Exit2 = new System.Windows.Forms.PictureBox();
            this.CiteBox = new System.Windows.Forms.ComboBox();
            this.GenderBox = new System.Windows.Forms.ComboBox();
            this.BoxPassword = new System.Windows.Forms.ComboBox();
            this.HylaBox = new System.Windows.Forms.PictureBox();
            this.CopyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Exit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HylaBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Город";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Полное ФИО";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата рождения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Пол";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Фамилия Руков.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(20, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Пароль на выбор";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(20, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Личный мобиль";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(20, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Внутренний номер";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(328, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Данные нового пользователя";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(163, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 42);
            this.button1.TabIndex = 9;
            this.button1.Text = "Роцк!";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormFIO
            // 
            this.FormFIO.BackColor = System.Drawing.Color.Black;
            this.FormFIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormFIO.ForeColor = System.Drawing.Color.White;
            this.FormFIO.Location = new System.Drawing.Point(122, 50);
            this.FormFIO.Name = "FormFIO";
            this.FormFIO.Size = new System.Drawing.Size(158, 20);
            this.FormFIO.TabIndex = 10;
            // 
            // FormAnswer
            // 
            this.FormAnswer.BackColor = System.Drawing.Color.Black;
            this.FormAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormAnswer.ForeColor = System.Drawing.Color.White;
            this.FormAnswer.Location = new System.Drawing.Point(312, 239);
            this.FormAnswer.Multiline = true;
            this.FormAnswer.Name = "FormAnswer";
            this.FormAnswer.Size = new System.Drawing.Size(219, 70);
            this.FormAnswer.TabIndex = 11;
            // 
            // FormNomerVn
            // 
            this.FormNomerVn.BackColor = System.Drawing.Color.Black;
            this.FormNomerVn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormNomerVn.ForeColor = System.Drawing.Color.White;
            this.FormNomerVn.Location = new System.Drawing.Point(123, 242);
            this.FormNomerVn.Name = "FormNomerVn";
            this.FormNomerVn.Size = new System.Drawing.Size(157, 20);
            this.FormNomerVn.TabIndex = 12;
            // 
            // FormMobNomer
            // 
            this.FormMobNomer.BackColor = System.Drawing.Color.Black;
            this.FormMobNomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormMobNomer.ForeColor = System.Drawing.Color.White;
            this.FormMobNomer.Location = new System.Drawing.Point(123, 209);
            this.FormMobNomer.Name = "FormMobNomer";
            this.FormMobNomer.Size = new System.Drawing.Size(157, 20);
            this.FormMobNomer.TabIndex = 13;
            // 
            // FormLeader
            // 
            this.FormLeader.BackColor = System.Drawing.Color.Black;
            this.FormLeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormLeader.ForeColor = System.Drawing.Color.White;
            this.FormLeader.Location = new System.Drawing.Point(123, 146);
            this.FormLeader.Name = "FormLeader";
            this.FormLeader.Size = new System.Drawing.Size(157, 20);
            this.FormLeader.TabIndex = 14;
            // 
            // FormDate
            // 
            this.FormDate.BackColor = System.Drawing.Color.Black;
            this.FormDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormDate.ForeColor = System.Drawing.Color.White;
            this.FormDate.Location = new System.Drawing.Point(122, 79);
            this.FormDate.Name = "FormDate";
            this.FormDate.Size = new System.Drawing.Size(158, 20);
            this.FormDate.TabIndex = 15;
            // 
            // Exit2
            // 
            this.Exit2.BackColor = System.Drawing.Color.Transparent;
            this.Exit2.BackgroundImage = global::Форма_для_2гис.Properties.Resources.close2;
            this.Exit2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit2.Location = new System.Drawing.Point(515, 1);
            this.Exit2.Name = "Exit2";
            this.Exit2.Size = new System.Drawing.Size(46, 40);
            this.Exit2.TabIndex = 16;
            this.Exit2.TabStop = false;
            this.Exit2.Click += new System.EventHandler(this.Exit2_Click);
            // 
            // CiteBox
            // 
            this.CiteBox.BackColor = System.Drawing.Color.Black;
            this.CiteBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.CiteBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CiteBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CiteBox.ForeColor = System.Drawing.Color.White;
            this.CiteBox.FormattingEnabled = true;
            this.CiteBox.Items.AddRange(new object[] {
            "Краснодар",
            "Астрахань",
            "Сочи",
            "Таганрог",
            "Армавир"});
            this.CiteBox.Location = new System.Drawing.Point(122, 20);
            this.CiteBox.Name = "CiteBox";
            this.CiteBox.Size = new System.Drawing.Size(158, 21);
            this.CiteBox.TabIndex = 17;
            this.CiteBox.SelectedIndexChanged += new System.EventHandler(this.CiteBox_SelectedIndexChanged);
            // 
            // GenderBox
            // 
            this.GenderBox.BackColor = System.Drawing.Color.Black;
            this.GenderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenderBox.ForeColor = System.Drawing.Color.White;
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Items.AddRange(new object[] {
            "Чувак",
            "Чувиха"});
            this.GenderBox.Location = new System.Drawing.Point(122, 113);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.Size = new System.Drawing.Size(158, 21);
            this.GenderBox.TabIndex = 18;
            this.GenderBox.SelectedIndexChanged += new System.EventHandler(this.GenderBox_SelectedIndexChanged);
            // 
            // BoxPassword
            // 
            this.BoxPassword.BackColor = System.Drawing.Color.Black;
            this.BoxPassword.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BoxPassword.ForeColor = System.Drawing.Color.White;
            this.BoxPassword.FormattingEnabled = true;
            this.BoxPassword.Location = new System.Drawing.Point(122, 177);
            this.BoxPassword.Name = "BoxPassword";
            this.BoxPassword.Size = new System.Drawing.Size(158, 21);
            this.BoxPassword.TabIndex = 19;
            // 
            // HylaBox
            // 
            this.HylaBox.BackColor = System.Drawing.Color.Transparent;
            this.HylaBox.BackgroundImage = global::Форма_для_2гис.Properties.Resources.frog;
            this.HylaBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HylaBox.Location = new System.Drawing.Point(525, 332);
            this.HylaBox.Name = "HylaBox";
            this.HylaBox.Size = new System.Drawing.Size(36, 28);
            this.HylaBox.TabIndex = 20;
            this.HylaBox.TabStop = false;
            this.HylaBox.Click += new System.EventHandler(this.HylaBox_Click);
            // 
            // CopyButton
            // 
            this.CopyButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CopyButton.Location = new System.Drawing.Point(373, 315);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(86, 34);
            this.CopyButton.TabIndex = 21;
            this.CopyButton.Text = "Копировать";
            this.CopyButton.UseVisualStyleBackColor = false;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Форма_для_2гис.Properties.Resources.iron_maiden2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(561, 361);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.HylaBox);
            this.Controls.Add(this.BoxPassword);
            this.Controls.Add(this.GenderBox);
            this.Controls.Add(this.CiteBox);
            this.Controls.Add(this.Exit2);
            this.Controls.Add(this.FormDate);
            this.Controls.Add(this.FormLeader);
            this.Controls.Add(this.FormMobNomer);
            this.Controls.Add(this.FormNomerVn);
            this.Controls.Add(this.FormAnswer);
            this.Controls.Add(this.FormFIO);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.Exit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HylaBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox FormFIO;
        private System.Windows.Forms.TextBox FormAnswer;
        private System.Windows.Forms.TextBox FormNomerVn;
        private System.Windows.Forms.TextBox FormMobNomer;
        private System.Windows.Forms.TextBox FormLeader;
        private System.Windows.Forms.TextBox FormDate;
        private System.Windows.Forms.PictureBox Exit2;
        private System.Windows.Forms.ComboBox CiteBox;
        private System.Windows.Forms.ComboBox GenderBox;
        private System.Windows.Forms.ComboBox BoxPassword;
        private System.Windows.Forms.PictureBox HylaBox;
        private System.Windows.Forms.Button CopyButton;
    }
}

