
using Microsoft.Data.SqlClient;

using System.Data;
using System.Web;
using System.Windows.Forms;

namespace Module2
{
    public partial class Form1 : Form
    {
        DataTable Partners = new DataTable();
        DataTable PartnerProduct = new DataTable();
        DataTable Products = new DataTable();
        DataTable MaterialType = new DataTable();
        DataTable ProductType = new DataTable();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Master_floor;Trusted_Connection=True;";
            string conn = "Server=DEFL\\MSSQLSERVER1;Database=Master_floor;Trusted_Connection=True;Encrypt=false";
            using (var connection = new SqlConnection(conn))
            {
                connection.Open();

                using (var command = new SqlCommand("select * from partner", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(Partners);

                using (var command = new SqlCommand("select * from Partner_product", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(PartnerProduct);

                using (var command = new SqlCommand("select * from Products", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(Products);

                using (var command = new SqlCommand("select * from Material_type_import", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(MaterialType);

                using (var command = new SqlCommand("select * from Product_type", connection))
                using (var adapter = new SqlDataAdapter(command))
                    adapter.Fill(ProductType);
            }


            for (int i = 0; i < Partners.Rows.Count; i++)
            {
                int CountSale = 0;
                for (int j = 0; j < PartnerProduct.Rows.Count; j++)
                {
                    string Partner = PartnerProduct.Rows[j][1].ToString();
                    string Deal = Partners.Rows[i][1].ToString();
                    if (Partner == Deal)
                    {
                        CountSale += int.Parse(PartnerProduct.Rows[j][2].ToString());
                    }
                }
                int discount = 0;
                if (CountSale < 10000)
                    discount = 0;
                else if (10000 <= CountSale && CountSale < 50000) discount = 5;
                else if (50000 <= CountSale && CountSale < 300000) discount = 10;
                else if (300000 < CountSale) discount = 15;
                Label label = new Label
                {
                    Width = 350,
                    BorderStyle = BorderStyle.FixedSingle,
                    Height = 100,
                    Margin = new Padding(10, 10, 0, 0),
                    Tag = Partners.Rows[i]
                };
                label.Text = $"{Partners.Rows[i][0]} | {Partners.Rows[i][1]}         {discount}%\n{Partners.Rows[i][2]}\n{Partners.Rows[i][4]}\nРейтинг: {Partners.Rows[i][7]}";
                label.Click += (sender, e) =>
                {
                    this.Hide();
                    new Form2((DataRow)((Label)sender).Tag).Show();
                };
                flowLayoutPanel1.Controls.Add(label);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }
    }
}
