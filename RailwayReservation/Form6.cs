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
    public partial class Form6 : Form
    {
        OracleConnection conn;

        public int id { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public string journey_date { get; set; }
        public Form6()
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
            Form3 f3 = new Form3();
            f3.id = id;
            f3.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand command2 = conn.CreateCommand();
            command2.CommandText = "select * from train where train_no in (select train_no from platform where station_id in (select station_id from station where city = :source or city = :destination) and to_char(arr_time, 'YYYY-MM-DD') = :journey_date)";
            command2.Parameters.Add("source", OracleDbType.Varchar2).Value = source;
            command2.Parameters.Add("destination", OracleDbType.Varchar2).Value = destination;
            command2.Parameters.Add("journey_date", OracleDbType.Varchar2).Value = journey_date;
            OracleDataAdapter adapter = new OracleDataAdapter(command2);
            DataTable dataTable = new DataTable();
            try
            {
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
