using Core.DataAccess.Repositories;
using System;
using System.Data.Entity;

namespace Blogging.DbModel
{
    public class BlogContext : DataContext
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
