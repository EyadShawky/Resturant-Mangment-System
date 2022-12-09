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
    public partial class Account : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;
        public Account()
        {
            InitializeComponent();
        }

        private void clearData()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.ACCOUNT ", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO restaurant_schema.ACCOUNT (EMPLOYEE_ID , USERNAME ,  PASSWORD , ROLE_ID , ROLE_NAME) VAlUES ('" + textBox1.Text + "' , '" + textBox3.Text + "' , '" + textBox6.Text + "' , '" + textBox4.Text + "' , '" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Inserted Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                cmd = new SqlCommand("DELETE restaurant_schema.ACCOUNT WHERE ID = '" + textBox2.Text + "' ", conn);
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
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM restaurant_schema.ACCOUNT WHERE (ID = '" + textBox5.Text + "')", conn);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader.GetValue(0).ToString();
                    textBox1.Text = reader.GetValue(3).ToString();
                    textBox3.Text = reader.GetValue(1).ToString();
                    textBox6.Text = reader.GetValue(2).ToString();
                    textBox4.Text = reader.GetValue(4).ToString();
                    comboBox1.Text = reader.GetValue(5).ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                cmd = new SqlCommand("UPDATE restaurant_schema.ACCOUNT SET USERNAME = '" + textBox3.Text + "' , PASSWORD = '" + textBox6.Text + "' , EMPLOYEE_ID = '" + textBox1.Text + "' , ROLE_ID='" + textBox4.Text + "' , ROLE_NAME='" + comboBox1.Text + "'  WHERE ID = '" + textBox2.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Updates Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
            this.Hide();
        }
    }
}
