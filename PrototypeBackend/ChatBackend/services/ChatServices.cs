//organizes class into a namespace for consistent access to its specific functions
namespace ChatBackend.Services;
using ChatBackend.DTOs;


public class ChatService
{
    private readonly ApiService _apiService;
    public ChatService(ApiService apiService)
    {
        _apiService = apiService;
    }
    //the service function
    public async Task<ChatMessageResponse> ProcessMessageAsync(ChatMessageRequest request, CancellationToken cancellationToken)
    {           

            var message = new  IncomingMessage(
                Prompt: request.Content,
                Model: request.Model
                
            );

            //gets return of 
            ChatCompletionResponse response = await _apiService.GetChatCompletionAsync(message, cancellationToken);

            

            List<string> chats = response.Choices
                .Select(model => model.Message.Content)
            .ToList();

            var answer = new ChatMessageResponse(
                Model: message.Model,
                ConversationId: request.ConversationId,
                Content: chats[0]
            );

        return answer;
    }
}