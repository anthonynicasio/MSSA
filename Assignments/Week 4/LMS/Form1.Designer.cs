namespace LMS
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
            pnlLogin = new Panel();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnLogin = new Button();
            pnlDashboard = new Panel();
            dataGridView1 = new DataGridView();
            btnSaveTopGPA = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtGPA = new TextBox();
            label6 = new Label();
            txtLastName = new TextBox();
            label5 = new Label();
            txtFirstName = new TextBox();
            label4 = new Label();
            txtStudentId = new TextBox();
            label3 = new Label();
            pnlLogin.SuspendLayout();
            pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(txtPassword);
            pnlLogin.Controls.Add(txtUsername);
            pnlLogin.Controls.Add(label2);
            pnlLogin.Controls.Add(label1);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Dock = DockStyle.Fill;
            pnlLogin.Location = new Point(0, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(800, 450);
            pnlLogin.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(303, 152);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(303, 111);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(224, 155);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(219, 114);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            label1.Click += label1_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(469, 132);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // pnlDashboard
            // 
            pnlDashboard.Controls.Add(dataGridView1);
            pnlDashboard.Controls.Add(btnSaveTopGPA);
            pnlDashboard.Controls.Add(btnDelete);
            pnlDashboard.Controls.Add(btnAdd);
            pnlDashboard.Controls.Add(txtGPA);
            pnlDashboard.Controls.Add(label6);
            pnlDashboard.Controls.Add(txtLastName);
            pnlDashboard.Controls.Add(label5);
            pnlDashboard.Controls.Add(txtFirstName);
            pnlDashboard.Controls.Add(label4);
            pnlDashboard.Controls.Add(txtStudentId);
            pnlDashboard.Controls.Add(label3);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 0);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(800, 450);
            pnlDashboard.TabIndex = 0;
            pnlDashboard.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 242);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 188);
            dataGridView1.TabIndex = 11;
            // 
            // btnSaveTopGPA
            // 
            btnSaveTopGPA.Location = new Point(304, 63);
            btnSaveTopGPA.Name = "btnSaveTopGPA";
            btnSaveTopGPA.Size = new Size(124, 29);
            btnSaveTopGPA.TabIndex = 10;
            btnSaveTopGPA.Text = "Save Top GPA";
            btnSaveTopGPA.UseVisualStyleBackColor = true;
            btnSaveTopGPA.Click += btnSaveTopGPA_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(434, 24);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete Selected";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(303, 24);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(125, 29);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add Student";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtGPA
            // 
            txtGPA.Location = new Point(117, 146);
            txtGPA.Name = "txtGPA";
            txtGPA.Size = new Size(125, 27);
            txtGPA.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(59, 149);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 6;
            label6.Text = "GPA:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(117, 107);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(125, 27);
            txtLastName.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 110);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 4;
            label5.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(117, 69);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(125, 27);
            txtFirstName.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 72);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 2;
            label4.Text = "First Name:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(117, 30);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(125, 27);
            txtStudentId.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 33);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 0;
            label3.Text = "Student ID:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlDashboard);
            Controls.Add(pnlLogin);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogin;
        private Panel pnlDashboard;
        private Label label1;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label2;
        private DataGridView dataGridView1;
        private Button btnSaveTopGPA;
        private Button btnDelete;
        private Button btnAdd;
        private TextBox txtGPA;
        private Label label6;
        private TextBox txtLastName;
        private Label label5;
        private TextBox txtFirstName;
        private Label label4;
        private TextBox txtStudentId;
        private Label label3;
    }
}
