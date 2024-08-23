using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Events;
public record PetWeightUpdated(Guid Id, decimal Weight) : IDomainEvent;