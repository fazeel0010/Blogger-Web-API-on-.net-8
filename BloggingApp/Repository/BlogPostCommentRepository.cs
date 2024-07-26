using BlogApp.Model;

namespace BlogApp.Repository
{
    public static class BlogPostCommentRepository
    {
        private static List<BlogPostComment> BlogPostsComment = new List<BlogPostComment>()
        {
            new BlogPostComment() {Id=1,Comment="Good ppost",BlogPostId=3},
            new BlogPostComment() {Id=2,Comment="bad post",BlogPostId=3},
            new BlogPostComment() {Id=3,Comment="average post",BlogPostId=3},
            new BlogPostComment() {Id=4,Comment="I really like the post",BlogPostId=5},
        };

        public static void CreateBlogPostComment(BlogPostComment postComment)
        {
            postComment.Id = (uint) BlogPostsComment.Count + 1;
            BlogPostsComment.Add(postComment);
        }

        public static List<string> GetBlogPostCommentsByBlogPostId(uint blogPostId)
        {
            return BlogPostsComment.Where(x=> x.BlogPostId == blogPostId).Select(x=>x.Comment).ToList();
        }
    }
}
