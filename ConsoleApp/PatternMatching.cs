namespace ConsoleApp;

public static class PatternMatching
{
    public static void Run()
    {
        
    }
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Teacher Teacher { get; set; }
    public int GradeLevel { get; set; }

    public Student(string firstName, string lastName, Teacher teacher, int gradeLevel)
    {
        FirstName = firstName;
        LastName = lastName;
        Teacher = teacher;
        GradeLevel = gradeLevel;
    }
    
    public void Deconstruct(
        out string firstName,
        out string lastName,
        out Teacher teacher,
        out int gradeLevel
        )
    {
        firstName = FirstName;
        lastName = LastName;
        teacher = Teacher;
        gradeLevel = GradeLevel;
    }
}

public class Teacher
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Subject { get; set; }

    public Teacher(string firstName, string lastName, string subject)
    {
        FirstName = firstName;
        LastName = lastName;
        Subject = subject;
    }
    
    public void Deconstruct(
        out string firstName, // add out any parameters you want to deconstruct
        out string lastName,
        out string subject
        )
    {
        firstName = FirstName;
        lastName = LastName;
        subject = Subject;
    }
}