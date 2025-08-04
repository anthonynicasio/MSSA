namespace Dictionary
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
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtMobileNumber = new TextBox();
            txtSearch = new TextBox();
            txtAddress = new TextBox();
            txtWorkPhone = new TextBox();
            btnAdd = new Button();
            btnSearch = new Button();
            btnDelete = new Button();
            dataGridViewPeople = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPeople).BeginInit();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(115, 9);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 0;
            txtFirstName.TextChanged += textBox1_TextChanged;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(331, 9);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 1;
            // 
            // txtMobileNumber
            // 
            txtMobileNumber.Location = new Point(115, 42);
            txtMobileNumber.Name = "txtMobileNumber";
            txtMobileNumber.Size = new Size(125, 27);
            txtMobileNumber.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(421, 138);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(115, 85);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(480, 27);
            txtAddress.TabIndex = 4;
            // 
            // txtWorkPhone
            // 
            txtWorkPhone.Location = new Point(331, 42);
            txtWorkPhone.Name = "txtWorkPhone";
            txtWorkPhone.Size = new Size(125, 27);
            txtWorkPhone.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(53, 138);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(290, 138);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(172, 138);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridViewPeople
            // 
            dataGridViewPeople.AllowUserToAddRows = false;
            dataGridViewPeople.AllowUserToDeleteRows = false;
            dataGridViewPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPeople.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPeople.Location = new Point(29, 197);
            dataGridViewPeople.Name = "dataGridViewPeople";
            dataGridViewPeople.ReadOnly = true;
            dataGridViewPeople.RowHeadersWidth = 51;
            dataGridViewPeople.Size = new Size(738, 225);
            dataGridViewPeople.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 12);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 10;
            label1.Text = "First Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 12);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 11;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 45);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 12;
            label3.Text = "Mobile";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(272, 45);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 13;
            label4.Text = "Work";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 88);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 14;
            label5.Text = "Address";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewPeople);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(btnAdd);
            Controls.Add(txtWorkPhone);
            Controls.Add(txtAddress);
            Controls.Add(txtSearch);
            Controls.Add(txtMobileNumber);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPeople).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtMobileNumber;
        private TextBox txtSearch;
        private TextBox txtAddress;
        private TextBox txtWorkPhone;
        private Button btnAdd;
        private Button btnSearch;
        private Button btnDelete;
        private DataGridView dataGridViewPeople;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
