using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktinis
{
    public partial class Form2 : Form
    {
        Groups fc = new Groups();
        Destytojai fa = new Destytojai();
        Studentai fs = new Studentai();
        Studentopazymiai fl = new Studentopazymiai();
        Dalykai df = new Dalykai();

        public Form2()
        {
            InitializeComponent();
        }


        private void LOGOUT_Click(object sender, EventArgs e)
        {
            Form1 b = new Form1();
            b.Show();
            this.Close();
            Form1.LoggedInUser = null;
      

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.LoggedInUser.GetName() + " " + Form1.LoggedInUser.GetSurname();

            if (Form1.LoggedInUser.GetUserType() == "Admin")
            {
                button1.Visible = true; 
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
            }

            if (Form1.LoggedInUser.GetUserType() == "Teacher")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = true;
            }

            if (Form1.LoggedInUser.GetUserType() == "Student")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                
                panel1.Controls.Clear();
                panel1.Controls.Add(fl);
                fl.Show();
            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(fc);
            fc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(fa);
            fa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(fs);
            fs.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(df);
            df.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            panel1.Controls.Add(fl);
            fl.Show();



        }
    }
}
