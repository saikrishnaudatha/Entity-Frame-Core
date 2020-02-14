using HandsOnEFCodeFirst.Context;
using HandsOnEFCodeFirst.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace HandsOnEFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello World!");
           using(MyContext db=new MyContext())
            {
             // Student s = new Student() { Sname = "krish", Age = 23, Std = "XVI" };
           //  db.Students.Add(s);
             //  db.SaveChanges();
                //Student s= db.Students.Find(1);
                // Console.WriteLine("Welcome {0}", s.Sname);
                Student s1= db.Students.SingleOrDefault(i => i.Sname == "Sai");
                List<Student> list = db.Students.Where(i => i.Age == 10).ToList();
                List<Student> list1 = db.Students.Where(i => i.Age == 10 && i.Std=="XV").ToList();

                Student s2 = db.Students.SingleOrDefault(i => i.Sname == "Sai");
                db.Students.Remove(s2);
                db.SaveChanges();

            }
        }
    }
}
