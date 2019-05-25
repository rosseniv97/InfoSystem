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
        public Student LogIn(string username, string password)
        {
            Student student = null;
            if (username== "")
            {
                Console.WriteLine("No name was given");
            }
            else
            {
                student = (from stud in StudentData.TestStudent where stud._username.Equals(username) select stud).FirstOrDefault();
            }
            if (student == null)
            {
                Console.WriteLine("No such student found");
                return student;
            }
            else
            {
                if (student._password == password) return student;
                else
                {
                    Console.WriteLine("Wrong password");
                    student = null;
                    return student;
                }
            }

        }
    }
}
