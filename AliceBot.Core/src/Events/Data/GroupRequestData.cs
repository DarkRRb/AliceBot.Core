using AliceBot.Core.Messages;

namespace AliceBot.Core.Events.Data;

public class GroupRequestData(string requestId, string groupId, string userId, string message) {
    public string RequestId { get; } = requestId;

    public string GroupId { get; } = groupId;

    public string UserId { get; } = userId;

    public string Message { get; } = message;
}