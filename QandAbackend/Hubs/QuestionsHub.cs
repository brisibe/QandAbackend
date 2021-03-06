﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QandAbackend.Hubs 
{
    public class QuestionsHub : Hub
    {//not fully implemented
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Caller.SendAsync("Message", "Successfully connected");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.Caller.SendAsync("Message", "Successfully disconnected");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SubscribeQuestion(int questionId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"Question-{questionId}");
            await Clients.Caller.SendAsync("Message", "Successfully subscribed");

        }



        public async Task UnSubscribeQuestion(int questionId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"Question-{questionId}");
            await Clients.Caller.SendAsync("Message", "Successfully Unsubscribeed");
            
        }

    }
}
