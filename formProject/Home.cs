using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeBoxProject;

namespace formProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            pictureBoxBackground.Image = System.Drawing.Image.FromFile("C:\\library\\box.jpg");
            Manager.root = FileManagement.LoadItems();
            FileManagement.DeleteItems();
        }

        private void headLine_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuyABox buyABox = new BuyABox();
            this.Hide();
            buyABox.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewBox newBox = new NewBox();
            newBox.Show();
        }

        private void pictureBoxBackground_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowAllBoxes showAllBoxes = new ShowAllBoxes();
            showAllBoxes.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingsForm settings = new SettingsForm();
            settings.Show();
        }
    }
}
