using BlogApp.Model;

namespace BlogApp.Repository
{
    public static class BlogPostRepository
    {
        private static List<BlogPost> blogPosts = new List<BlogPost>()
        {
            new BlogPost() {Id=1,Title="1st blog ppost",Content="Content of the 1st blog post.",BlogPostComments= new List<BlogPostComment>(){ } },
            new BlogPost() {Id=2,Title="2nd blog ppost",Content="Content of the 2nd blog post.",BlogPostComments= new List<BlogPostComment>(){ } },
            new BlogPost() {Id=3,Title="3rd blog ppost",Content="Content of the 3d blog post.",BlogPostComments= new List<BlogPostComment>(){ } },
            new BlogPost() {Id=4,Title="4th blog ppost",Content="Content of the 4th blog post.",BlogPostComments= new List<BlogPostComment>(){ } },
            new BlogPost() {Id=5,Title="5th blog ppost",Content="Content of the 5th blog post.",BlogPostComments= new List<BlogPostComment>(){ } },
        };

        public static List<BlogPost> GetAllBlogPost() => blogPosts;

        public static void CreateBlogPost(BlogPost blogPost)
        {
            blogPost.Id = blogPosts.Count + 1;
            blogPosts.Add(blogPost);
        }

        public static BlogPost GetBlogPostById(int blogPostId) => blogPosts?.FirstOrDefault(x => x.Id == blogPostId);
    }
}
