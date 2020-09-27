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
    public partial class Login : MaterialForm
    {
        private User _currentUser;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Text = @"Email";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = @"Password";
            textBox2.ForeColor = Color.Gray;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == @"Email")
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

        private void button1_Click(object sender, EventArgs e)
        {
            AutorizeLogic authorizeLogic = new AutorizeLogic();
            var userExist = authorizeLogic.Login(textBox1.Text, textBox2.Text);
            if (!userExist) return;
            _currentUser = authorizeLogic.GetUser();
            Console.WriteLine(@"Login successful");
            Console.WriteLine(@"{0} {1}", _currentUser.Name, _currentUser.Password);
            this.Close();
        }
    }
}
