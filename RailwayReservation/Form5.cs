using Microsoft.VisualBasic.ApplicationServices;
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
using Oracle.ManagedDataAccess.Client;

namespace RailwayReservation
{
    public partial class Form5 : Form
    {
        OracleConnection conn;
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public long phone { get; set; }

        public Form5()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=10.145.2.231;USER ID=system;PASSWORD=hello");
            conn.Open();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.id = id;
            f3.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label7.Text = id.ToString();
            label9.Text = name;
            label10.Text = gender;
            textBox1.Text = age.ToString();
            textBox2.Text = email;
            textBox3.Text = phone.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectDB();
                OracleCommand command2 = conn.CreateCommand();
                command2.CommandText = "update u_details set age = :u_age, email = :u_email, phone = :u_phone where user_id = :u_id";
                command2.Parameters.Add("u_age", OracleDbType.Varchar2).Value = Convert.ToInt32(textBox1.Text);
                command2.Parameters.Add("u_email", OracleDbType.Varchar2).Value = textBox2.Text;
                command2.Parameters.Add("u_phone", OracleDbType.Varchar2).Value = Convert.ToInt64(textBox3.Text);
                command2.Parameters.Add("u_id", OracleDbType.Varchar2).Value = id;
                int rowsAffected = command2.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Profile updated!");
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.id = id;
                    f3.name = name;
                    f3.gender = gender;
                    f3.age = Convert.ToInt32(textBox1.Text);
                    f3.email = textBox2.Text;
                    f3.phone = Convert.ToInt64(textBox3.Text);
                    f3.Show();
                    command2.Dispose();
                }
                else
                    MessageBox.Show("Error while updating!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
        }
    }
}