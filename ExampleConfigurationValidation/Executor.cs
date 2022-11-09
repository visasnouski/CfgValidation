using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ExampleConfigurationValidation;

internal class Executor : IExecutor
{
	private readonly Settings _settings;
	private readonly ILogger<Executor> _logger;

	public Executor(IOptions<Settings> settings, ILogger<Executor> logger)
	{
		_settings = settings.Value ?? throw new ArgumentNullException(nameof(settings));
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
	}
	public void Execute()
	{
		_logger.LogInformation("AccessKey: [{AccessKey}]", _settings.AccessKey);
		_logger.LogInformation("Region: [{Region}]", _settings.Region);
		_logger.LogInformation("SecretKey: [{SecretKey}]", _settings.SecretKey);
		_logger.LogInformation("ServiceUrl: [{ServiceUrl}]", _settings.ServiceUrl);
	}
}