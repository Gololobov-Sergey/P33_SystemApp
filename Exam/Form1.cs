namespace Exam
{
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox1.Checked;
            button1.Enabled = checkBox1.Checked;
            textBox1.Enabled = !checkBox1.Checked;
            StartEnable();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Text files | *.txt|All files | *.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                textBox2.Text = path;
                StartEnable();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
                StartEnable();
            }
        }


        void StartEnable()
        {
            button3.Enabled = ((textBox2.Text != "" || textBox1.Text != "") && textBox3.Text != "") ? true : false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            StartEnable();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            StartEnable();
        }
    }
}
