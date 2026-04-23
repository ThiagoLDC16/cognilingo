namespace Cognilingo.Application.Simulations.Commands.SendMessage;

public sealed class SendMessageCommandHandler(
    IAppDbContext context,
    IRequestContext requestContext
) : IRequestHandler<SendMessageCommand, Response>
{
    public async Task<Response> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var simulation = await context.Simulations
            .Include(s => s.Messages)
            .FirstOrDefaultAsync(s => s.Id == request.SimulationId && s.UserId == requestContext.UserId, cancellationToken);

        if (simulation is null)
            return new NotFoundResponse(SimulationMessages.SimulationNotFound);
        
        simulation.AddUserMessage(request.Content);
        
        // TODO: Chamar IA para gerar feedback e resposta
        // Por enquanto, apenas salvamos a mensagem do usuário conforme a regra do domínio.

        await context.SaveChangesAsync(cancellationToken);

        return new NoContentResponse();
    }
}
