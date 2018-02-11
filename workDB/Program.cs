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
                db.Blog.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blog)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }

                               var groups = db.Blog.GroupBy(b=>b.BlogId)
                                  .Select(b => new { Count = b.Count()});
                foreach (var b in groups)
                    Console.WriteLine(" quality blogs in database: {0}, BlogId: {1}", b.Count, BlogId);
            }
        }
    }
}
