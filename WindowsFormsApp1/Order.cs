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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Order : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;
        public Order()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && textBox6.Text != "")
            {
                cmd = new SqlCommand(" INSERT INTO restaurant_schema.ORDER_DATA (MEALS_ID , ORDER_STATUS , EMPLOYEE_ID , CUSTOMER_ID) VAlUES ('" + textBox1.Text + "' , '" + comboBox1.Text + "' , '" + textBox6.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Inserted Successfully");
                DisplayData();
                clearData();
            }
        }

        private void clearData()
        {
            textBox1.Text = " ";
            comboBox1.Text = " ";
        }

        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.ORDER_DATA ", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                cmd = new SqlCommand("UPDATE restaurant_schema.ORDER_DATA SET MEALS_ID = '" + textBox1.Text + "' , ORDER_STATUS='" + comboBox1.Text + "' WHERE ID = '" + textBox2.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Updates Successfully");
                DisplayData();
                clearData();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                cmd = new SqlCommand("DELETE restaurant_schema.ORDER_DATA WHERE ID = '" + textBox2.Text + "' ", conn);
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
                cmd = new SqlCommand("SELECT * FROM restaurant_schema.ORDER_DATA WHERE (ID = '" + textBox5.Text + "')", conn);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader.GetValue(0).ToString();
                    textBox1.Text = reader.GetValue(1).ToString();
                    comboBox1.Text = reader.GetValue(3).ToString();
                    textBox6.Text = reader.GetValue(2).ToString();

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

        private void Order_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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
