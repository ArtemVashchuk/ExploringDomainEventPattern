namespace Gatherly.Domain.Exceptions;

public sealed class GatheringMaximumNumberOfAttendeesIsNullDomainException(string message)
    : BaseDomainException(message);