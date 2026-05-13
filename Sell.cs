using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Mobilshopp
{
    public partial class Sell : Form
    {
        public Sell()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\altin\OneDrive\Dokumentet\Mobilshopp.mdf;Integrated Security = True; Connect Timeout = 30");

        private void phonee()
        {
            Con.Open();
            String query = "select Sbrand,Smodel,Sprice from Phones";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            SDVG.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void accee()
        {
            Con.Open();
            String query = "select abrand,amodel,aprice from Accessorie";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            advg.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void Sell_Load(object sender, EventArgs e)
        {
            phonee();
            accee();
        }

        private void SDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            product.Text = SDVG.SelectedRows[0].Cells[0].Value.ToString() + SDVG.SelectedRows[0].Cells[1].Value.ToString();
            price.Text = SDVG.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void advg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            product.Text = advg.SelectedRows[0].Cells[0].Value.ToString() + SDVG.SelectedRows[0].Cells[1].Value.ToString();
            price.Text = advg.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Mobilshop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

        }

        private void gunaTileButton2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();

        }

        private void Selld_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            int n = 0, Grdtotal = 0;
            if (quantity.Text == "" || price.Text == "")
            {
                MessageBox.Show("Missing information");

            }
            else
            {
                int total = Convert.ToInt32(quantity.Text) * Convert.ToInt32(price.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(Selld);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = product.Text;
                newRow.Cells[2].Value = price.Text;
                newRow.Cells[3].Value = quantity.Text;
                newRow.Cells[4].Value = total;
                Selld.Rows.Add(newRow);
                n++;
                Grdtotal = Grdtotal + total;
                Amount.Text = "" + Grdtotal;
            }
        }

        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}