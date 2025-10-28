namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Submit = new Button();
            ST_name = new TextBox();
            ST_Class = new TextBox();
            ST_Age = new TextBox();
            dataGridView1 = new DataGridView();
            DisplayData = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Submit
            // 
            Submit.Font = new Font("Segoe UI", 20F);
            Submit.Location = new Point(311, 427);
            Submit.Name = "Submit";
            Submit.Size = new Size(224, 81);
            Submit.TabIndex = 0;
            Submit.Text = "Внести данные";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // ST_name
            // 
            ST_name.AccessibleName = "ST_name";
            ST_name.Location = new Point(58, 428);
            ST_name.Name = "ST_name";
            ST_name.PlaceholderText = "Имя Студента";
            ST_name.Size = new Size(191, 23);
            ST_name.TabIndex = 1;
            ST_name.TextChanged += textBox1_TextChanged;
            // 
            // ST_Class
            // 
            ST_Class.Location = new Point(58, 486);
            ST_Class.Name = "ST_Class";
            ST_Class.PlaceholderText = "Группа Студента";
            ST_Class.Size = new Size(191, 23);
            ST_Class.TabIndex = 2;
            // 
            // ST_Age
            // 
            ST_Age.Location = new Point(58, 457);
            ST_Age.Name = "ST_Age";
            ST_Age.PlaceholderText = "Возраст Студента";
            ST_Age.Size = new Size(191, 23);
            ST_Age.TabIndex = 3;
            ST_Age.TextChanged += textBox3_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(793, 376);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // DisplayData
            // 
            DisplayData.Font = new Font("Segoe UI", 20F);
            DisplayData.Location = new Point(541, 427);
            DisplayData.Name = "DisplayData";
            DisplayData.Size = new Size(227, 80);
            DisplayData.TabIndex = 6;
            DisplayData.Text = "Вывод данных";
            DisplayData.UseVisualStyleBackColor = true;
            DisplayData.Click += DisplayData_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 537);
            Controls.Add(DisplayData);
            Controls.Add(dataGridView1);
            Controls.Add(ST_Age);
            Controls.Add(ST_Class);
            Controls.Add(ST_name);
            Controls.Add(Submit);
            Name = "Form1";
            Text = "Как подключить БД к WinForm";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Submit;
        private TextBox ST_name;
        private TextBox ST_Class;
        private TextBox ST_Age;
        private DataGridView dataGridView1;
        private Button DisplayData;
    }
}
