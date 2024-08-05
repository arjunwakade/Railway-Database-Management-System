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
    public partial class Form2 : Form
    {
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=10.145.2.231;USER ID=system;PASSWORD=hello");
            conn.Open();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (textBox7.Text.Equals(textBox8.Text) == true)
                {
                    ConnectDB();
                    OracleCommand command2 = conn.CreateCommand();
                    command2.CommandText = "insert into login values (:u_id, :u_pw)";
                    command2.Parameters.Add("u_id", OracleDbType.Varchar2).Value = Convert.ToInt32(textBox2.Text);
                    command2.Parameters.Add("u_pw", OracleDbType.Varchar2).Value = textBox7.Text;
                    int rowsAffected2 = command2.ExecuteNonQuery();
                    if (rowsAffected2 > 0)
                        MessageBox.Show("Data inserted in login table sucessfully!");
                    else
                        MessageBox.Show("Error inserting data!");
                    command2.Dispose();
                    using (OracleCommand command3 = conn.CreateCommand())
                    {
                        command3.CommandText = "insert into u_details values (:u_id, :u_name, :u_gender, :u_age, :u_email, :u_phone)";
                        command3.Parameters.Add("u_id", OracleDbType.Varchar2).Value = Convert.ToInt32(textBox2.Text);
                        command3.Parameters.Add("u_name", OracleDbType.Varchar2).Value = textBox1.Text;
                        command3.Parameters.Add("u_gender", OracleDbType.Varchar2).Value = textBox3.Text;
                        command3.Parameters.Add("u_age", OracleDbType.Varchar2).Value = Convert.ToInt32(textBox4.Text);
                        command3.Parameters.Add("u_email", OracleDbType.Varchar2).Value = textBox5.Text;
                        command3.Parameters.Add("u_phone", OracleDbType.Varchar2).Value = Convert.ToInt64(textBox6.Text);
                        int rowsAffected3 = command3.ExecuteNonQuery();
                        if (rowsAffected3 > 0)
                        {
                            MessageBox.Show("Data inserted in u_details sucessfully!");
                            this.Hide();
                            Form1 f1 = new Form1();
                            f1.Show();
                        }
                        else
                            MessageBox.Show("Error inserting data!");
                        command3.Dispose();
                    }
                }
                else
                    MessageBox.Show("Passwords not matching!");
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
