//organizes class into a namespace for consistent access to its specific functions
namespace ChatBackend.Services;

//class defines its service
public class ChatService
{
    //the service function
    public string ProcessMessage(string message)
    {   
        //returns the message 
        return $"You said: {message}";
    }
}