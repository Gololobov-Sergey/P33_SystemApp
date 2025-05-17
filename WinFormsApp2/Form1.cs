namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        List<int> numbers = new List<int>();

        Thread thread1;
        Thread thread2;
        Thread thread3;

        public Form1()
        {
            InitializeComponent();
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                numbers.Add(random.Next(1, 100));
            }
        }

        private void CalcSum()
        {
            int sum = numbers.Sum();
            BeginInvoke(new Action(() =>
            {
                textBox1.Text += $"Sum: {sum}\r\n";
            }));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(() => CalcSum());
            thread1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(() => CalcAvg());
            thread2.Start();
        }

        private void CalcAvg()
        {
            BeginInvoke(new Action(() =>
            {
                textBox1.Text += $"Avg: {numbers.Average()}\r\n";
            }));
        }
    }
}
