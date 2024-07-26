namespace BlogApp.Model
{
    public class Blog
    {

        public uint Id { get; set; }
        public string Name { get; set; }
        public List<BlogPost> BlogPosts { get; set; }

        public Blog()
        {
        }

        public Blog(string name)
        {
            Name = name;
        }

    }
}
