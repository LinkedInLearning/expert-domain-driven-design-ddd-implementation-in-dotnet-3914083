using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Events;
public record ConsultationStarted(Guid Id, Guid PatientId, DateTime StartedAt) : IDomainEvent;
public record DiagnosisUpdated(Guid Id, string Diagnosis) : IDomainEvent;
public record TreatmentUpdated(Guid Id, string Treatment) : IDomainEvent;
public record WeightUpdated(Guid Id, decimal Weight) : IDomainEvent;
public record ConsultationEnded(Guid Id, DateTime EndedAt) : IDomainEvent;