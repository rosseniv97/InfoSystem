﻿using System;

namespace StudentRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 6; i++)
            {
                Console.Write(StudentData.TestStudent[i].facNum+" \n");
                Console.Write(StudentData.TestStudent[i].year + " \n");

            }
            String facNum;
            facNum= Console.ReadLine();
            StudentData.IsThereStudent(facNum);
            


        }
    }
}
