namespace Cognilingo.Application.Simulations.Commands.SendMessage;

public sealed class SendMessageCommandHandler(
    IAppDbContext context,
    IRequestContext requestContext,
    IChatCompletionService chatCompletionService,
    IMessageFeedbackService messageFeedbackService
) : IRequestHandler<SendMessageCommand, Response>
{
    public async Task<Response> Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        var simulation = await context.Simulations
            .Include(s => s.Messages)
            .Include(s => s.Variant)
            .FirstOrDefaultAsync(
                s => s.Id == request.SimulationId && s.UserId == requestContext.UserId.Value,
                cancellationToken
            );

        if (simulation is null)
            return new NotFoundResponse(SimulationMessages.SimulationNotFound);

        var history = simulation.Messages
            .Select(m => new Message(m.Sender, m.Content))
            .ToList();

        var userMessage = simulation.AddUserMessage(request.Content);

        var chatTask = chatCompletionService.GenerateResponseAsync(
            new ChatRequest(
                History: history,
                SystemPrompt: simulation.Variant.PromptInstructions,
                UserMessage: request.Content
            ),
            cancellationToken
        );

        var feedbackTask = messageFeedbackService.GenerateFeedbackAsync(
            new FeedbackRequest(
                History: history,
                LanguageCode: simulation.Variant.LearningLanguage,
                UserMessage: request.Content
            ),
            cancellationToken
        );

        await Task.WhenAll(chatTask, feedbackTask);

        var chatResponse = await chatTask;
        var feedbackResponse = await feedbackTask;

        userMessage.SetFeedback(
            new SimulationMessageFeedback(
                classification: feedbackResponse.Classification,
                explanation: feedbackResponse.Explanation,
                correction: feedbackResponse.Correction
            )
        );

        simulation.AddAssistantMessage(chatResponse.AssistantResponse);

        await context.SaveChangesAsync(cancellationToken);

        return new NoContentResponse();
    }
}