using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;

namespace ISPTF.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            Log.Logger = new LoggerConfiguration()
                //.ReadFrom.Configuration(config)
                .WriteTo.Console(new JsonFormatter())
                //.WriteTo.Seq("http://localhost:44392")
                .WriteTo.File(
                    path: "c:\\data\\logs\\ISPTF-Standing-log-.txt",
                    outputTemplate:"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval:RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information
                    )
                .WriteTo.File(new JsonFormatter(), "log.json")
                .WriteTo.Seq(
                    serverUrl: "http://203.154.158.182:8081"
                )
                .WriteTo.MSSqlServer("Data Source=.;Initial Catalog=SerilogExample;User ID=sa;Password=ispadmin;Integrated Security=false;",
                    new MSSqlServerSinkOptions
                    {
                        TableName = "Logs",
                        SchemaName = "dbo",
                        AutoCreateSqlTable = true
                    })
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .CreateLogger();
            Log.Information("Hello {Name} from thread {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"), Thread.CurrentThread.ManagedThreadId);


            try
            {
                Log.Information("Web Api is starting");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Web Api failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            //var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            //}

            //host.Run();

            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();
            //Log.Logger = new LoggerConfiguration()
            //  .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //  .Enrich.FromLogContext()
            //  .WriteTo.Console()
            //  .CreateLogger();

            //try
            //{
            //    Log.Information("Starting web host");
            //    CreateHostBuilder(args).Build().Run();
            //    return 0;
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Host terminated unexpectedly");
            //    return 1;
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.UseSerilog((context, services, configuration) => configuration
                //.ReadFrom.Configuration(context.Configuration)
                //.ReadFrom.Services(services)
                //.Enrich.FromLogContext()
                //.WriteTo.Console())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => 
                {
                    webBuilder.UseStartup<Startup>(); 
                });
        //.ConfigureWebHostDefaults(webBuilder =>
        //{
        //    webBuilder.UseStartup<Startup>();
        //});
    }
}
