using System.ComponentModel.DataAnnotations;

namespace BlogApp.DTO
{
    public class BlogPostDTO
    {
        public string Title { get; set; }
        public int CommentCount { get; set; }

        public BlogPostDTO(string title, int commentCount)
        {
            Title = title;
            CommentCount = commentCount;
        }
    }
    
    public class BlogPostByIdDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> CommentsList { get; set; }

        public BlogPostByIdDTO(string title, string content, List<string> commentsList)
        {
            Title = title;
            Content = content;
            CommentsList = commentsList;
        }
    }

    public class CreateBlog
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateBlogPost
    {
        [Required]
        public uint BlogId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }

    public class CreateComment
    {
        [Required]
        public string Comment { get; set; }
    }
}
