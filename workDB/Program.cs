using System;
using System.Linq;
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

                var blogesNames = db.Blog.Where(b => b.Post.Count() < 1).Select(u => u.Url).ToList<string>();
                Console.WriteLine("Blogs in database where quality post < 1 : {0}", String.Join(",",blogesNames));

            }
        }
    }
}







