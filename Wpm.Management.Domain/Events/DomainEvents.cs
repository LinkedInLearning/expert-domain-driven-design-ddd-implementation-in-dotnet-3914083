using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Events;
public static class DomainEvents
{
    public static DomainEventDispatcher<PetWeightUpdated> PetWeightUpdated = new();
}