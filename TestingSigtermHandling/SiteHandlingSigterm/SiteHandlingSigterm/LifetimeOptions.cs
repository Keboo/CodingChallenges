namespace SiteHandlingSigterm;

public class LifetimeOptions
{
    public const string SectionName = nameof(LifetimeOptions);
    public TimeSpan StoppingDelay { get; set; }
}