using Microsoft.AspNetCore.SignalR.Client;

namespace Gabfest.API;

public interface ISignalRConnection
{
    HubConnection StartConnection();
    bool IsConnected();
}
