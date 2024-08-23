namespace Wpm.Clinic.Domain.ValueObjects;

public record DateTimeRange
{
    public DateTime StartedAt { get; init; }
    public DateTime? EndedAt { get; init; }

    public DateTimeRange(DateTime startedAt, DateTime endedAt)
    {
        ValidateRange(startedAt, endedAt);
        StartedAt = startedAt;
        EndedAt = endedAt;
    }

    public DateTimeRange(DateTime startedAt)
    {
        StartedAt = startedAt;
    }

    public string Duration
    {
        get
        {
            if (EndedAt == null)
            {
                return "Ongoing";
            }

            TimeSpan elapsedTime = EndedAt.Value - StartedAt;
            return $"Duration: {elapsedTime.Days} days, {elapsedTime.Hours} hours, {elapsedTime.Minutes} minutes, {elapsedTime.Seconds} seconds.";
        }
    }

    public static implicit operator DateTimeRange(DateTime startedAt)
    {
        return new DateTimeRange(startedAt);
    }

    private void ValidateRange(DateTime startedAt, DateTime endedAt)
    {
        if (endedAt < startedAt)
        {
            throw new InvalidOperationException("Invalid date and time range");
        }
    }
}