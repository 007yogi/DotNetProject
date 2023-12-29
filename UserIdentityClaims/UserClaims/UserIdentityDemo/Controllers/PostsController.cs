using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserIdentityDemo.Data;
using UserIdentityDemo.Helpers;
using UserIdentityDemo.Models;

namespace UserIdentityDemo.Controllers
{
    [Authorize(Policy = "EmailID")]
    public class PostsController : Controller
    {
        private readonly ILogger<PostsController> _logger;

        public PostsController(ILogger<PostsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Post> posts = DataHelper.GetAllPosts();
            return View(posts);
        }

        public IActionResult Details(string id)
        {
            Post post = DataHelper.GetAllPosts().Find(p => p.Id.Equals(id));
            return View(post);
        }
    }
}
