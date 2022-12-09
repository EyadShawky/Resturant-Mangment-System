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
    public partial class Booking_employee : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;
        private void clearData()
        {
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.BOOKING ", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        
        public Booking_employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO restaurant_schema.BOOKING VAlUES ('" + textBox2.Text + "' , '" + textBox3.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Inserted Successfully");
                clearData();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard_Employee back = new Dashboard_Employee();
            back.Show();
            this.Hide();
        }
    }
}
