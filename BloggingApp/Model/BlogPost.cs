using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BlogApp.Model
{
    public class BlogPost
    {

        public uint Id { get; set; }

        [ForeignKey("BlogId")]
        public uint BlogId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public List<BlogPostComment> BlogPostComments { get; set; } = new List<BlogPostComment>();

        public BlogPost(string title, string content,uint blogId)
        {
            Title = title;
            Content = content;
            BlogId = blogId;
        }

        public BlogPost()
        {
        }

    }
}
