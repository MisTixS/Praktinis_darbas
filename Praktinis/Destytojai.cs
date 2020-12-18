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
    public partial class Destytojai : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Server=TOBY-PC;Database=Praktinis; User ID=sa;Password=123456");
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        public Destytojai()
        {
            InitializeComponent();
        }

        private void Destytojai_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("Vardas", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Pavarde", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Gimimo_Data", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("Slapyvardis", 110, HorizontalAlignment.Center);
            listView1.Columns.Add("Slaptazodis", 110, HorizontalAlignment.Center);
            listView1.Columns.Add("Tipas", 70, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [vartotojai] where tipas = 'Teacher' ", conn);
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
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString().Substring(0, 10));
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
            }
        }

        public void TeacherRefresh()
        {
            listView1.Clear();
            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("Vardas", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Pavarde", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("Gimimo_Data", 90, HorizontalAlignment.Center);
            listView1.Columns.Add("Slapyvardis", 110, HorizontalAlignment.Center);
            listView1.Columns.Add("Slaptazodis", 110, HorizontalAlignment.Center);
            listView1.Columns.Add("Tipas", 70, HorizontalAlignment.Center);
            listView1.View = View.Details;

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [vartotojai] where tipas = 'Teacher' ", conn);
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
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString().Substring(0, 10));
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User(nameTextBox.Text, surnameTextBox.Text, dateTimePicker1.Value, nameTextBox.Text.ToLower() + "." + surnameTextBox.Text.ToLower(), surnameTextBox.Text.ToLower(), "Teacher", null);
            UsersRepository repository = new UsersRepository();
            user.GetType();
            user.SetUserType("Teacher");
            repository.PatikrintiPrisijungima(nameTextBox.Text.ToLower() + "." + surnameTextBox.Text.ToLower());
            repository.UzregistruotiDestytoja(user);
            nameTextBox.Clear();
            surnameTextBox.Clear();
            MessageBox.Show("Registration succesfull! Teacher may now log in");
            TeacherRefresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Ar tikrai norite istrinti destytoja?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    UsersRepository repository = new UsersRepository();


                    repository.PatikrintiDestytoja(textBox1.Text);
                    repository.IstrintiDestytoja(textBox1.Text);
                    TeacherRefresh();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error message: " + exc.Message);
                }
            }
            else if (dr == DialogResult.No)
            {

            }
        }
    }
}
