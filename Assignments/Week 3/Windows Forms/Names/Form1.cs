namespace Names
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtNames.Text) && !lstNames.Items.Contains(txtNames.Text))
                lstNames.Items.Add(txtNames.Text);
        }
    }
}
