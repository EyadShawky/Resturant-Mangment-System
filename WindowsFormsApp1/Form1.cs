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
    public partial class Form1 : Form
    {
        
        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!= "" && textBox2.Text != "")
            {
                cmd = new SqlCommand("insert into restaurant_schema.CUSTOMERS values('" + textBox2.Text + "', '" + textBox1.Text + "', '" + textBox3.Text + "')",conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Inserted succes");
                clearData();
                displayData();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                cmd = new SqlCommand("UPDATE restaurant_schema.CUSTOMERS SET FIRST_NAME = '" + textBox2.Text + "' , LAST_NAME= '" + textBox1.Text + "' , PHONE_NO='" + textBox3.Text + "' WHERE ID = '" + textBox4.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Updated Succes");
                clearData();
                displayData();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                cmd = new SqlCommand("  DELETE FROM restaurant_schema.CUSTOMERS WHERE ID ='"+ textBox4.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record Deleted Succes");
                displayData();
                clearData();
            }
        }

        private void clearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        public void displayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapter = new SqlDataAdapter("SELECT * FROM restaurant_schema.CUSTOMERS ", conn);
            adapter.Fill(dt); 
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
