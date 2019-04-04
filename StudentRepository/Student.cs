using System;
using System.Collections.Generic;
using System.Text;


namespace StudentRepository
{
    public class Student
    {
        private String firstName;
        private String secondName;
        private String lastName;
        private String faculty;
        private String speciality;
        private String degree;
        private int status;
        private String facNum;
        private int year;
        private int stream;
        private int group;
        private DateTime dateVal;
        private DateTime datePay;

        public String _firstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public String _secondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
            }
        }
        public String _lastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public String _faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                faculty = value;
            }
        }
        public String _speciality
        {
            get
            {
                return speciality;
            }
            set
            {
                speciality = value;
            }
        }
        public String _degree
        {
            get
            {
                return degree;
            }
            set
            {
                degree = value;
            }
        }
        public int _status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public String _facNum
        {
            get
            {
                return facNum;
            }
            set
            {
                facNum = value;
            }
        }
        public int _year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public int _stream
        {
            get
            {
                return stream;
            }
            set
            {
                stream = value;
            }
        }
        public int _group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
        public DateTime _dateVal
        {
            get
            {
                return dateVal;
            }
            set
            {
                dateVal = value;
            }
        }
        public DateTime _datePay
        {
            get
            {
                return _datePay;
            }
            set
            {
                _datePay = value;
            }
        }





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
            
            facNum+="121216";
            facNum+=facNumCount;               

        }
    }

   

}
