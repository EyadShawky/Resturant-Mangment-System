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
    public partial class Department : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;

        public Department()
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
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.DEPARTMENT ", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO restaurant_schema.DEPARTMENT (DEPARTMENT_DESCRIPTION , MANGER_ID , DEPARTMENT_NAME , POSITION) VAlUES ('" + textBox1.Text + "' , '" + textBox3.Text + "' , '" + textBox6.Text + "' , '" + textBox4.Text + "')", conn);
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                cmd = new SqlCommand("UPDATE restaurant_schema.DEPARTMENT SET DEPARTMENT_NAME = '" + textBox6.Text + "' , DEPARTMENT_DESCRIPTION = '"+ textBox1.Text + "' , POSITION = '"+ textBox4.Text + "' , MANGER_ID='"+ textBox3.Text + "'   WHERE ID = '" + textBox2.Text + "'" , conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Updates Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                cmd = new SqlCommand("DELETE restaurant_schema.DEPARTMENT WHERE ID = '" + textBox2.Text + "' ", conn);
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
                cmd = new SqlCommand("SELECT * FROM restaurant_schema.DEPARTMENT WHERE (ID = '" + textBox5.Text + "')", conn);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader.GetValue(0).ToString();
                    textBox1.Text = reader.GetValue(1).ToString();
                    textBox3.Text = reader.GetValue(2).ToString();
                    textBox6.Text = reader.GetValue(3).ToString();
                    textBox4.Text = reader.GetValue(4).ToString();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
