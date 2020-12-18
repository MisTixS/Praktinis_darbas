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
using LoginApp;

namespace Praktinis
{
    public partial class Studentopazymiai : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Server=TOBY-PC;Database=Praktinis;User Id=sa;Password=123456");
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        public Studentopazymiai()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }



        private void Studentopazymiai_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("dalyko pavadinimas", 140);
            listView1.Columns.Add("pazymys", 140, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select dalykai.pavadinimas, pazymiai.pazymys from [pazymiai] " +
                "INNER JOIN dalykai ON pazymiai.dalyko_id=dalykai.id WHERE pazymiai.studento_id = @studento_id", conn);
            UsersRepository repository = new UsersRepository();
            string student_id = repository.GetUserId(Form1.LoggedInUser.GetUserName());

            cmd.Parameters.AddWithValue("@studento_id", student_id);
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

        private void Studentopazymiai_Load_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

