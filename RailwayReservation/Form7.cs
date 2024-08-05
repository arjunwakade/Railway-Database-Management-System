using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace RailwayReservation
{
    public partial class Form7 : Form
    {
        OracleConnection conn;

        public Form7()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=10.145.2.231;USER ID=system;PASSWORD=hello");
            conn.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Equals(textBox3.Text))
                {
                    ConnectDB();
                    OracleCommand command2 = conn.CreateCommand();
                    command2.CommandType = CommandType.Text;
                    command2.CommandText = "update login set password = :u_pw where user_id = :u_id";
                    command2.Parameters.Add("u_pw", OracleDbType.Varchar2).Value = textBox2.Text;
                    command2.Parameters.Add("u_id", OracleDbType.Varchar2).Value = Convert.ToInt32(textBox1.Text);
                    int rowsAffected = command2.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        this.Hide();
                        Form1 f1 = new Form1();
                        f1.Show();
                        command2.Dispose();
                    }
                    else
                        MessageBox.Show("User does not exist!");
                }
                else
                    MessageBox.Show("Passwords don't match!");
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
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
