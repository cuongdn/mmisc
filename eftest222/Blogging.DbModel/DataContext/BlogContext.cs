using System;
using System.Data.Entity;

namespace Blogging.DbModel.DataContext
{
    public class BlogContext : Core.DataAccess.Repositories.DataContext
    {
        public BlogContext()
            : base("name=ConnectionString")
        {
            Database.Log = x =>
            {
                var color = Console.ForegroundColor;
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(x);
                }
                finally
                {
                    Console.ForegroundColor = color;
                }
            };
            Database.SetInitializer(new NullDatabaseInitializer<BlogContext>());
        }
    }
}
