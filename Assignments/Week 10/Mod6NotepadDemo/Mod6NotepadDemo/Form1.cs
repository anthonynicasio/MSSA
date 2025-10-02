namespace Mod6NotepadDemo
{
    public partial class Form1 : Form
    {
        string filepath;
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtArea.Clear();
            txtArea.Focus();
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text Files|*.txt";
            openFile.Title = "Open a Text File";
            openFile.ShowDialog();
            if (openFile.FileName != string.Empty)
            {
                filepath = openFile.FileName;
                // if(File.Exists(filepath))
                txtArea.Text = File.ReadAllText(filepath);
            }
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(filepath))
            {
                File.WriteAllText(filepath, txtArea.Text);
            }
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Text File| *.txt";
                saveFile.Title = "Save a Text File";
                saveFile.ShowDialog();
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    filepath = saveFile.FileName;
                    Stream stream = saveFile.OpenFile();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(txtArea.Text);
                    writer.Close();
                    stream.Close();
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files|*.txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                filepath = saveFile.FileName;
                Stream stream = saveFile.OpenFile();
                StreamWriter writer = new StreamWriter(stream);
                writer.WriteLine(txtArea.Text);
                writer.Close();
                stream.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtArea.SelectionColor = colorDialog.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                txtArea.SelectionFont = fontDialog.Font;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtArea.SelectedText);
            txtArea.SelectedText = string.Empty;
        }
    }
}
