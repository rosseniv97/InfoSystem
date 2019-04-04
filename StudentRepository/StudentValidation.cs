using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository
{
    class StudentValidation
    {
       public Student GetStudentDataByUser(User user)
        {
            Student student = null;
            if (user.facNum == null)
            {
                Console.WriteLine("No faculty number was given");
            }
            else
            {
                student = (from stud in StudentData.TestStudent where stud._facNum.Equals(user.facNum) select stud).FirstOrDefault();
                
            }
            if (student == null) Console.WriteLine("No such faculty number");

            return student;
        }
    }
}
