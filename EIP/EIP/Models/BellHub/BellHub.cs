using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EIP.Models.BellHub
{
    [HubName("bell")]
    public class BellHub : Hub
    {
        dbEIPEntities db = new dbEIPEntities();
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        public void Send(string 職稱, string message)   //新增佈告欄通知
        {

            Clients.All.Message(職稱, message);
        }
        public void Sendbulletinboardedit(string name) //佈告欄修改通知
        {

            Clients.All.Edit(name);
        }
        public void Sendbulletinboarddelete(string message) //佈告欄刪除通知
        {

            Clients.All.Delete(message);
        }
        public void identityGroup(string id,string Message,int check)   //設定特定群組
        {
            var f =db.個人資料.Find(id);
            if(f.職稱 == "人事")
            {         
            Clients.Group("人事").addMessage(f.職稱, Message);
            Clients.Group("主管").addMessage(f.職稱, Message);
            Clients.Group("總經理").addMessage(f.職稱, Message);//addMessage=前端的function(自定義)
            }
            if(f.職稱 == "主管")
            {
            Clients.Group("主管").addMessage(f.職稱, Message);
            Clients.Group("總經理").addMessage(f.職稱, Message);
            }
            var 通知 = new 通知
            {
               
            };
        }
        public void SendHRAdd(String GroupId, String Message)   //對特定群組發送通知
        {
            Clients.Group(GroupId).addMessage(Message);
        }

        public void group(int id)
        {
           var connectedID = db.個人資料.FirstOrDefault(c => c.EmployeeID == id);
            var 發送職稱 = connectedID.職稱;
            if (發送職稱 == "人事")
            {
                Groups.Add(Context.ConnectionId,"人事");
            }
            if (發送職稱 == "主管")
            {
                Groups.Add(Context.ConnectionId, "人事");
                Groups.Add(Context.ConnectionId, "主管");
            }
          
        }
    }
}