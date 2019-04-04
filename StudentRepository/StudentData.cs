using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentRepository
{
    public static class StudentData
    {
       static private List<Student> student;
        static public List<Student> TestStudent
        {
            get
            {
                ResetStudent();
                return student;
            }
            private set
            {

            }

        }
        static private void ResetStudent()
        {
            student = new List<Student>();
            Student newStud;
            for (int i = 0; i < 6; i++)
            {
                
                 newStud = new Student("name" + i, "secondname" + i, "lastname" + i, "fac" + i, "spec" + i, "degree" + i, i, i,i.ToString());
                student.Add(newStud);

            }
        }
       static public void IsThereStudent(String facNum)
        {
            Student student = null;
            student = (Student)(from stud in TestStudent where stud._facNum.Equals(facNum) select stud).FirstOrDefault();

            if (student != null)
            {
                Console.WriteLine(student._firstName);
            }
            else Console.WriteLine("Student not found");
        }
    }
}
