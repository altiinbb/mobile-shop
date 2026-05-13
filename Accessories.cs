using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mobilshopp
{
    public partial class Accessories : Form
    {
        public Accessories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\altin\OneDrive\Dokumentet\Mobilshopp.mdf;Integrated Security = True; Connect Timeout = 30");
        private void acce()
        {
            Con.Open();
            String query = "select * from Accessorie";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            advg.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void Accessories_Load(object sender, EventArgs e)
        {
            acce();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if (aid.Text == "")
            {
                MessageBox.Show("Enter phone to delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Accessorie where aid=" + aid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Deleted");
                    Con.Close();
                    acce();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void advg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            aid.Text = advg.SelectedRows[0].Cells[0].Value.ToString();
            abrand.Text = advg.SelectedRows[0].Cells[1].Value.ToString();
            amodel.Text = advg.SelectedRows[0].Cells[2].Value.ToString();
            astock.Text = advg.SelectedRows[0].Cells[3].Value.ToString();
            aprice.Text = advg.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (aid.Text == "" || abrand.Text == "" || amodel.Text == "" || astock.Text == "" || aprice.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update Accessorie set abrand='" + abrand.Text + "' ,amodel='" + amodel.Text + "',astock=" + astock.Text + ",aprice=" + aprice.Text + " where aid=" + aid.Text + ";";

                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessories Updated");
                    Con.Close();
                    acce();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            aid.Text = "";
            abrand.Text = "";
            amodel.Text = "";
            astock.Text = "";
            aprice.Text = "";
        }

        private void gunaTileButton2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();

        }

        private void gunaButton4_Click_1(object sender, EventArgs e)
        {

            aid.Text = "";
            abrand.Text = "";
            amodel.Text = "";
            astock.Text = "";
            aprice.Text = "";
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            if (aid.Text == "" || abrand.Text == "" || amodel.Text == "" || aprice.Text == "" || astock.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into Accessorie values(" + aid.Text + ",'" + abrand.Text + "','" + amodel.Text + "'," + astock.Text + "," + aprice.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Added Successfully");
                    Con.Close();
                    acce();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
        }
    }
}






