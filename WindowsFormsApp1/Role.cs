using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Role : Form

    {
        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;

        public Role()
        {
            InitializeComponent();
        }


        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.ROLE ", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void clearData()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
        }





        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO restaurant_schema.ROLE VAlUES ('" + textBox2.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Inserted Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.Text != "")
            {
                cmd = new SqlCommand("UPDATE restaurant_schema.ROLE SET ROLE_NAME = '" + textBox2.Text + "' WHERE ID = '" + textBox1.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Updates Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("DELETE restaurant_schema.ROLE WHERE ID = '" + textBox1.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Deleted Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM restaurant_schema.ROLE WHERE (ID = '" + textBox5.Text + "')", conn);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader.GetValue(0).ToString();
                    textBox2.Text = reader.GetValue(1).ToString();
                }
                conn.Close();
                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in searching" + ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
            this.Hide();
        }
    }
}
