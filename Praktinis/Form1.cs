using LoginApp;
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
    public partial class Form1 : Form
    {
        public static User LoggedInUser;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsersRepository repository = new UsersRepository();
            try
            {
               Form1.LoggedInUser = repository.Login(textBox1.Text, textBox2.Text);

               Form2 g = new Form2();
                g.Show();
                this.Hide();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
