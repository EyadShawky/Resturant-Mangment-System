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
    public partial class Employee : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;
        public Employee()
        {
            InitializeComponent();
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
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.EMPLOYEE ", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO restaurant_schema.Employee (FIRST_NAME , LAST_NAME , Email , PHONE , SALARY , BIRTH_DATE , MANGER_ID , SEX , DEPARTMENT_ID) VAlUES ( '" + textBox2.Text + "' ,'" + textBox3.Text + "',  '" + textBox4.Text + "', '" + textBox5.Text + "','" + textBox10.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + comboBox1.Text + "','" + textBox6.Text + "')", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Recorde Inserted Successfully");
            DisplayData();
            clearData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant_schema.EMPLOYEE WHERE (ID = '" + textBox11.Text + "')", conn);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader.GetValue(0).ToString();
                    textBox2.Text = reader.GetValue(1).ToString();
                    textBox3.Text = reader.GetValue(2).ToString();
                    textBox4.Text = reader.GetValue(3).ToString();
                    textBox5.Text = reader.GetValue(4).ToString();
                    textBox10.Text = reader.GetValue(7).ToString();
                    textBox9.Text = reader.GetValue(6).ToString();
                    textBox8.Text = reader.GetValue(9).ToString();
                    comboBox1.Text = reader.GetValue(5).ToString();
                    textBox6.Text = reader.GetValue(8).ToString();
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
            if (textBox8.Text != "" && textBox6.Text != "" && textBox1.Text != "")
            {
                SqlCommand cmd = new SqlCommand("UPDATE restaurant_schema.EMPLOYEE SET FIRST_NAME = '" + textBox2.Text + "' ,LAST_NAME = '" + textBox3.Text + "', Email = '" + textBox4.Text + "',PHONE= '" + textBox5.Text + "',SEX = '" + comboBox1.Text + "', BIRTH_DATE ='" + textBox9.Text + "',SALARY= '" + textBox10.Text + "',DEPARTMENT_ID='" + textBox6.Text + "',MANGER_ID ='" + textBox8.Text + "' WHERE ID = '" + textBox1.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Updates Successfully");
                DisplayData();
                clearData();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlCommand cmd = new SqlCommand("DELETE restaurant_schema.EMPLOYEE WHERE ID = '" + textBox1.Text + "' ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorde Deleted Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
