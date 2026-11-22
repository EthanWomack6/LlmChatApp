namespace ChatBackend.DTOs;


public record ModelInfo(
    string Id
);
public record ModelResponse (List<ModelInfo> Data);


public record ChatMessageRequest(
    int ConversationId,
    string Content
);
