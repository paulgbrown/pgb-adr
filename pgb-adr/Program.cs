using System;
using System.IO;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace pgb_adr
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder();
			BuildConfig(builder);

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Build())
				.Enrich.FromLogContext()
				.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			var host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					//services.AddTransient<IIneligiblesService, IneligiblesService>();

					//services.AddScoped<IIneligiblesOptionsBuilder, IneligiblesOptionsBuilder>();
					//services.AddScoped<IProcessExtractDataCommand, ProcessExtractDataCommand>();
					//services.AddScoped<ISavePriorIneligiblesCommand, SavePriorIneligiblesCommand>();
					//services.AddScoped<IPayloadFactory, PayloadFactory>();

					//services.AddDbContext<IneligiblesContext>(options =>
					//    options.UseSqlServer(builder.Build().GetConnectionString("DefaultConnection")));
				})
				.UseSerilog()
				.Build();

			/// Note: This Activator call deliberately uses the instance IneligiblesService
			/// instead of the interface IIneligiblesService
			var svc = ActivatorUtilities.CreateInstance<AdrService>(host.Services);
			svc.Run(args);
		}

		static void BuildConfig(IConfigurationBuilder builder)
		{
			builder.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIROMENT") ?? "Production"}.json", optional: true)
				.AddEnvironmentVariables();
		}
	}
}
