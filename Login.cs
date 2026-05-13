using System;
using System.Windows.Forms;

namespace Mobilshopp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || pw.Text == "")
            {
                MessageBox.Show("Missing info");
            }
            else if
                (user.Text == "admin" && pw.Text == "admin")
            {


                Home h1 = new Home();
                h1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or pw");
            }
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_Show_Hide_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_Show_Hide.Checked)
            {
                pw.UseSystemPasswordChar = false;
            }
            else
            {
                pw.UseSystemPasswordChar = true;


            }

        }
    }
}