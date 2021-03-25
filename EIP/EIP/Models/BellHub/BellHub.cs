using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.BellHub
{
    [HubName("bell")]
    public class BellHub : Hub
    {
        public void Send(string name, string message)   //新增佈告欄通知
        {

            Clients.All.Message(name, message);
        }
        public void Sendbulletinboardedit(string name) //佈告欄修改通知
        {

            Clients.All.Edit(name);
        }
        public void Sendbulletinboarddelete(string message) //佈告欄刪除通知
        {

            Clients.All.Delete(message);
        }
        public void SetHRADD(string GroupID)   //設定特定群組
        {
            Groups.Add(Context.ConnectionId, GroupID);
            Clients.Group(GroupID).addMessage("Welcome");
        }
        public void SendHRAdd(String GroupId, String Message)   //對特定群組發送通知
        {
            Clients.Group(GroupId).addMessage(Message);
        }
    }
}