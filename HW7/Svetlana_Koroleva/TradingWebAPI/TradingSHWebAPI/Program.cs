using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TradingSHWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()

                .UseContentRoot(Directory.GetCurrentDirectory())

                .UseStartup<Startup>()

                .UseKestrel((context, options) =>

                {



                })
                .Build();

            host.Run();


        }
    }
}
