namespace Core.Models.Students;

public static partial class StudentExtensions
{
    extension(Student student)
    {
       public Student WithAddress(string street, int home, string flat)
        {
            student.Address = new Address(street, home, flat);
            return student;
        }
        
        public Student WithPhone(string phone)
        {
            student.Phone = phone;
            return student;
        }
        
        public Student WithSubjects(params Subject[] subjects)
        {
            student.Subjects.AddRange(subjects);
            return student;
        }

    }

    
}