using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RailwayReservation
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=10.145.2.231;USER ID=system;PASSWORD=hello");
            conn.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arjun Wakade 220953174\nPranav Hande C.R 220953124\nHarsh Shah 220953224");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectDB();
                OracleCommand command2 = conn.CreateCommand();
                command2.CommandText = "select count(*) from login where user_id = :u_id and password = :u_pw";
                command2.Parameters.Add("u_id", OracleDbType.Varchar2).Value = Convert.ToInt32(textBox1.Text);
                command2.Parameters.Add("u_pw", OracleDbType.Varchar2).Value = textBox2.Text;
                object result = command2.ExecuteScalar();
                int count = Convert.ToInt32(result.ToString());
                if (result != null && count > 0)
                {
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.id = Convert.ToInt32(textBox1.Text);
                    f3.Show();
                    command2.Dispose();
                }
                else
                    MessageBox.Show("Wrong username or password!");
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

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.Show();
        }
    }
}
