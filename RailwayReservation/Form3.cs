using Oracle.ManagedDataAccess.Client;
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
    public partial class Form3 : Form
    {
        OracleConnection conn;
        public int id { get; set; }
        public string name, gender, email;
        public int age;
        public long phone;

        public Form3()
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
            this.Hide();
            Form4 f4 = new Form4();
            f4.id = id;
            f4.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.id = this.id;
            f5.name =  this.name;
            f5.gender = this.gender;
            f5.age = this.age;
            f5.email = this.email;
            f5.phone = this.phone;
            f5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.id = this.id;
            f9.Show();
        }

        private String getName()
        {
            try
            {
                ConnectDB();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select user_name from u_details where user_id = :u_id";
                cmd.Parameters.Add("u_id", OracleDbType.Varchar2).Value = id;
                object result = cmd.ExecuteScalar();
                cmd.Dispose();
                return result != null ? result.ToString() : "User";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return "";
            }
            finally
            {
                conn.Close();
            }
        }

        private String getGender()
        {
            try
            {
                ConnectDB();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select gender from u_details where user_id = :u_id";
                cmd.Parameters.Add("u_id", OracleDbType.Varchar2).Value = id;
                object result = cmd.ExecuteScalar();
                cmd.Dispose();
                return result != null ? result.ToString() : "NULL";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return "";
            }
            finally
            {
                conn.Close();
            }
        }

        private int getAge()
        {
            try
            {
                ConnectDB();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select age from u_details where user_id = :u_id";
                cmd.Parameters.Add("u_id", OracleDbType.Varchar2).Value = id;
                object result = cmd.ExecuteScalar();
                cmd.Dispose();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        private String getEmail()
        {
            try
            {
                ConnectDB();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select email from u_details where user_id = :u_id";
                cmd.Parameters.Add("u_id", OracleDbType.Varchar2).Value = id;
                object result = cmd.ExecuteScalar();
                cmd.Dispose();
                return result != null ? result.ToString() : "NA";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return "";
            }
            finally
            {
                conn.Close();
            }
        }

        private long getPhone()
        {
            try
            {
                ConnectDB();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select phone from u_details where user_id = :u_id";
                cmd.Parameters.Add("u_id", OracleDbType.Varchar2).Value = id;
                object result = cmd.ExecuteScalar();
                cmd.Dispose();
                return result != null ? Convert.ToInt64(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            name = getName();
            gender = getGender();
            age = getAge();
            email = getEmail();
            phone = getPhone();
            label2.Text = name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.id = this.id;
            f8.Show();
        }
    }
}
