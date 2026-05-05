namespace Cognilingo.Application.Simulations.Queries.ListSimulationMessages;

public sealed class ListSimulationMessagesQueryHandler(
    IAppDbContext context
) : IRequestHandler<ListSimulationMessagesQuery, Response<IEnumerable<ListSimulationMessageDto>>>
{
    public async Task<Response<IEnumerable<ListSimulationMessageDto>>> Handle(
        ListSimulationMessagesQuery request,
        CancellationToken cancellationToken
    )
    {
        var messages = await context.Simulations
            .AsNoTracking()
            .Where(s => s.Id == request.SimulationId)
            .SelectMany(s => s.Messages)
            .OrderBy(m => m.CreatedAt)
            .Select(m => new ListSimulationMessageDto
            {
                Id = m.Id,
                Sender = m.Sender,
                Content = m.Content,
                TranslatedContent = m.TranslatedContent,
                Feedback = m.Feedback != null
                    ? new ListSimulationMessageFeedbackDto
                    {
                        Classification = m.Feedback.Classification,
                        Explanation = m.Feedback.Explanation,
                        Correction = m.Feedback.Correction
                    }
                    : null
            })
            .ToListAsync(cancellationToken);

        return new OkResponse<IEnumerable<ListSimulationMessageDto>>(messages);
    }
}