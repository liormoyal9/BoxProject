using ClassLibrary;
using System;
using System.Windows.Forms;
using TreeBoxProject;

namespace formProject
{
    public partial class NewBox : Form
    {
        public NewBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strHeight = (textBox1.Text);
            string strWidth = (textBox2.Text);
            string strAmount = (textBox3.Text);
            if (double.TryParse(strWidth, out double width) && double.TryParse(strHeight, out double height) && int.TryParse(strAmount, out int amount))
            {
                Manager.Insert(new Box(width, height, amount));
                FileManagement.SaveItems(Manager.root);
                MessageBox.Show("thank you for adding a new box", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("you have an input error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewBox_Load(object sender, EventArgs e)
        {

        }
    }
}
