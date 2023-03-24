namespace ConsoleApp;

public static class NullableReferenceTypes
{
    public static void Run()
    {
        BlogPost post = null;
        PrintTitle(post);
    }

    private static void PrintTitle(BlogPost post)
    {
        WriteLine(post.Title);
    }
}

public class BlogPost
{
    public string Title { get; set; }
    public List<Comment> Comments { get; set; }
}

public class Author
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Comment
{
    public string Body { get; set; }
    public Author Author { get; set; }
}