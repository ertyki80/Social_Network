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
using SocialNetwork.BusinesLogic.Service;
using SocialNetwork.DataAccess.Helpers;
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.WindowsForm
{
    public partial class Comment : MaterialForm
    {
        private Comments comment;

        private User _user = new User();
        public Comment(User currentUser)
        {
            _user = currentUser;
            InitializeComponent();
        }

        private void Comment_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public Comments GetComment()
        {
            return comment;
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            comment = new Comments(){Author = _user.Name,Body = richTextBox1.Text};
            
            this.Close();

        }
    }
}
