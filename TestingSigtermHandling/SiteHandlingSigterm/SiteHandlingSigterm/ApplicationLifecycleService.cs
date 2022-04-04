using Microsoft.Extensions.Options;

namespace SiteHandlingSigterm;

public class ApplicationLifetimeService : IHostedService
{
    private ILogger Logger { get; }
    private IHostApplicationLifetime ApplicationLifetime { get; }
    public IOptions<LifetimeOptions> LifetimeOptions { get; }

    public ApplicationLifetimeService(
        IHostApplicationLifetime applicationLifetime,
        IOptions<LifetimeOptions> lifetimeOptions,
        ILogger<ApplicationLifetimeService> logger)
    {
        ApplicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        LifetimeOptions = lifetimeOptions ?? throw new ArgumentNullException(nameof(lifetimeOptions));
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }


    public Task StartAsync(CancellationToken cancellationToken)
    {
        // register a callback that sleeps
        ApplicationLifetime.ApplicationStopping.Register(() =>
        {
            Logger.LogInformation($"SIGTERM received, waiting for {LifetimeOptions.Value.StoppingDelay} seconds");
            Thread.Sleep(LifetimeOptions.Value.StoppingDelay);
            Logger.LogInformation("Termination delay complete, continuing stopping process");
        });
        return Task.CompletedTask;
    }

    // Required to satisfy interface
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
