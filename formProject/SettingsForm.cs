using System;
using System.Windows.Forms;

namespace formProject
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            TreeBoxProject.Settings settings = TreeBoxProject.Settings.LoadItems();
            textBox1.Text = settings.MinBoxes.ToString();
            textBox2.Text = settings.MaxBoxes.ToString();
            textBox3.Text = settings.ExpireDays.ToString();
            textBox4.Text = settings.DeviationPercentage.ToString();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void NewBox_Click(object sender, EventArgs e)
        {
            string strMinAmount = (textBox1.Text);
            string strMaxAmount = (textBox2.Text);
            string strExpiredDate = (textBox3.Text);
            string strDiff = (textBox4.Text);

            if (int.TryParse(strMinAmount, out int minAmount) && int.TryParse(strMaxAmount, out int maxAmount) && int.TryParse(strExpiredDate, out int expiredDate) && double.TryParse(strDiff, out double diff))
            {
                TreeBoxProject.Settings settings = new TreeBoxProject.Settings(minAmount, maxAmount, expiredDate, diff);
                settings.SaveItems();
                MessageBox.Show("thank you for changing the settings", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("you have an input error", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
