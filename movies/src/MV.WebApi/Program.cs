using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using MV.WebApi.Server;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace MV.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            
                
                    var host = WebHost.CreateDefaultBuilder(webHostArgs)
                        .UseConfiguration(config)
                        .ConfigureServices(s => s.AddAutofac())
                        .UseContentRoot(pathToContentRoot)
                        .UseStartup<Startup>()
                        .UseIISIntegration()
                        .UseSerilog()
                        .Build();

                    host.Run();
                
        }
    }
}
