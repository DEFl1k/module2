using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Module2
{
    public partial class Form2 : Form
    {
        static bool isEdit;
        static string Name;
        public Form2(DataRow DataRow)
        {
            InitializeComponent();
            this.CenterToScreen();
            textBox1.Text = DataRow[0].ToString();
            textBox9.Text = DataRow[1].ToString();
            textBox3.Text = DataRow[2].ToString();
            textBox4.Text = DataRow[3].ToString();
            textBox5.Text = DataRow[4].ToString();
            textBox6.Text = DataRow[5].ToString();
            textBox7.Text = DataRow[6].ToString();
            textBox8.Text = DataRow[7].ToString();
            Name = DataRow[1].ToString();
            isEdit = true;
        }

        public Form2()
        {
            InitializeComponent();
            this.CenterToScreen();
            isEdit = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                //string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Master_floor;Trusted_Connection=True;";
                string conn = "Server=DEFL\\MSSQLSERVER1;Database=Master_floor;Trusted_Connection=True;Encrypt=false";
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string sql = "UPDATE partner SET Тип_партнера = @value1, Наименование_партнера = @value2, Директор = @value3, Электронная_почта_партнера = @value4, Телефон_партнера = @value5, Юридический_адрес_партнера = @value6, ИНН = @value7, Рейтинг = @value8 WHERE Наименование_партнера = @name";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@value1", textBox1.Text);
                        command.Parameters.AddWithValue("@value2", textBox9.Text);
                        command.Parameters.AddWithValue("@value3", textBox3.Text);
                        command.Parameters.AddWithValue("@value4", textBox4.Text);
                        command.Parameters.AddWithValue("@value5", textBox5.Text);
                        command.Parameters.AddWithValue("@value6", textBox6.Text);
                        command.Parameters.AddWithValue("@value7", textBox7.Text);
                        command.Parameters.AddWithValue("@value8", textBox8.Text);
                        command.Parameters.AddWithValue("@name", Name);

                        command.ExecuteNonQuery();
                    }

                }
                this.Hide();
                new Form1().Show();
            }
            else
            {
                //string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Master_floor;Trusted_Connection=True;";
                string conn = "Server=DEFL\\MSSQLSERVER1;Database=Master_floor;Trusted_Connection=True;Encrypt=false";
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string sql = "INSERT INTO partner (Тип_партнера, Наименование_партнера, Директор, Электронная_почта_партнера, Телефон_партнера, Юридический_адрес_партнера, ИНН, Рейтинг) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@value1", textBox1.Text);
                        command.Parameters.AddWithValue("@value2", textBox9.Text);
                        command.Parameters.AddWithValue("@value3", textBox3.Text);
                        command.Parameters.AddWithValue("@value4", textBox4.Text);
                        command.Parameters.AddWithValue("@value5", textBox5.Text);
                        command.Parameters.AddWithValue("@value6", textBox6.Text);
                        command.Parameters.AddWithValue("@value7", textBox7.Text);
                        command.Parameters.AddWithValue("@value8", textBox8.Text);
                        command.Parameters.AddWithValue("@name", Name);

                        command.ExecuteNonQuery();
                    }

                }
                this.Hide();
                new Form1().Show();
            }
        }
    }
}
