namespace Core.Models;

public class Student
{
    public Guid Id { get; } = Guid.CreateVersion7(); 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
    public DateOnly? DoB { get; set; }
    public Address? Address { get; set; }
    public string? Phone { get; set; }
    public List<Subject> Subjects { get; set; } = [];

    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public override string ToString()
    {
        return $"{FullName}, Address:{Address?.ToString() ?? "Empty"}, Phone: {Phone ?? "Empty"}";
    }

    public Student Copy()
    {
        var student = (Student)MemberwiseClone();
        return student;
    }
}

public record Subject(string Title, decimal Mark, ExamResult ExamResult);
public record Address(string? Street, int? Home, string Flat);

public enum Specific
{
    None = 0,
    Some = 100
}

public enum ExamResult
{
    None = 0,
    Pass = 100,
    Fail = 200,
}