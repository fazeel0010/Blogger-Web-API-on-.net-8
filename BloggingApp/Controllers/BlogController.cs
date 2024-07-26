using BlogApp.DTO;
using BlogApp.Model;
using BlogApp.Repository;
using BlogApp.Services;
using Microsoft.AspNetCore.Mvc;
using static BlogApp.DbContext.BlogDbContext;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/")]
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

        [HttpGet("blogs")]
        public IActionResult GetAllBlogs()
        {
            var allBlog = _blogService.GetAllBlogs();
            if (allBlog == null)
                return NotFound("There are no blogs in database");

            var blogPostDTOList = new List<BlogPost>();
            foreach (var item in allBlog)
            {
                item.BlogPosts = BlogPostRepository.GetBlogPostByBlogId(item.Id);
            }
            return Ok(allBlog);
        }


        [HttpPost("blog")]
        public IActionResult CreateBlog(CreateBlog blogPost)
        {
            _blogService.CreateBlog(blogPost);
            return Ok("Blog has been created successfully");
        }


        [HttpGet("posts")]
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


        [HttpPost("posts")]
        public IActionResult CreateBlogPost( CreateBlogPost blogPost)
        {
            var data = BlogRepository.GetBlogById(blogPost.BlogId);
            if (data == null)
                return NotFound($"The blog Id:{blogPost.BlogId} does not exit in the database");
            _blogService.CreateBlogPost(blogPost);
            return Ok("Blog post has been created successfully");
        }

        [HttpGet("posts/{id}")]
        public IActionResult GetBlogPostById(uint id)
        {
            var blogPost = _blogService.GetBlogPostById(id);
            if (blogPost == null)
                return NotFound($"Post has not been found by id:{id}");
            var blogPostDTO = new BlogPostByIdDTO(blogPost.Title, blogPost.Content, BlogPostCommentRepository.GetBlogPostCommentsByBlogPostId(id));
            return Ok(blogPostDTO);
        }

        [HttpPost("posts/{id}/comments")]
        public IActionResult AddComment(uint id, CreateComment comment)
        {
            var data = BlogPostRepository.GetBlogPostById(id);
            if (data == null)
                return NotFound($"The post Id:{id} does not exit in the database");
            _blogService.CreateBlogPostComment(id, comment.Comment);
            return Ok("Comment has been added successfully");
        }


    }
}
