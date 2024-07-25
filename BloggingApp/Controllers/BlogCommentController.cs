using BlogApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogCommentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BlogController> _logger;

        public BlogCommentController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }
    }
}
