using System.Threading;
using System.Threading.Tasks;
using AliceBot.Core.Actions.Results;
using AliceBot.Core.Messages;

namespace AliceBot.Core.Actions;

public interface IActions {
    public Task<GetSelfInfoResult> GetSelfInfo(CancellationToken token);

    // Message
    public Task<SendPrivateMessageResult> SendPrivateMessageAsync(string userId, MessageContent message, CancellationToken token);

    public Task<SendGroupMessageResult> SendGroupMessageAsync(string groupId, MessageContent message, CancellationToken token);

    public Task RecallMessageAsync(string messageId, CancellationToken token);

    // Request
    public Task SetGroupRequestAsync(string requestId, CancellationToken token);
}