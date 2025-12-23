using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShopMart.Data.EF;
using Serilog;
using Serilog.Events;
using TeduCoreApp.Data.EF;

namespace ShopMart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ✅ 1. Cấu hình Serilog TRƯỚC
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/shopmart-.txt",
                              rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                var host = BuildWebHost(args);

                // ✅ 2. Seed database
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbInitializer = services.GetRequiredService<DbInitializer>();
                    dbInitializer.Seed().Wait();
                }

                // ✅ 3. Run app
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
            //AVC
            public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>()
                .Build();
    }
}
