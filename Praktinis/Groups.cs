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
    public partial class Groups : UserControl
    {
        public Groups()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Server=TOBY-PC;Database=Praktinis; User ID=sa;Password=123456");
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        private void Groups_Load(object sender, EventArgs e)
        {
            this.grupesTableAdapter.Fill(this.praktinisDataSet.grupes);

            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("Pavadinimas", 130, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from grupes", conn);
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
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void RefreshGroups()
        {
            listView1.Clear();
            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("Pavadinimas", 70, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from grupes", conn);
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupRepository repository = new GroupRepository();
            repository.PridetiGrupe(textBox1.Text);
            MessageBox.Show("Group was added.");
            textBox1.Clear();
            this.grupesTableAdapter.Fill(this.praktinisDataSet.grupes);
            RefreshGroups();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int fid;
            bool parseOK = Int32.TryParse(comboBox1.SelectedValue.ToString(), out fid);

            GroupRepository repository = new GroupRepository();
            repository.IstrintiGrupe(fid);
            this.grupesTableAdapter.Fill(this.praktinisDataSet.grupes);
            RefreshGroups();
        }
    }
}
