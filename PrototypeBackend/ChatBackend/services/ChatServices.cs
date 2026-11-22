//organizes class into a namespace for consistent access to its specific functions
namespace ChatBackend.Services;

//class defines its service
public class ChatService
{
    //the service function
    public async Task<string> ProcessMessageAsync(string message, CancellationToken cancellationToken)
    {   
        //returns the message 
        await Task.Delay(1000, cancellationToken);
        return $"You said: {message}";
    }
}