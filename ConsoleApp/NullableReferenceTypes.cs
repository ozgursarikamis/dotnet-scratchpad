namespace ConsoleApp;

public static class NullableReferenceTypes
{
    public static void Run()
    {
        var post = new BlogPost(null);
        WriteLine($"Post Title: {post.Title}");
    }

    private static void PrintPostInfo(BlogPost post)
    {
        WriteLine($"{post.Title} ({post.Title!.Length})");

        foreach (var comment in post.Comments)
        {
            var commentPreview = comment.Body.Length > 10
                ? $"{comment.Body.Substring(0, 10)}..."
                : comment.Body;
            
            WriteLine($"{comment.PostedBy.Name} ({comment.PostedBy.Email}): {commentPreview}");
        }
    }

    private static void PrintTitle(BlogPost post)
    {
        WriteLine(post.Title);
    }
}

public class BlogPost
{
    public string Title { get; set; }
    public List<Comment> Comments { get; set; } = new();

    public BlogPost(string title)
    {
        Title = title;
    }
}

public class Author
{
    public string? Name { get; set; }
    public string? Email { get; set; }

    public Author(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

public class Comment
{
    public string? Body { get; set; }
    public Author? PostedBy { get; set; }

    public Comment(string body, Author postedBy)
    {
        Body = body;
        PostedBy = postedBy;
    }
}