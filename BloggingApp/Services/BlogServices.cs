using BlogApp.DTO;
using BlogApp.Model;
using BlogApp.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Services
{
    public class BlogServices
    {
        public List<Blog> GetAllBlogs()
        {
            var blogPostDTOList = new List<Blog>();
            return BlogRepository.GetAllBlog();
        }

        public void CreateBlog(CreateBlog createBlogPost)
        {
            var Blog = new Blog(createBlogPost.Name);
            BlogRepository.CreateBlog(Blog);
        }

        public List<BlogPost> GetAllBlogPost()
        {
            var blogPostDTOList = new List<BlogPostDTO>();
            return BlogPostRepository.GetAllBlogPost();
        }

        public void CreateBlogPost(CreateBlogPost createBlogPost)
        {
            var BlogPost = new BlogPost(createBlogPost.Title,createBlogPost.Content, createBlogPost.BlogId);
            BlogPostRepository.CreateBlogPost(BlogPost);
        }


        public BlogPost GetBlogPostById(uint blogPostId)
        {
            return BlogPostRepository.GetBlogPostById(blogPostId);
        }


        public void CreateBlogPostComment(uint blogPostId, string comment)
        {
            var blogPost = new BlogPostComment(blogPostId, comment);
            BlogPostCommentRepository.CreateBlogPostComment(blogPost);
        }

    }
}
