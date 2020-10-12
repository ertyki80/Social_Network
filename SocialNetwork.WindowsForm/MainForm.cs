using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using SocialNetwork.BusinesLogic.Service;
using SocialNetwork.DataAccess.Helpers;
using SocialNetwork.DataAccess.Models;

namespace SocialNetwork.WindowsForm
{
    public partial class MainForm : MaterialForm
    {
        private User _user = new User();
        private readonly IEnumerable<Post> posts;
        private Int32 Id = 0;
        readonly PostService postService;

        private string _comments = "";
        public MainForm()
        {


            postService = new PostService();
            posts = postService.GetAllPosts();
            InitializeComponent();

        }

        private void  UPDATE()
        {
            


            label1.Text = posts.ElementAtOrDefault(Id).Title;
            label2.Text = posts.ElementAtOrDefault(Id).Body;

            string a="";
            foreach (var tag in posts.ElementAtOrDefault(Id).Tags)
            {
                a += tag.Name_.ToString() + " ";
            }

            label3.Text = a;

            label4.Text = posts.ElementAtOrDefault(Id).TimeOfCreating.ToString();
            label5.Text = posts.ElementAtOrDefault(Id).Like.ToString();


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UPDATE();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Login _login = new Login();
            
            _login.ShowDialog();
            if (_login.GetUser() != null)
            {


                _user = _login.GetUser();

                materialLabel1.Text = _user.Name;
                materialLabel2.Text = _user.Email;
            }
            button1.Hide();
            button2.Hide();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_user.About, "",MessageBoxButtons.OK);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (Id != posts.Count())
            {
                Id += 1;
            }

            UPDATE();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {


            string _comments = "";
            for (int i = 0; i < this.posts.ElementAtOrDefault(Id).Comments.Count(); i++)
            {


                _comments += posts.ElementAtOrDefault(Id).Comments.ElementAtOrDefault(i).Body + "\n<<" + posts
                    .ElementAtOrDefault(Id).Comments.ElementAtOrDefault(i).Author + ">>\n";
            }

            string title = "Comment";
            MessageBox.Show(_comments, title);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Comment commentForm = new Comment(_user);
            commentForm.ShowDialog();
            Comments comment =  commentForm.GetComment();
            Post post_ = new Post();
            post_ = posts.ElementAtOrDefault(Id);
            post_.Comments.Append(comment);
            postService.Update( posts.ElementAtOrDefault(Id).Id, post_ );


        }

        private void button7_Click(object sender, EventArgs e)
        {
            PostForm postForm = new PostForm(_user);
            postForm.ShowDialog();
            Post nPost = postForm.GetPost();
            postService.Create(nPost);

            UPDATE();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Post post_ = new Post();
            post_ = posts.ElementAtOrDefault(Id);
            post_.Like++;
            postService.Update(posts.ElementAtOrDefault(Id).Id, post_);
            UPDATE();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();

            register.ShowDialog();
            if (register.GetUser() != null)
            {


                _user = register.GetUser();

                materialLabel1.Text = _user.Name;
                materialLabel2.Text = _user.Email;
            }
            button1.Hide();
            button2.Hide();


        }
    }
}
