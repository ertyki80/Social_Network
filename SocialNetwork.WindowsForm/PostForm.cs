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
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.WindowsForm
{
    public partial class PostForm : MaterialForm
    {

        private Post post;

        private User _user = new User();
        public PostForm(User user)
        {

            _user = user;
            InitializeComponent();
        }

        private void Post_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public Post GetPost()
        {
            return post;
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Post nPost = new Post() { Body = richTextBox2.Text,Id=new Guid(),Like=0,Tags = null,TimeOfCreating = DateTime.Now.ToString(),Title=richTextBox1.Text};
            post = nPost;
        }
    }
}
