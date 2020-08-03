using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Matrix.Net.Server.WebApi
{
	public class Program
	{
		
		//[STAThread]
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			string[] urls = null;
			if (args != null && args.Length > 0)
			{
				var indexOfHosts = Array.FindIndex(args, x => x == "-hosts");

				if (indexOfHosts > -1)
					urls = args[indexOfHosts + 1].Split(';');
			}
			return Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
					if (urls != null)
						webBuilder.UseUrls(urls);
				});
		}
	}
}
