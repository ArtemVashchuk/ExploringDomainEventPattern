namespace Gatherly.Domain.Exceptions;

public sealed class GatheringInvitationValidBeforeInHoursIsNullDomainException(string message)
    : BaseDomainException(message);