using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Entities;

public class Consultation : AggregateRoot
{
    private readonly List<DrugAdministration> administeredDrugs = new();
    private readonly List<VitalSigns> vitalSignReadings = new();
    public DateTime StartedAt { get; init; }
    public DateTime? EndedAt { get; private set; }
    public Text? Diagnosis { get; private set; }
    public Text? Treatment { get; private set; }
    public PatientId PatientId { get; init; }
    public Weight? CurrentWeight { get; private set; }
    public ConsultationStatus Status { get; private set; }
    public IReadOnlyCollection<DrugAdministration> AdministeredDrugs => administeredDrugs;
    public IReadOnlyCollection<VitalSigns> VitalSignReadings => vitalSignReadings;

    public Consultation(PatientId patientId)
    {
        Id = Guid.NewGuid();
        PatientId = patientId;
        Status = ConsultationStatus.Open;
        StartedAt = DateTime.UtcNow;
    }
    public void RegisterVitalSigns(IEnumerable<VitalSigns> vitalSigns)
    {
        ValidateConsultationStatus();
        vitalSignReadings.AddRange(vitalSigns);
    }

    public void AdministerDrug(DrugId drugId, Dose dose)
    {
        ValidateConsultationStatus();
        var newDrugAdministration = new DrugAdministration(drugId, dose);
        administeredDrugs.Add(newDrugAdministration);
    }

    public void End()
    {
        ValidateConsultationStatus();

        if (Diagnosis == null || Treatment == null || CurrentWeight == null)
        {
            throw new InvalidOperationException("The consultation cannot be ended.");
        }

        Status = ConsultationStatus.Closed;
        EndedAt = DateTime.UtcNow;
    }

    public void SetWeight(Weight weight)
    {
        ValidateConsultationStatus();
        CurrentWeight = weight;
    }

    public void SetDiagnosis(Text diagnosis)
    {
        ValidateConsultationStatus();
        Diagnosis = diagnosis;
    }

    public void SetTreatment(Text treatment)
    {
        ValidateConsultationStatus();
        Treatment = treatment;
    }

    private void ValidateConsultationStatus()
    {
        if (Status == ConsultationStatus.Closed)
        {
            throw new InvalidOperationException("The consultation is already closed.");
        }
    }
}

public enum ConsultationStatus
{
    Open,
    Closed
}