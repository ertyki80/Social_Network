using AutoMapper;
using DataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.Concrete;
using WebApp.Models.ProfileApp;

namespace WebApp.Controllers
{
    public class PostController : Controller
    {
        private static UserManagerModel user;
        

        public ActionResult Index()
        {
            if (TempData["User"] != null)
            {
                user = new UserManagerModel((int)TempData["User"]);
            }
            else
            {
                return new HttpUnauthorizedResult();
            }
            return Redirect("~/Posts/Posts");
        }

        [HttpPost]
        public ActionResult Posts(FormCollection form)
        {
            var postId = Convert.ToInt32(form.GetValues("Post_Id")[0]);
            var action = form.GetKey(1);

            if (action == "LikeButton")
            {
                user.Get().LikePost(postId);
            }
            else if (action == "CommentButton")
            {
                TempData["post_id"] = postId;
                return Redirect("~/Posts/AddComment");
            }

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PostProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            var all_posts = new List<PostModel>();
            foreach (var p in user.Get().GetAllPosts())
            {
                all_posts.Add(mapper.Map<PostModel>(p));
            }
            ViewBag.Posts = all_posts;
            return View();
        }

        [HttpGet]
        public ActionResult Posts()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PostProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            var all_posts = new List<PostModel>();
            foreach (var p in user.Get().GetAllPosts())
            {
                all_posts.Add(mapper.Map<PostModel>(p));
            }
            ViewBag.Posts = all_posts;

            return View();
        }
        [HttpGet]
        public ActionResult AddComment()
        {
            int id = (int)TempData["post_id"];
            TempData["post_id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddComment(string comment)
        {
            user.Get().AddComment((int)TempData["post_id"], comment);
            return Redirect("~/Posts/Posts");
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            //int id = (int)TempData["post_id"];
            //TempData["post_id"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(PostDTO post)
        {
            user.Get().CreatePost(post.Title, post.Body, string.Join(",", post.Tags));
            return Redirect("~/Posts/Posts");
        }

        public ActionResult Post()
        {
            return PartialView();
        }
    }
}