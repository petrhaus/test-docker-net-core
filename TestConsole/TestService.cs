using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TestConsole
{
    public class TestService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IOptions<Configuration> _configuration;

        public TestService(
            ILogger<TestService> logger,
            IOptions<Configuration> configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            _logger.LogInformation($"Starting with environment {env}...");

            return Task.Run(() =>
            {
                _logger.LogInformation("Started!");
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping...");

            return Task.Run(() =>
            {
                _logger.LogInformation("Stopped!");

            });
        }
    }
}