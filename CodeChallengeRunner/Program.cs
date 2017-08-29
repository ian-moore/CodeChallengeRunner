using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace CodeChallengeRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TelemetryDebugWriter.IsTracingDisabled = true;

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(builder => builder.AddConsole())
                .Build();
        }
    }
}
