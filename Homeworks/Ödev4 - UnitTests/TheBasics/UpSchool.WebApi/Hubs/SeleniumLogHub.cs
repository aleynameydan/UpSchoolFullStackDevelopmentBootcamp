using Microsoft.AspNetCore.SignalR;
using UpSchool.Domain.Dtos;

namespace UpSchool.WebApi.Hubs;

public class SeleniumLogHub : Hub
{
    //buraya yazılan methodlar clientların çalıştıracağı methodlar -->selenium, console, blazor --> server dışındaki her şey

    public async Task SendLogNotificationAsync(SeleniumLogDto log)
    {
        //istek gönderen kişi harici herkese bu mesajı geç.
        await Clients.AllExcept(Context.ConnectionId).SendAsync("NewSeleniumLogAdded",log);
    }
}