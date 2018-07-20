using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCoreExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool appNamePrinted = PrintAppName(args);

            if (appNamePrinted == false)
            {
                CreateWebHostBuilder(args).Build().Run();
            }
        }

        private static bool PrintAppName(string[] args)
        {
            var commandHandled = false;
            var app = new Microsoft.Extensions.CommandLineUtils.CommandLineApplication();
            app.Command("appName", config =>
            {
                config.OnExecute(() =>
                {
                    var currentAssembly = Assembly.GetExecutingAssembly();
                    var product = currentAssembly.GetCustomAttribute<AssemblyProductAttribute>();
                    Console.WriteLine(product.Product);
                    commandHandled = true;
                    return 0;
                });
            });

            app.Execute(args);
            return commandHandled;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var result = WebHost.CreateDefaultBuilder(args)
                  .UseStartup(Assembly.GetEntryAssembly().FullName);

            return result;
        }
    }
}
