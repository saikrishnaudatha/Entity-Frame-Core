using HandsOnDataAccess;
using HandsOnDataAccess.Context;
using HandsOnDataAccess.Model;
using System;

namespace ExClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyContext db = new MyContext())
            {
                Item o = new Item() { item_name = "SAI" };
                Order p = new Order() { item_id=1,OrderDate = DateTime.Now };
                
                db.Add(p);
                db.Add(o);
                db.SaveChanges();
            }
        }
    }
}
