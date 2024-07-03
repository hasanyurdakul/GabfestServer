using Microsoft.AspNetCore.SignalR.Client;

namespace Gabfest.API;

public class SignalRConnection : ISignalRConnection
{
    HubConnection _connection;

    public bool IsConnected()
    {
        return _connection != null && _connection.State == HubConnectionState.Connected;
    }

    public HubConnection StartConnection()
    {
        var hostInfo = "http://localhost:5243";
        if (_connection != null && _connection.State == HubConnectionState.Connected)
        {
            return _connection;
        }
        _connection = new HubConnectionBuilder()
            .WithUrl($"{hostInfo}/gabfesthub")
            .WithKeepAliveInterval(TimeSpan.FromDays(1))
            .WithServerTimeout(TimeSpan.FromDays(1))
            .WithAutomaticReconnect()
            .Build();

        if (_connection.State == HubConnectionState.Disconnected)
        {
            _connection.StartAsync();
        }
        return _connection;
    }
}
