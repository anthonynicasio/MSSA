namespace Names
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
            btnAdd = new Button();
            label1 = new Label();
            lstNames = new ListBox();
            txtNames = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(138, 55);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 31);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Name";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 1;
            label1.Text = "Names";
            // 
            // lstNames
            // 
            lstNames.FormattingEnabled = true;
            lstNames.Location = new Point(12, 27);
            lstNames.Name = "lstNames";
            lstNames.Size = new Size(120, 84);
            lstNames.TabIndex = 2;
            // 
            // txtNames
            // 
            txtNames.Location = new Point(138, 26);
            txtNames.Name = "txtNames";
            txtNames.Size = new Size(100, 27);
            txtNames.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(138, 90);
            button1.Name = "button1";
            button1.Size = new Size(100, 31);
            button1.TabIndex = 4;
            button1.Text = "Add Name";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 133);
            Controls.Add(button1);
            Controls.Add(txtNames);
            Controls.Add(lstNames);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Names";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label label1;
        private ListBox lstNames;
        private TextBox txtNames;
        private Button button1;
    }
}
