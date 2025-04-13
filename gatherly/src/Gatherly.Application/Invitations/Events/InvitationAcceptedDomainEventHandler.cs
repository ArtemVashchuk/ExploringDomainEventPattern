using Gatherly.Application.Abstractions;
using Gatherly.Domain.DomainEvents;
using Gatherly.Domain.Repositories;
using MediatR;

namespace Gatherly.Application.Invitations.Events;

public sealed class InvitationAcceptedDomainEventHandler(
    IGatheringRepository gatheringRepository,
    IEmailService emailService)
    : INotificationHandler<InvitationAcceptedDomainEvent>
{
    public async Task Handle(InvitationAcceptedDomainEvent notification, CancellationToken cancellationToken)
    {
        var gathering = await gatheringRepository.GetByIdAsync(notification.GatheringId, cancellationToken);

        if (gathering is null)
        {
            return;
        }

        await emailService.SendInvitationAcceptedEmailAsync(gathering, cancellationToken);
    }
}