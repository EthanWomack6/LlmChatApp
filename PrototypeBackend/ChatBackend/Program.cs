using ChatBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ChatService>();



var app = builder.Build();



app.MapGet("/", () => "ChatBackend is running!");

app.MapPost(
    //chatmessage request is the deserialized json, chatService is the dependancy injection container
    "/api/chat/messages", (ChatMessageRequest request, ChatService chatService) =>
{
   
    string response = chatService.ProcessMessage(request.Content);

    return Results.Ok(new
        {
            ConversationId = request.ConversationId,
            Response = response
        });




});

app.Run();

public record ChatMessageRequest(
    int ConversationId,
    string Content
);