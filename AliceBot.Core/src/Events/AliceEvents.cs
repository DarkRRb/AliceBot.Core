using System;
using AliceBot.Core.Events.Data;
using AliceBot.Core.Protocols;

namespace AliceBot.Core.Events;

public class AliceEvents : IProtocolEvents {
    public event Action? OnAliceStarted;

    public event Action? OnAliceStopped;

    public event Action<IProtocol, PrivateMessageData>? OnPrivateMessage;

    public event Action<IProtocol, GroupMessageData>? OnGroupMessage;

    public event Action<IProtocol, GroupRequestData>? OnGroupRequest;

    // Alice
    internal void EmitAliceStarted() {
        OnAliceStarted?.Invoke();
    }

    internal void EmitAliceStopped() {
        OnAliceStopped?.Invoke();
    }

    // Message
    private void EmitPrivateMessage(IProtocol protocol, PrivateMessageData data) {
        OnPrivateMessage?.Invoke(protocol, data);
    }

    private void EmitGroupMessage(IProtocol protocol, GroupMessageData data) {
        OnGroupMessage?.Invoke(protocol, data);
    }

    private void EmitGroupRequest(IProtocol protocol, GroupRequestData data) {
        OnGroupRequest?.Invoke(protocol, data);
    }

    internal void Aggregate(IProtocolEvents events) {
        events.OnPrivateMessage += EmitPrivateMessage;
        events.OnGroupMessage += EmitGroupMessage;
        events.OnGroupRequest += EmitGroupRequest;
    }

    internal void Disaggregate(IProtocolEvents events) {
        events.OnPrivateMessage -= EmitPrivateMessage;
        events.OnGroupMessage -= EmitGroupMessage;
        events.OnGroupRequest -= EmitGroupRequest;
    }
}