using System;
using System.Windows.Forms;
using TreeBoxProject;

namespace formProject
{
    public partial class ShowAllBoxes : Form
    {
        public ShowAllBoxes()
        {
            InitializeComponent();
            ListView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ListView()
        {
            foreach (Box b in Manager.GetAllBoxesMainTree(Manager.root))
            {
                ListViewItem listView = new ListViewItem(b.Width.ToString());
                listView.Tag = b;
                listView.SubItems.Add(b.Height.ToString());
                listView.SubItems.Add(b.BoxCount.ToString());
                listView1.Items.Add(listView);
            }
        }

        private void ShowAllBoxes_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
