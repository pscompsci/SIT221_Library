using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Playground
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Program
    {
        const int n = 5000000;
        const int runs = 1000;

        static void Main(string[] args)
        {
            Random random = new Random();
            Stopwatch watch = new Stopwatch();
            int index;

            Hashtable hash = new Hashtable();
            List<Student> students = new List<Student>();

            long totalHashTime = 0;
            long totalListTime = 0;

            for(int i = 0; i < n; i++)
            {
                Student student = new Student(id: i, name: "student" + i);
                hash.Add(i, student);
                students.Add(student);
            }

            for(int i = 0; i < runs; i++)
            {
                index = random.Next(n - runs, n);
                
                watch.Start();
                Student resultList = students[index];
                watch.Stop();
                totalListTime += watch.ElapsedTicks;
                watch.Reset();

                watch.Start();
                Student resultHash = (Student)hash[index];
                watch.Stop();
                totalHashTime += watch.ElapsedTicks;
                watch.Reset();
            }
            Console.Write("Total Size: {0:#,##0} Runs {1,3}: ", n, runs);
            Console.Write("List: Average Ticks: {0, 3}, Hash: Average Ticks: {1, 3}",
                totalListTime/runs, totalHashTime/runs);
            Console.WriteLine();
        }
    }
}
