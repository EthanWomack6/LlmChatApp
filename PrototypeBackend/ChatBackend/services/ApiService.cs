namespace ChatBackend.Services; 
using ChatBackend.DTOs;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Linq;



public class ApiService
{

//so that  program.c can inject a client into here
private readonly HttpClient _client;



//constructor
public ApiService(HttpClient client)
    {
        _client = client;
    }



//to unwrap the outer string




//method used to ask what models exist
public async Task<ModelResponse> GetModelAsync(CancellationToken cancellationToken)

    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        //lets the jsonserialiozer be case insensitive

        using HttpResponseMessage response = await _client.GetAsync("models",cancellationToken);

        response.EnsureSuccessStatusCode();

        string stringResponse = await response.Content.ReadAsStringAsync(cancellationToken);
        Console.WriteLine(stringResponse);

        ModelResponse? result = JsonSerializer.Deserialize<ModelResponse>(stringResponse, options);
        
        if (result == null || result?.Data ==null)
        {
            throw new InvalidOperationException("lmstudio returned null");
        }

        return result;
        
    }


//sending to and receiving message from the llm
public async Task<ChatCompletionResponse> GetChatCompletionAsync(IncomingMessage message, CancellationToken cancellationToken)
    {   
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
         //creates the object to send to the llm
        var FirstMessage = new ChatCompletionMessage(
            Role: "system",
            Content: "you are a helpful assistant"

        );
        var SecondMessage = new ChatCompletionMessage(
            Role: "user",
            Content: message.Prompt

        ); 

        List<ChatCompletionMessage> Messages = new List<ChatCompletionMessage>();
        Messages.Add(FirstMessage);
        Messages.Add(SecondMessage);

        var requestObject = new ChatCompletionRequest(
            Model: message.Model,
            Messages: Messages,
            Stream: false
        );


        //returns the message 
         using HttpResponseMessage response = await _client.PostAsJsonAsync("chat/completions", requestObject, cancellationToken);
         response.EnsureSuccessStatusCode();
         string stringResponse = await response.Content.ReadAsStringAsync(cancellationToken);

         ChatCompletionResponse? result = JsonSerializer.Deserialize<ChatCompletionResponse>(stringResponse, options);

        //catches any null response, .Any means that any choice->message->content catches on null
         if (result == null || result.Choices is null or [] || result.Choices.Any(choice => choice?.Message?.Content is null))
        {
            throw new InvalidOperationException("lmstudio returned null");
        }
        
        return result;
    }

}
