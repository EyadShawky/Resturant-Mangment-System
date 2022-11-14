using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Customers : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;

        public Customers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO restaurant_schema.CUSTOMERS VAlUES ('"+textBox2.Text+"' , '"+textBox3.Text+"' , '"+textBox4.Text+"')" , conn );
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Inserted Successfully");
                DisplayData();
                clearData();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                cmd = new SqlCommand("UPDATE restaurant_schema.CUSTOMERS SET FIRST_NAME = '" + textBox2.Text + "' , LAST_NAME = '" + textBox3.Text + "' , PHONE_NO='"+ textBox4.Text + "' WHERE ID = '" + textBox1.Text + "' ", conn);
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
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("DELETE restaurant_schema.CUSTOMERS WHERE ID = '" + textBox1.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Deleted Successfully");
                DisplayData();
                clearData();
            }
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
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.CUSTOMERS ", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
