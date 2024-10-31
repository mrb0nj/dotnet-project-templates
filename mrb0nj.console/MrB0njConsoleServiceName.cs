using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MrB0nj.Console;

public class MrB0njConsoleServiceName : BackgroundService
{
	private readonly ILogger<MrB0njConsoleServiceName> _logger;

	public MrB0njConsoleServiceName(ILogger<MrB0njConsoleServiceName> logger)
	{
		_logger = logger;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		_logger.LogInformation("Hello MrB0nj.Console!");
		return Task.CompletedTask;
	}
}
