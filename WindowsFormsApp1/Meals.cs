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
    public partial class Meals : Form
    {

        SqlConnection con = new SqlConnection("Data Source=EYAD\\SQLEXPRESS;Initial Catalog=Restaurant_DB;Integrated Security=True;");
        SqlCommand cmd;
        private SqlDataAdapter adapt;
        public Meals()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != "" && textBox2.Text != "" && textBox5.Text != "")
            {
                cmd = new SqlCommand("INSERT INTO restaurant_schema.MEALS (PRICE , MEALS_INGREDIENTS, MEALS_NAME) VAlUES ('" + "$"+textBox3.Text + "' , '" + textBox2.Text + "' , '" + textBox5.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Recorde Inserted Successfully");
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
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM restaurant_schema.MEALS ", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                cmd = new SqlCommand("UPDATE restaurant_schema.MEALS SET PRICE ='" + "$"+textBox3.Text + "' , MEALS_INGREDIENTS ='" + textBox4.Text + "', MEALS_NAME ='" + textBox2.Text + "'  where ID ='" + textBox1.Text + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Recorde Updated Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("DELETE restaurant_schema.MEALS WHERE ID ='" + textBox1.Text + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Recorde Deleted Successfully");
                DisplayData();
                clearData();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant_schema.MEALS WHERE (ID = '" + textBox4.Text + "')", con);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader.GetValue(0).ToString();
                    textBox3.Text = reader.GetValue(1).ToString();
                    textBox2.Text = reader.GetValue(2).ToString();
                    textBox5.Text = reader.GetValue(3).ToString();
                }
                con.Close();
                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in searching" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
            this.Hide();
        }
    }
}
