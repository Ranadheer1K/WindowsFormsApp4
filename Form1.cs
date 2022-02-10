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

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            string name = textBox1.Text;
            string pwd = textBox2.Text;

            try
            {
                con = new SqlConnection("data source=.; database = Test; User ID=ranadheer; Password=ravan2451");
                
                SqlCommand cmd = new SqlCommand("select * from login",con);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                //MessageBox.Show(reader.Read().ToString());

                /*if (reader.Read())
                {
                    MessageBox.Show("Logged in");
                } 
                else
                {
                    MessageBox.Show("Invalid username or password");
                }*/

                bool isRecordExist = false;
                while (reader.Read())
                {
                    if (textBox1.Text == reader["username"].ToString() && textBox2.Text == reader["password"].ToString())
                    {
                        isRecordExist = true;
                        break;
                    }

                }

                if (isRecordExist)
                {
                    MessageBox.Show("User is Logged in successfully !! ");
                }
                else
                {
                    MessageBox.Show("User is not Logged in!! ");
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.testDataSet.Login);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }
    }
}
