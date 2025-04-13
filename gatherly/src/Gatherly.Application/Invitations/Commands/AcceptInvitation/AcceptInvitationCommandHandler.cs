using Gatherly.Domain.Enums;
using Gatherly.Domain.Repositories;
using MediatR;

namespace Gatherly.Application.Invitations.Commands.AcceptInvitation;

internal sealed class AcceptInvitationCommandHandler(
    IMemberRepository memberRepository,
    IGatheringRepository gatheringRepository,
    IAttendeeRepository attendeeRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<AcceptInvitationCommand>
{
    public async Task<Unit> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
    {
        var gathering = await gatheringRepository
            .GetByIdWithCreatorAsync(request.GatheringId, cancellationToken);

        var invitation = gathering?.Invitations.FirstOrDefault(i => i.Id == request.InvitationId);

        if (invitation is null || invitation.Status != InvitationStatus.Pending)
        {   
            return Unit.Value;
        }
        
        var member = await memberRepository.GetByIdAsync(invitation.MemberId, cancellationToken);

        if (member is null || gathering is null)
        {
            return Unit.Value;
        }

        var attendeeResult = gathering.AcceptInvitation(invitation);

        if (attendeeResult.IsSuccess)
        {
            attendeeRepository.Add(attendeeResult.Value());
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}