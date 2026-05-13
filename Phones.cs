using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Mobilshopp
{
    public partial class Phones : Form
    {
        public Phones()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\altin\OneDrive\Dokumentet\Mobilshopp.mdf;Integrated Security = True; Connect Timeout = 30");

        private void phonee()
        {
            Con.Open();
            String query = "select * from Phones";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            SDVG.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Phones_Load(object sender, EventArgs e)
        {
            phonee();
        }



        private void gunaButton3_Click(object sender, EventArgs e)
        {
            if (PidTb.Text == "")
            {
                MessageBox.Show("Enter phone to delete");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from Phones where Smartid=" + PidTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Deleted");
                    Con.Close();
                    phonee();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void SDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PidTb.Text = SDVG.SelectedRows[0].Cells[0].Value.ToString();
            PbrandTb.Text = SDVG.SelectedRows[0].Cells[1].Value.ToString();
            PmodelTb.Text = SDVG.SelectedRows[0].Cells[2].Value.ToString();
            PstockTb.Text = SDVG.SelectedRows[0].Cells[3].Value.ToString();
            PpriceTb.Text = SDVG.SelectedRows[0].Cells[4].Value.ToString();
            Ramc.SelectedItem = SDVG.SelectedRows[0].Cells[5].Value.ToString();
            Romc.SelectedItem = SDVG.SelectedRows[0].Cells[6].Value.ToString();
            Cam.Text = SDVG.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (PidTb.Text == "" || PbrandTb.Text == "" || PmodelTb.Text == "" || PstockTb.Text == "" || PpriceTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update Phones set Sbrand='" + PbrandTb.Text + "' ,Smodel='" + PmodelTb.Text + "',Sstock=" + PstockTb.Text + ",Sprice=" + PpriceTb.Text + " where Smartid=" + PidTb.Text + ";";

                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessories Updated");
                    Con.Close();
                    phonee();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            PidTb.Text = "";
            PbrandTb.Text = "";
            PmodelTb.Text = "";
            PstockTb.Text = "";
            PpriceTb.Text = "";
            Cam.Text = "";
        }

        private void gunaTileButton2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();

        }

        private void gunaButton4_Click_1(object sender, EventArgs e)
        {
            PidTb.Text = "";
            PbrandTb.Text = "";
            PmodelTb.Text = "";
            PstockTb.Text = "";
            PpriceTb.Text = "";
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            if (PidTb.Text == "" || PmodelTb.Text == "" || PpriceTb.Text == "" || PstockTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into Phones values(" + PidTb.Text + ",'" + PbrandTb.Text + "','" + PmodelTb.Text + "'," + PstockTb.Text + "," + PpriceTb.Text + "," + Ramc.SelectedItem.ToString() + "," + Romc.SelectedItem.ToString() + "," + Cam.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    phonee();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
