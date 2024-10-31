using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MrB0nj.Console;

static class Application
{
	public static void ConfigureLogging()
	{
		var configuration = BuildConfig().Build();
		Log.Logger = new LoggerConfiguration()
			.ReadFrom.Configuration(configuration)
			.CreateLogger();
	}

	public static void BuildAndRun<T>(string[] args) where T : BackgroundService
	{
		CreateHost<T>(args).Build().Run();
	}

	static IHostBuilder CreateHost<T>(string[] args) where T : BackgroundService =>
		Host.CreateDefaultBuilder(args)
			.ConfigureServices((context, services) =>
				{
					services.AddHostedService<T>();
				})
			.UseSerilog();

	static IConfigurationBuilder BuildConfig(IConfigurationBuilder? builder = null)
	{
		if (builder == null) builder = new ConfigurationBuilder();

		var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
		builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
			.AddEnvironmentVariables();

		return builder;
	}
}
