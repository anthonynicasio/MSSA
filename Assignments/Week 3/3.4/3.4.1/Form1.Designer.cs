namespace _3._4._1
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            bindingSource1 = new BindingSource(components);
            coffeeBindingSource = new BindingSource(components);
            cofRoastDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isDecafDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            typeOfDrinkDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bevIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bevNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            expDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bevContainerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bevMfrDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sizeInOzDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            flavorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bevTempDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coffeeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { cofRoastDataGridViewTextBoxColumn, isDecafDataGridViewCheckBoxColumn, typeOfDrinkDataGridViewTextBoxColumn, bevIDDataGridViewTextBoxColumn, bevNameDataGridViewTextBoxColumn, expDateDataGridViewTextBoxColumn, bevContainerDataGridViewTextBoxColumn, bevMfrDataGridViewTextBoxColumn, sizeInOzDataGridViewTextBoxColumn, flavorDataGridViewTextBoxColumn, bevTempDataGridViewTextBoxColumn });
            dataGridView1.DataSource = coffeeBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(634, 367);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // coffeeBindingSource
            // 
            coffeeBindingSource.DataSource = typeof(Coffee);
            // 
            // cofRoastDataGridViewTextBoxColumn
            // 
            cofRoastDataGridViewTextBoxColumn.DataPropertyName = "CofRoast";
            cofRoastDataGridViewTextBoxColumn.HeaderText = "CofRoast";
            cofRoastDataGridViewTextBoxColumn.MinimumWidth = 6;
            cofRoastDataGridViewTextBoxColumn.Name = "cofRoastDataGridViewTextBoxColumn";
            cofRoastDataGridViewTextBoxColumn.Width = 125;
            // 
            // isDecafDataGridViewCheckBoxColumn
            // 
            isDecafDataGridViewCheckBoxColumn.DataPropertyName = "isDecaf";
            isDecafDataGridViewCheckBoxColumn.HeaderText = "isDecaf";
            isDecafDataGridViewCheckBoxColumn.MinimumWidth = 6;
            isDecafDataGridViewCheckBoxColumn.Name = "isDecafDataGridViewCheckBoxColumn";
            isDecafDataGridViewCheckBoxColumn.Width = 125;
            // 
            // typeOfDrinkDataGridViewTextBoxColumn
            // 
            typeOfDrinkDataGridViewTextBoxColumn.DataPropertyName = "TypeOfDrink";
            typeOfDrinkDataGridViewTextBoxColumn.HeaderText = "TypeOfDrink";
            typeOfDrinkDataGridViewTextBoxColumn.MinimumWidth = 6;
            typeOfDrinkDataGridViewTextBoxColumn.Name = "typeOfDrinkDataGridViewTextBoxColumn";
            typeOfDrinkDataGridViewTextBoxColumn.Width = 125;
            // 
            // bevIDDataGridViewTextBoxColumn
            // 
            bevIDDataGridViewTextBoxColumn.DataPropertyName = "BevID";
            bevIDDataGridViewTextBoxColumn.HeaderText = "BevID";
            bevIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            bevIDDataGridViewTextBoxColumn.Name = "bevIDDataGridViewTextBoxColumn";
            bevIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // bevNameDataGridViewTextBoxColumn
            // 
            bevNameDataGridViewTextBoxColumn.DataPropertyName = "BevName";
            bevNameDataGridViewTextBoxColumn.HeaderText = "BevName";
            bevNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            bevNameDataGridViewTextBoxColumn.Name = "bevNameDataGridViewTextBoxColumn";
            bevNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // expDateDataGridViewTextBoxColumn
            // 
            expDateDataGridViewTextBoxColumn.DataPropertyName = "ExpDate";
            expDateDataGridViewTextBoxColumn.HeaderText = "ExpDate";
            expDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            expDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // bevContainerDataGridViewTextBoxColumn
            // 
            bevContainerDataGridViewTextBoxColumn.DataPropertyName = "BevContainer";
            bevContainerDataGridViewTextBoxColumn.HeaderText = "BevContainer";
            bevContainerDataGridViewTextBoxColumn.MinimumWidth = 6;
            bevContainerDataGridViewTextBoxColumn.Name = "bevContainerDataGridViewTextBoxColumn";
            bevContainerDataGridViewTextBoxColumn.Width = 125;
            // 
            // bevMfrDataGridViewTextBoxColumn
            // 
            bevMfrDataGridViewTextBoxColumn.DataPropertyName = "BevMfr";
            bevMfrDataGridViewTextBoxColumn.HeaderText = "BevMfr";
            bevMfrDataGridViewTextBoxColumn.MinimumWidth = 6;
            bevMfrDataGridViewTextBoxColumn.Name = "bevMfrDataGridViewTextBoxColumn";
            bevMfrDataGridViewTextBoxColumn.Width = 125;
            // 
            // sizeInOzDataGridViewTextBoxColumn
            // 
            sizeInOzDataGridViewTextBoxColumn.DataPropertyName = "SizeInOz";
            sizeInOzDataGridViewTextBoxColumn.HeaderText = "SizeInOz";
            sizeInOzDataGridViewTextBoxColumn.MinimumWidth = 6;
            sizeInOzDataGridViewTextBoxColumn.Name = "sizeInOzDataGridViewTextBoxColumn";
            sizeInOzDataGridViewTextBoxColumn.Width = 125;
            // 
            // flavorDataGridViewTextBoxColumn
            // 
            flavorDataGridViewTextBoxColumn.DataPropertyName = "Flavor";
            flavorDataGridViewTextBoxColumn.HeaderText = "Flavor";
            flavorDataGridViewTextBoxColumn.MinimumWidth = 6;
            flavorDataGridViewTextBoxColumn.Name = "flavorDataGridViewTextBoxColumn";
            flavorDataGridViewTextBoxColumn.Width = 125;
            // 
            // bevTempDataGridViewTextBoxColumn
            // 
            bevTempDataGridViewTextBoxColumn.DataPropertyName = "BevTemp";
            bevTempDataGridViewTextBoxColumn.HeaderText = "BevTemp";
            bevTempDataGridViewTextBoxColumn.MinimumWidth = 6;
            bevTempDataGridViewTextBoxColumn.Name = "bevTempDataGridViewTextBoxColumn";
            bevTempDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 536);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)coffeeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private DataGridViewTextBoxColumn cofRoastDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isDecafDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn typeOfDrinkDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bevIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bevNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bevContainerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bevMfrDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sizeInOzDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn flavorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bevTempDataGridViewTextBoxColumn;
        private BindingSource coffeeBindingSource;
    }
}
