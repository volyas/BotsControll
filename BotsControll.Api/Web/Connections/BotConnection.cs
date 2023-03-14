﻿using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BotsControll.Core.Identity;

namespace BotsControll.Api.Web.Connections;

public class BotConnection
{
    public WebSocket Connection { get; }

    // todo: nullable must be removed in future versions
    // now nullable just gag
    public IBotIdentity? Bot { get; }

    public BotConnection(WebSocket connection)
    {
        Connection = connection;
        Bot = null;
    }

    public async Task SendAsync(string message)
    {
        await Connection.SendAsync(
            buffer: new ArraySegment<byte>(
                array: Encoding.ASCII.GetBytes(message),
                offset: 0,
                count: message.Length
            ),
            messageType: WebSocketMessageType.Text,
            endOfMessage: true,
            cancellationToken: CancellationToken.None
        );
    }
}