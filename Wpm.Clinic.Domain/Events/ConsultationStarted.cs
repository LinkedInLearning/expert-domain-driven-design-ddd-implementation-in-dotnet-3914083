using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Events;
public record ConsultationStarted(Guid Id, Guid PatientId, DateTime StartedAt) : IDomainEvent;