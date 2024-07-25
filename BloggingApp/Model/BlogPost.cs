using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BlogApp.Model
{
    public class BlogPost
    {
        public BlogPost(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public BlogPost()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public List<BlogPostComment> BlogPostComments { get; set; } = new List<BlogPostComment>();
    }
}
