namespace ConsoleApp;

public static class NullableReferenceTypes
{
    public static void Run()
    {
        
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
    public string? Title { get; set; }
    public List<Comment>? Comments { get; set; }
}

public class Author
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

public class Comment
{
    public string? Body { get; set; }
    public Author? PostedBy { get; set; }
}