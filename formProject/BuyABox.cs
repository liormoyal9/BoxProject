using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TreeBoxProject;

namespace formProject
{
    public partial class BuyABox : Form
    {
        public BuyABox()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewBox_Click(object sender, EventArgs e)
        {
            string strWidth = (textBox1.Text);
            string strHeight = (textBox2.Text);
            string strAmount = (textBox3.Text);

            if (double.TryParse(strWidth, out double width) && double.TryParse(strHeight, out double height) && int.TryParse(strAmount, out int amount))
            {
                List<Box> boxes = Manager.FindMostSuitableBoxes(width, height, amount);
                FileManagement.SaveItems(Manager.root);

                if (boxes != null && boxes.Count > 0)
                {
                    List<Box> boxes2 = Manager.DisplayBoxesWithoutDuplicates(boxes);
                    string strBoxes = "";
                    foreach (Box box in boxes2)
                    {
                        strBoxes += box.ToString();
                    }
                    Settings settings = Settings.LoadItems();
                    DialogResult result = MessageBox.Show($"do you want to buy this box? \n{strBoxes}", "confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("we got your order!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (Box box in boxes2)
                        {
                            if (box.BoxCount < settings.MinBoxes)
                            {
                                MessageBox.Show("your stock is low!", "notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (box.BoxCount == 0)
                            {
                                MessageBox.Show("the box is out of stock!", "notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        foreach (Box box in boxes)
                        {
                            Manager.Insert(new Box(box.Width, box.Height, 1));
                        }
                        MessageBox.Show("your boxes are back in stock!", "notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    FileManagement.SaveItems(Manager.root);
                }
                else
                {
                    MessageBox.Show("we don't have a box that will fit you. we are sorry", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("you have an input error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void BuyABox_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
