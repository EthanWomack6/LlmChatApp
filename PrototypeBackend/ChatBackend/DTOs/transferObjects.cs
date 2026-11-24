namespace ChatBackend.DTOs;


public record ModelInfo(
    string Id
);
public record ModelResponse (List<ModelInfo> Data);


public record ChatMessageRequest(
    int ConversationId,
    string Content,
    string Model
);
public record ChatMessageResponse(
    int ConversationId,
    string Content,
    string Model
);


public record ChatCompletionRequest(
    string Model,
    List<ChatCompletionMessage> Messages,
    bool Stream
);


public record ChatCompletionMessage(
    string Role,
    string Content
);

public record IncomingMessage
(
    string Model,
    string Prompt
);


public record ChatCompletionChoice(
    int Index, 
    ChatCompletionMessage Message
);

public record ChatCompletionResponse(
    string Model,
    List<ChatCompletionChoice> Choices
);




