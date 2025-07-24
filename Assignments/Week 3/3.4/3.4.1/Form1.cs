namespace _3._4._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Coffee> coffees = Coffee.GetCoffees();
            coffeeBindingSource.DataSource = coffees;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
