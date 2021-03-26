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
        public void Sendbulletinboardedit(string message) //佈告欄修改通知
        {
            var 通知 = new 通知
            {


            };
            Clients.All.Edit(message);
        }
        public void Deletebb(int 類別, string message) //佈告欄刪除通知
        {
            var 通知 = new 通知
            {
                通知類別id = 類別,
                通知內容 = message,
                讀取狀態 = "未讀"
            };
            db.通知.Add(通知);
            db.SaveChanges();
            var 通知類別轉換 = db.通知類別.FirstOrDefault(m => m.通知類別id == 類別);
            Clients.All.Delete(通知類別轉換.通知類別1, message);
        }
        public void SendGroup(string id,string Message,int check) //對特定群組發送通知  
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
        }
        public void Setgroup(int id)  //設定特定群組
        {
           var connectedID = db.個人資料.FirstOrDefault(c => c.EmployeeID == id);
            var 發送職稱 = connectedID.職稱;
            if (發送職稱 == "人事")
            {
                Groups.Add(Context.ConnectionId,"人事");
            }
            if (發送職稱 == "主管")
            {
                Groups.Add(Context.ConnectionId, "主管");
            }
            if (發送職稱 == "總經理")
            {
                Groups.Add(Context.ConnectionId, "總經理");
            }



        }
    }
}