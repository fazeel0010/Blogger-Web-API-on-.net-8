using BlogApp.Model;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BlogApp.DbContext
{
    public class BlogDbContext
    {
        public class BloggingContext 
            //: DbContext
        {
            //public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
            //{
            //}

            public BlogPost BlogPosts { get; set; }
            public BlogPostComment Comments { get; set; }
        }
    }
}
