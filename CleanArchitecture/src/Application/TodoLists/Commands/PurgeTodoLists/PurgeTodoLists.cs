using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Domain.Constants;

namespace CleanArchitecture.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTodoListsCommand : IRequest;

public class PurgeTodoListsCommandHandler(IApplicationDbContext context) : IRequestHandler<PurgeTodoListsCommand>
{
    public async Task Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        context.TodoLists.RemoveRange(context.TodoLists);

        await context.SaveChangesAsync(cancellationToken);
    }
}
