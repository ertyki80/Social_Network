using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SocialNetwork.BusinesLogic.Helpers;
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.WindowsForm
{
    public partial class Register : MaterialForm
    {
        private User _currentUser;

        public Register()
        {
            InitializeComponent();
        }
        private void Register_Load(object sender, EventArgs e)
        {
            textBox1.Text = @"Name";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = @"Password";
            textBox2.ForeColor = Color.Gray;
            textBox3.Text = @"Email";
            textBox3.ForeColor = Color.Gray;
            textBox4.Text = @"Phone";
            textBox4.ForeColor = Color.Gray;
            textBox5.Text = @"About";
            textBox5.ForeColor = Color.Gray;
        }

        
        private void textBox1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == @"Name")
            {
                textBox1.Text = "";

            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == @"Password")
            {
                textBox2.Text = "";

            }

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == @"First Name")
            {
                textBox1.Text = "";

            }

        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == @"Last Name")
            {
                textBox1.Text = "";

            }

        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == @"Email")
            {
                textBox5.Text = "";

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutorizeLogic authorizeLogic = new AutorizeLogic();
            var userExist = authorizeLogic.Registration(textBox1.Text, textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text);
            if (userExist==null) return;
            _currentUser = authorizeLogic.GetUser();
            MessageBox.Show("Register successful", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            this.Close();

        }

        public User GetUser()
        {
            return _currentUser;
        }
    }
}
