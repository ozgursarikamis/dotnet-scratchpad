namespace ConsoleApp;

public static class PatternMatching
{
    public static void Run()
    {
        // var teacher = new Teacher("John", "Doe", "Math");
        // var student = new Student("Jane", "Doe", teacher, 7);
        // var result = IsInSeventhGradeMath(student);
        // WriteLine(result);
        
        var employee = new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            Type = "Contractor",
            Region = "US",
            ReportsTo = new Employee
            {
                FirstName = "Jane",
                LastName = "Doe",
                Type = "Manager",
                Region = "UK"
            }
        };
        var result = IsUsBasedWithUkManager(employee);
        WriteLine(result);
    }
    
    private static bool IsInSeventhGradeMath(Student student)
    {
        // return student is Student(_, _, _, _); // _ = discard pattern: Matches any student
        // return student is Student(_, _, _, 7); // matches only 7th grade
        
        // return student is Student(_, _, Teacher(_, _, _), 7); // matches only 7th grade
        // return student is Student(_, _, (_, _, _), 7); // exactly the same as above
        // return student is (_, _, (_, _, _), 7); // exactly the same as above
        
        return student is (_, _, (_, _, "Math"), 7); // the result
    }

    private static bool IsUsBasedWithUkManager(object e)
    {
        // return e is Employee ee &&
        //        ee is { Region: "US", ReportsTo: { Region: "UK" } };
        
        // OR:
        return e is Employee { Region: "US", ReportsTo: { Region: "UK" } };
    }
}

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Type { get; set; }
    public string Region { get; set; }
    public Employee ReportsTo { get; set; }
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