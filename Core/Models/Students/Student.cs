using Core.Models.Students;

namespace Core.Models;

public class Student
{
    public Guid Id { get; } = Guid.CreateVersion7();
    private string FirstName { get; init; } = string.Empty;
    public string LastName { get; private init; } = string.Empty;
    public string? FullName => $"{FirstName} {LastName}";
    private DateOnly DoB { get; init; }
    public Address? Address { get; set; }
    public string? Phone { get; set; }
    public List<Subject> Subjects { get; set; } = [];
    public decimal Avg => this.CalculateGPA();
    public int Age => DateTime.Now.Year - DoB.Year;
    
    private Student()
    {
    }
    
    public static Student Create(string firstName, string lastName, DateOnly dob)
    {
        return new Student
        {
            FirstName = firstName,
            LastName = lastName,
            DoB = dob,
        };
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