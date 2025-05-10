using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        Process[] processes;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello", "C#", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            processes = null;
            processes = Process.GetProcesses();
            listBox1.Items.Clear();
            foreach (Process process in processes)
            {
                string txt = process.Id.ToString() + " " + process.ProcessName;
                listBox1.Items.Add(txt);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int index = listBox1.SelectedIndex;
            if (index != -1)
            {
                try
                {
                    listBox2.Items.Add(index.ToString());
                    listBox2.Items.Add("Id - " + processes[index].Id);
                    listBox2.Items.Add(processes[index].Handle);
                    listBox2.Items.Add(processes[index].ProcessName);
                    listBox2.Items.Add(processes[index].StartTime);
                    listBox2.Items.Add(processes[index].Threads.Count);
                }
                catch (Exception)
                {

                }
                
            }
        }
    }
}
