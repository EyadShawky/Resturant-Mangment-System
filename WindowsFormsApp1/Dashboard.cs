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
    public partial class Dashboard : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
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
           
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

       private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Customers cu = new Customers();
            cu.Show();
            this.Hide();
            this.Close();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login back = new Login();
            back.Show();
            this.Hide();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Role ro = new Role();
            ro.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Order order = new Order();  
            order.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Table table = new Table();
            table.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();  
            emp.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Meals meals = new Meals();  
            meals.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Booking booking = new Booking();    
            booking.Show();
            this.Hide();
        }
    }
}


