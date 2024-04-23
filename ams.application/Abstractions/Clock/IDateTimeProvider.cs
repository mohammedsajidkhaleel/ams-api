namespace ams.application.Abstractions.Clock;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}

