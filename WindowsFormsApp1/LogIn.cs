using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class LogIn : Form
    {


        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username == "Admin" && password == "1234")
            {
                Dashboard db = new Dashboard();
                db.Show();
                this.Hide();
            }
            else if (username == "Employee" && password == "1234")
            {
                Dashboard_Employee dbee = new Dashboard_Employee();
                dbee.Show();
                this.Hide();
            }
            else if (username == "" || password == "")
            {
                MessageBox.Show("Please enter Username && password");
            }
            else
            {
                MessageBox.Show("Please enter a valid data");
            }
            clearData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void clearData()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
        }
    }
}
