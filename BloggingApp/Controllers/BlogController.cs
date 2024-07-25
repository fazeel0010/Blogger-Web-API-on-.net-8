using BlogApp.DTO;
using BlogApp.Model;
using BlogApp.Repository;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;
using static BlogApp.DbContext.BlogDbContext;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("[controller]/api/posts")]
    public class BlogController : ControllerBase
    {
        private readonly BlogServices _blogService;
        private readonly BloggingContext _context;
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger, BlogServices blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        [HttpGet(Name = "posts")]
        public IActionResult GetAllBlogPosts()
        {
            var allBlogPosts = _blogService.GetAllBlogPost();
            if (allBlogPosts == null)
                return NotFound("There are no posts");

            var blogPostDTOList = new List<BlogPostDTO>();
            foreach (var item in allBlogPosts)
            {
                blogPostDTOList.Add(new BlogPostDTO(item.Title, BlogPostCommentRepository.GetBlogPostCommentsByBlogPostId(item.Id)?.Count ?? 0));
            }
            return Ok(blogPostDTOList);
        }

        [HttpPost]
        public IActionResult CreateBlogPost( CreateBlogPost blogPost)
        {
            _blogService.CreateBlogPost(blogPost);
            return Ok("Blog post created successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogPostById(int id)
        {
            var blogPost = _blogService.GetBlogPostById(id);
            if (blogPost == null)
                return NotFound($"Post has not been found by id:{id}");
            var blogPostDTO = new BlogPostByIdDTO(blogPost.Title, blogPost.Content, BlogPostCommentRepository.GetBlogPostCommentsByBlogPostId(id));
            return Ok(blogPostDTO);
        }

        [HttpPost("{id}/comments")]
        public IActionResult AddComment(int id, CreateComment comment)
        {
            var data = BlogPostRepository.GetBlogPostById(id);
            if (data == null)
                return NotFound($"The post Id:{id} does not exit in the database");
            _blogService.CreateBlogPostComment(id, comment.Comment);
            return Ok("Comment has been added successfully");
        }


    }
}
