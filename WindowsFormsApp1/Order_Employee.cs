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
    public partial class Order_Employee : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;
        public Order_Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "")
            {
                cmd = new SqlCommand("  insert into restaurant_schema.ORDER_DATA (MEALS_ID , ORDER_STATUS) values('"+textBox1.Text+"' , '"+comboBox1.Text+"')", conn);
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

        private void button5_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Order_Employee_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard_Employee back = new Dashboard_Employee();
            back.Show();
            this.Hide();
        }
    }
}
