namespace ChatBackend.Services; 
using ChatBackend.DTOs;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Linq;

public class ApiService
{

//so that program.c can inject a client into here
private readonly HttpClient _client;
//constructor
public ApiService(HttpClient client)
    {
        _client = client;
    }



//to unwrap the outer string





public async Task<ModelResponse> GetModelAsync(CancellationToken cancellationToken)
    {
        //lets the jsonserialiozer be case insensitive
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        using HttpResponseMessage response = await _client.GetAsync("http://127.0.0.1:1234/v1/models",cancellationToken);

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

}
