namespace Wpm.Clinic.Domain.ValueObjects;
public record VitalSigns
{
    public DateTime ReadingDateTime { get; init; }
    public decimal Temperature { get; init; }
    public int HeartRate { get; init; }
    public int RespiratoryRate { get; init; }

    public VitalSigns(decimal temperature,
                      int heartRate,
                      int respiratoryRate)
    {
        ReadingDateTime = DateTime.UtcNow;
        Temperature = temperature;
        HeartRate = heartRate;
        RespiratoryRate = respiratoryRate;
    }
}