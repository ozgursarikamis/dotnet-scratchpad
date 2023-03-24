using System.Text.Json;

namespace ConsoleApp.Json;

public static class JsonSerializerApp
{
    public static void Run()
    {
        var text = File.ReadAllText("./Json/sample.json");
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var course = JsonSerializer.Deserialize<Course>(text, options);

        
        WriteLine($"Course Name: {course.CourseName}");
        WriteLine($"Language: {course.Language}");
        WriteLine($"Author: {course.Author.FirstName} {course.Author.LastName}");
        WriteLine($"Published At: {course.PublishedAt}");
        WriteLine($"Published Year: {course.PublishedYear}");
        WriteLine($"Is Active: {course.IsActive}");
        WriteLine($"Tags: {string.Join(", ", course.Tags)}");
    }
}

public class Course
{
    public string CourseName { get; set; }
    public string Language { get; set; }
    public Author Author { get; set; }
    public DateTime PublishedAt { get; set; }
    public int PublishedYear { get; set; }
    public bool IsActive { get; set; }
    public string[] Tags { get; set; }
    
}

public class Author
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}