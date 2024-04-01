﻿using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRhub:Hub
    {
        SignalRContext context=new SignalRContext();
        public async Task SendCategoryCount()
        {
         var values= context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount",values);
        }
    }
}