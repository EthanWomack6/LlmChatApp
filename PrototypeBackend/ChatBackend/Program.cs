using ChatBackend.Services;
using ChatBackend.DTOs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ChatService>();

//url for lmstudio 
string? baseUrl = builder.Configuration["LMStudio:BaseUrl"];
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri(baseUrl!);
});
var app = builder.Build();





app.MapGet("/", () => "ChatBackend is running!");
//change chatservice to have a dependency injected through apiservice, and call it instead of apiservice
app.MapPost(
    //chatmessage request is the deserialized json, chatService is the object created by the dependancy injection container
    "/api/chat/messages", async (ChatMessageRequest request, ChatService chatService, CancellationToken cancellationToken = default) =>
{
   
    ChatMessageResponse response = await chatService.ProcessMessageAsync(request, cancellationToken);

    return Results.Ok(new
        {
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


app.MapPost("api/chat/completions", async (ApiService apiservice, IncomingMessage message, CancellationToken cancellationToken = default)=>
{   
    ChatCompletionResponse response = await apiservice.GetChatCompletionAsync(message, cancellationToken);

    List<string> chats = response.Choices.Select(model => model.Message.Content)
        .ToList();

    return Results.Ok(new
    {
        Response = chats
    });

});


app.Run();


