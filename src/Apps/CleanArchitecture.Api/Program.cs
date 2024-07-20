using Emr.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Emr.Api
{
    /// <summary>
    /// Starter
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        ///    
         
        //public static ApplicationDbContext _contextGenerelApp;
        //public static MydbContext _contextGenerel;
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        /// <summary>
        /// WebHost builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .UseSerilog(((context, configuration) =>
        //        {
        //            configuration.Enrich.FromLogContext()
        //                .Enrich.WithMachineName()
        //                .WriteTo.Console();
        //                //.WriteTo.Elasticsearch(
        //                //    new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
        //                //    {
        //                //        IndexFormat =
        //                //            $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
        //                //        AutoRegisterTemplate = true,
        //                //        NumberOfShards = 2,
        //                //        NumberOfReplicas = 1
        //                //    })
        //                //.Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
        //                //.ReadFrom.Configuration(context.Configuration);
        //        }))
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseContentRoot(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
                    webBuilder.UseStartup<Startup>();
                });
    }
}
