using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace xMessage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDB();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
        private static void CreateDB()
        {
            using (var context = new AppDbContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();
            }
        }
    }
}
