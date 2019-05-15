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
      var builder = new ConfigurationBuilder();
      builder.AddCommandLine(args);

      var config = builder.Build();

      var isService = !(Debugger.IsAttached || args.Contains("--console"));
      var pathToContentRoot = Directory.GetCurrentDirectory();

      var webHostArgs = args.Where(arg => arg != "--console").ToArray();


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
