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
    public partial class Table : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;
        public Table()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO restaurant_schema.TABLE_DATA VAlUES ('" + textBox2.Text + "' , '" + textBox1.Text + "' )", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Inserted Successfully");
                clearData();
                DisplayData();
            }
        }

        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.TABLE_DATA ", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void clearData()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                cmd = new SqlCommand("UPDATE restaurant_schema.TABLE_DATA SET NUMBER_OF_PEOPLE = '" + textBox1.Text + "' WHERE ID = '" + textBox2.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Updates Successfully");
                DisplayData();
                clearData();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
                cmd = new SqlCommand("DELETE restaurant_schema.TABLE_DATA WHERE ID = '" + textBox2.Text + "' ", conn);
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
                cmd = new SqlCommand("SELECT * FROM restaurant_schema.TABLE_DATA WHERE (ID = '" + textBox5.Text + "')", conn);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox2.Text = reader.GetValue(1).ToString();
                    textBox1.Text = reader.GetValue(2).ToString();
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
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
            this.Hide();
        }
    }
}
