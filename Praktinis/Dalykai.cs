using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Praktinis
{
    public partial class Dalykai : UserControl
    {
        public Dalykai()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Server=TOBY-PC;Database=Praktinis; User ID=sa;Password=123456");
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
       

        private void Dalykai_Load(object sender, EventArgs e)
        {

            this.dalykaiTableAdapter.Fill(this.praktinisDataSet.dalykai);
            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("Pavadinimas", 130, HorizontalAlignment.Center);
            listView1.Columns.Add("grupes_id", 130, HorizontalAlignment.Center);
            listView1.Columns.Add("destyrojo_id", 130, HorizontalAlignment.Center);
            listView1.View = View.Details;
            
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dalykai", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            conn.Close();

            dt = ds.Tables["testTable"];
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());

            }
        }

      
        public void RefreshDalykai()
        {
            listView1.Clear();
            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("Pavadinimas", 130, HorizontalAlignment.Center);
            listView1.Columns.Add("grupes_id", 130, HorizontalAlignment.Center);
            listView1.Columns.Add("destyrojo_id", 130, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dalykai", conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            conn.Close();

            dt = ds.Tables["testTable"];
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DalykuRepository repository = new DalykuRepository();
            repository.PridetiDalyka(textBox1.Text, textBox2.Text, textBox3.Text);
            
            MessageBox.Show("Dalykas was added.");
            textBox1.Clear();
            this.dalykaiTableAdapter.Fill(this.praktinisDataSet.dalykai);
            RefreshDalykai();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int fid;
            bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);
      
            DalykuRepository repository = new DalykuRepository();
            repository.IstrintiDalyka(fid);
            this.dalykaiTableAdapter.Fill(this.praktinisDataSet.dalykai);
            RefreshDalykai();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
