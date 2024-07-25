using BlogApp.DTO;
using BlogApp.Model;
using BlogApp.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Services
{
    public class BlogServices
    {
        public List<BlogPost> GetAllBlogPost()
        {
            var blogPostDTOList = new List<BlogPostDTO>();
            return BlogPostRepository.GetAllBlogPost();
        }

        public void CreateBlogPost(CreateBlogPost createBlogPost)
        {
            var BlogPost = new BlogPost(createBlogPost.Title,createBlogPost.Content);
            BlogPostRepository.CreateBlogPost(BlogPost);
        }


        public BlogPost GetBlogPostById(int blogPostId)
        {
            return BlogPostRepository.GetBlogPostById(blogPostId);
        }


        public void CreateBlogPostComment(int blogPostId, string comment)
        {
            var blogPost = new BlogPostComment(blogPostId, comment);
            BlogPostCommentRepository.CreateBlogPostComment(blogPost);
        }

    }
}
