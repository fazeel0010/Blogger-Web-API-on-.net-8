using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Model
{
    public class BlogPostComment
    {

        public uint Id { get; set; }

        [Required]
        public string Comment { get; set; }


        [ForeignKey("BlogPostId")]
        public uint BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }


        public BlogPostComment()
        {
        }

        public BlogPostComment(uint blogPostId, string comment)
        {
            BlogPostId = blogPostId;
            Comment = comment;
        }

    }
}
