using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MrB0nj.Console;

public class Service : BackgroundService
{
	private readonly ILogger<Service> _logger;

	public Service(ILogger<Service> logger)
	{
		_logger = logger;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_logger.LogInformation("Hello MrB0nj.Console!");
		return Task.CompletedTask;
	}
}
