namespace Core.Models.Students;

public static partial class StudentExtensions
{
    extension(Student student)
    {
        public decimal CalculateGPA()
        {
            if (student.Subjects.Count==0)
            {
                return 0;
            }
            
            return student.Subjects.Sum(x => x.Mark) / student.Subjects.Count;
        }
        public bool HasPassedSession() => student.CalculateGPA() >= 60;

    }

    extension(Student)
    {
        public static bool operator ==(Student left, Student right) => left.Subjects.Sum(x => x.Mark) == right.Subjects.Sum(x => x.Mark);
        public static bool operator !=(Student left, Student right) => left.Subjects.Sum(x => x.Mark) != right.Subjects.Sum(x => x.Mark);
        public static bool operator >(Student left, Student right) => left.Subjects.Sum(x => x.Mark) > right.Subjects.Sum(x => x.Mark);
        public static bool operator <(Student left, Student right) => left.Subjects.Sum(x => x.Mark) < right.Subjects.Sum(x => x.Mark);
        
       
    }
}