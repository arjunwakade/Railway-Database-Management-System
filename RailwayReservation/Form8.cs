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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace RailwayReservation
{
    public partial class Form8 : Form
    {
        public int id { get; set; }

        OracleConnection conn;
        public Form8()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=10.145.2.231;USER ID=system;PASSWORD=hello");
            conn.Open();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand command2 = conn.CreateCommand();
            command2.CommandText = "select * from transaction_history where PNR in (select PNR from passenger where user_id = :u_id)";
            command2.Parameters.Add("u_id", OracleDbType.Varchar2).Value = id;
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
    }
}
