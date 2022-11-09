using ExampleConfigurationValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
	builder
		.AddFilter("Microsoft", LogLevel.Warning)
		.AddFilter("System", LogLevel.Warning)
		.AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
		.AddConsole();
});

var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
var configurationRoot = configurationBuilder.Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton(loggerFactory);
serviceCollection.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
serviceCollection.AddSingleton<IExecutor, Executor>();

serviceCollection.AddOptions<Settings>()
	.Bind(configurationRoot.GetSection("Some:DB"))
	.ValidateDataAnnotations();

var provider = serviceCollection.BuildServiceProvider();

var executor = provider.GetRequiredService<IExecutor>();
executor.Execute();

