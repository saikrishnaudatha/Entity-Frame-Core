using System;
using DataAccessLibrary;
using DataAccessLibrary.Context;
using DataAccessLibrary.Models;

namespace EMSClient
{
    class Program
    {
        static void Main(string[] args)
        {

            using(MyContext db=new MyContext())
            {
                Project p = new Project() { ProjectName = "BFS" };
                db.Add(p);
                db.SaveChanges();
            }
        }
    }
}
