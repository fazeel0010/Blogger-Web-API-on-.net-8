using BlogApp.Model;

namespace BlogApp.Repository
{
    public static class BlogRepository
    {
        private static List<Blog> blogList = new List<Blog>()
        {
            new Blog {Id=1,Name="Nvida",BlogPosts= new List<BlogPost>{ } },
            new Blog {Id=2,Name="Intel",BlogPosts= new List<BlogPost>{ } },
            new Blog {Id=3,Name="Amazon",BlogPosts= new List<BlogPost>{ } },
            new Blog {Id=4,Name="Amazon",BlogPosts= new List<BlogPost>{ } },
        };

        public static List<Blog> GetAllBlog() => blogList;

        public static void CreateBlog(Blog blog)
        {
            blog.Id =(uint) blogList.Count + 1;
            blogList.Add(blog);
        }

        public static Blog GetBlogById(uint blogId) => blogList?.FirstOrDefault(x => x.Id == blogId);
    }
}
