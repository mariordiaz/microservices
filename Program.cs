using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.Builder; 
using Microsoft.Extensions.Configuration;



namespace netCore
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Starting the App");
            CreateWebHostBuilder(args).Build().Run();
            Console.WriteLine("App Shouted down");

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.UseKestrel()
            .UseStartup<Startup>();
    }
}
