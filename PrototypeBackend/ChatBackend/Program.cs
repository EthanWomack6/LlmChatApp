using ChatBackend.Services;
using ChatBackend.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ChatService>();


builder.Services.AddHttpClient<ApiService>();



var app = builder.Build();



app.MapGet("/", () => "ChatBackend is running!");

app.MapPost(
    //chatmessage request is the deserialized json, chatService is the object created by the dependancy injection container
    "/api/chat/messages", async (ChatMessageRequest request, ChatService chatService, CancellationToken cancellationToken = default) =>
{
   
    string response = await chatService.ProcessMessageAsync(request.Content, cancellationToken);

    return Results.Ok(new
        {
            ConversationId = request.ConversationId,
            Response = response
        });

});

app.MapGet("api/models", async (ApiService apiservice, CancellationToken cancellationToken = default)=>
{
    ModelResponse response = await apiservice.GetModelAsync(cancellationToken);
     List<string> ids = response.Data.Select(model => model.Id)
        .ToList();

    return Results.Ok(new
    {
        Models = ids

    });

});







app.Run();


