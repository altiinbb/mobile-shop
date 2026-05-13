using System;
using System.Windows.Forms;

namespace Mobilshopp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void SP_Click(object sender, EventArgs e)
        {
            Phones ph = new Phones();
            ph.Show();
            this.Hide();
        }

        private void Acc_Click(object sender, EventArgs e)
        {
            Accessories acc = new Accessories();
            acc.Show();
            this.Hide();

        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {
            Sell s = new Sell();
            s.Show();
            this.Hide();


        }

        private void gunaTileButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaTileButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
