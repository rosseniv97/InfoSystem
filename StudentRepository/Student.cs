using System;
using System.Collections.Generic;
using System.Text;


namespace StudentRepository
{
    public class Student
    {
        public String firstName;
        public String secondName;
        public String lastName;
        public String faculty;
        public String speciality;
        public String degree;
        public int status;
        public StringBuilder facNum;
        public int year;
        public int stream;
        public int group;
        public DateTime dateZav;
        public DateTime datePay;
        

      

        public Student(String firstName, String secondName, String lastName, String faculty, String speciality, String degree,int stream, int group,String facNumCount)
        {
            
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.degree = degree;
            this.faculty = faculty;
            this.speciality = speciality;
            this.group = group;
            this.stream = stream;

            year = 1;
            status = 1;
            facNum = new StringBuilder();
            facNum.Append("121216");
            facNum.Append(facNumCount);               

        }
    }

   

}
