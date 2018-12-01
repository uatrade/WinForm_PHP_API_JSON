namespace WindowsFormsApp10
{
    partial class FormAddInfo
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
            this.TextBoxAddCountry = new System.Windows.Forms.TextBox();
            this.BtnAddCountry = new System.Windows.Forms.Button();
            this.textBoxAddCity = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxCountryAdd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddCity = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxAddCountry
            // 
            this.TextBoxAddCountry.Location = new System.Drawing.Point(6, 19);
            this.TextBoxAddCountry.Name = "TextBoxAddCountry";
            this.TextBoxAddCountry.Size = new System.Drawing.Size(205, 20);
            this.TextBoxAddCountry.TabIndex = 0;
            // 
            // BtnAddCountry
            // 
            this.BtnAddCountry.Location = new System.Drawing.Point(262, 16);
            this.BtnAddCountry.Name = "BtnAddCountry";
            this.BtnAddCountry.Size = new System.Drawing.Size(109, 23);
            this.BtnAddCountry.TabIndex = 1;
            this.BtnAddCountry.Text = "Добавить страну";
            this.BtnAddCountry.UseVisualStyleBackColor = true;
            this.BtnAddCountry.Click += new System.EventHandler(this.BtnAddCountry_Click);
            // 
            // textBoxAddCity
            // 
            this.textBoxAddCity.Location = new System.Drawing.Point(6, 102);
            this.textBoxAddCity.Name = "textBoxAddCity";
            this.textBoxAddCity.Size = new System.Drawing.Size(199, 20);
            this.textBoxAddCity.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddCity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxCountryAdd);
            this.groupBox1.Controls.Add(this.textBoxAddCity);
            this.groupBox1.Location = new System.Drawing.Point(63, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление городов";
            // 
            // comboBoxCountryAdd
            // 
            this.comboBoxCountryAdd.FormattingEnabled = true;
            this.comboBoxCountryAdd.Location = new System.Drawing.Point(7, 47);
            this.comboBoxCountryAdd.Name = "comboBoxCountryAdd";
            this.comboBoxCountryAdd.Size = new System.Drawing.Size(198, 21);
            this.comboBoxCountryAdd.TabIndex = 3;
            this.comboBoxCountryAdd.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountryAdd_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Список стран";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Новый город";
            // 
            // buttonAddCity
            // 
            this.buttonAddCity.Location = new System.Drawing.Point(243, 102);
            this.buttonAddCity.Name = "buttonAddCity";
            this.buttonAddCity.Size = new System.Drawing.Size(128, 23);
            this.buttonAddCity.TabIndex = 6;
            this.buttonAddCity.Text = "Добавить город";
            this.buttonAddCity.UseVisualStyleBackColor = true;
            this.buttonAddCity.Click += new System.EventHandler(this.buttonAddCity_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TextBoxAddCountry);
            this.groupBox2.Controls.Add(this.BtnAddCountry);
            this.groupBox2.Location = new System.Drawing.Point(63, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 55);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавление стран";
            // 
            // FormAddInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 322);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAddInfo";
            this.Text = "Добавление данных";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxAddCountry;
        private System.Windows.Forms.Button BtnAddCountry;
        private System.Windows.Forms.TextBox textBoxAddCity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddCity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCountryAdd;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}