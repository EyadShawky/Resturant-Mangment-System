using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Dashboard_Employee : Form
    {
        public Dashboard_Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Customers_Employee ce = new Customers_Employee();
            ce.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Order_Employee order = new Order_Employee();
            order.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Table_Employee table = new Table_Employee();    
            table.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Booking_employee booking = new Booking_employee();    
            booking.Show();
            this.Hide(); 
        }
    }
}
