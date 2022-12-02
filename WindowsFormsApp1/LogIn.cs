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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant_schema.ACCOUNT WHERE USERNAME = '" + textBox1.Text + "' AND PASSWORD = '" + textBox2.Text + "' ", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd); 
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ROLE_NAME"].ToString() == cmbItemValue)
                    {
                        if(comboBox1.SelectedIndex == 0)
                        {
                            Dashboard d1 = new Dashboard();
                            d1.Show();
                            this.Hide();
                        }
                        else
                        {
                            Dashboard_Employee d2 = new Dashboard_Employee();
                            d2.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error while login please check from your data");
            }
        }
    }
}
