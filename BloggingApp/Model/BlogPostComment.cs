using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Model
{
    public class BlogPostComment
    {

        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }


        [ForeignKey("BlogPost")]
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }


        public BlogPostComment()
        {
        }

        public BlogPostComment(int blogPostId, string comment)
        {
            BlogPostId = blogPostId;
            Comment = comment;
        }

    }
}
