using Wpm.Clinic.Domain.Events;
using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Entities;

public class Consultation : AggregateRoot
{
    private readonly List<DrugAdministration> administeredDrugs = new();
    private readonly List<VitalSigns> vitalSignReadings = new();
    public DateTimeRange When { get; private set; }
    public Text? Diagnosis { get; private set; }
    public Text? Treatment { get; private set; }
    public PatientId PatientId { get; private set; }
    public Weight? CurrentWeight { get; private set; }
    public ConsultationStatus Status { get; private set; }
    public IReadOnlyCollection<DrugAdministration> AdministeredDrugs => administeredDrugs;
    public IReadOnlyCollection<VitalSigns> VitalSignReadings => vitalSignReadings;

    public Consultation(PatientId patientId)
    {        
        ApplyDomainEvent(new ConsultationStarted(Guid.NewGuid(),
                                                 patientId,
                                                 DateTime.UtcNow));
    }

    public Consultation(IEnumerable<IDomainEvent> domainEvents)
    {
        Load(domainEvents);
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
        ApplyDomainEvent(new ConsultationEnded(Id, DateTime.UtcNow));
    }

    public void SetWeight(Weight weight)
    {
        ApplyDomainEvent(new WeightUpdated(Id, weight));
    }

    public void SetDiagnosis(Text diagnosis)
    {
        ApplyDomainEvent(new DiagnosisUpdated(Id, diagnosis));
    }

    public void SetTreatment(Text treatment)
    {
        ApplyDomainEvent(new TreatmentUpdated(Id, treatment));
    }

    private void ValidateConsultationStatus()
    {
        if (Status == ConsultationStatus.Closed)
        {
            throw new InvalidOperationException("The consultation is already closed.");
        }
    }

    protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
    {
        switch (domainEvent)
        {
            case ConsultationStarted e:
                Id = e.Id;
                PatientId = e.PatientId;
                Status = ConsultationStatus.Open;
                When = e.StartedAt;
                break;
            case DiagnosisUpdated e:
                ValidateConsultationStatus();
                Diagnosis = e.Diagnosis;
                break;
            case TreatmentUpdated e:
                ValidateConsultationStatus();
                Treatment = e.Treatment;
                break;
            case WeightUpdated e:
                ValidateConsultationStatus();
                CurrentWeight = e.Weight;
                break;
            case ConsultationEnded e:
                ValidateConsultationStatus();
                if (Diagnosis == null || Treatment == null || CurrentWeight == null)
                {
                    throw new InvalidOperationException("The consultation cannot be ended.");
                }
                Status = ConsultationStatus.Closed;
                When = new DateTimeRange(When.StartedAt, DateTime.UtcNow);
                break;
        }
    }
}

public enum ConsultationStatus
{
    Open,
    Closed
}