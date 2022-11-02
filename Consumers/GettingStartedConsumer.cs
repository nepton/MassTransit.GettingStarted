using System.Threading.Tasks;
using GettingStarted.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace GettingStarted.Consumers
{
    public class GettingStartedConsumer : IConsumer<Contracts.GettingStarted>
    {
        private readonly ILogger<GettingStartedConsumer> _logger;

        public GettingStartedConsumer(ILogger<GettingStartedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Contracts.GettingStarted> context)
        {
            _logger.LogInformation("Received message: {Message}", context.Message);
            context.RespondAsync(new GettingStartedAccepted() {Message = "Hello World from consumer!"});

            return Task.CompletedTask;
        }
    }
}
