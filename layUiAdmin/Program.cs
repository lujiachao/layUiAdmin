using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace layUiAdmin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
               .UseUrls("http://192.168.1.180:1314")
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseIISIntegration()
               .UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();
    }
}
