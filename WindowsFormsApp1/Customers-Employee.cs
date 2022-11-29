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
    public partial class Customers_Employee : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;
        public Customers_Employee()
        {
            InitializeComponent();
        }

        private void clearData()
        {
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }


       

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard_Employee dbe = new Dashboard_Employee();
            dbe.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO restaurant_schema.CUSTOMERS VAlUES ('" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Inserted Successfully");
                clearData();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LogIn back = new LogIn();
            back.Show();
            this.Hide();
        }
    }
}
