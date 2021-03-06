﻿using System;
using System.Linq;
using System.Security.Policy;
using workDB;

namespace EFGetStarted.ConsoleApp.ExistingDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                /* db.Blog.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count); */

                var a = db.Blog.Count();
                var d = db.Blog.Where(x => x.Post.Count() > 0).ToArray();
                
                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blog)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }

                var count = db.Blog.Count();
                Console.WriteLine(" quality blogs in database: {0}", count);

                var blogesCount = db.Blog.Where(b => b.Post.Count() < 1).ToList().Count();
                Console.WriteLine(" Quality blogs in database where quality post < 1 : {0}", blogesCount);

                var blogesNames = db.Blog.Where(b => b.Post.Count() == 0).Select(u => u.Url).ToList();
                Console.WriteLine("Blogs in database where quality post == 0 : {0}", String.Join(",",blogesNames));

                Console.WriteLine("Sorting:");
                var sortUrl = db.Blog.OrderBy(u => u.Url);
                foreach (var u in sortUrl)
                {
                    Console.WriteLine ("- :{0}", u.Url);
                }

              
            }
        }
    }
}







