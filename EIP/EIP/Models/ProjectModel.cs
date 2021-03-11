using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models
{
    public class ProjectModel
    {
        dbEIPEntities dbEIP = new dbEIPEntities();

        public IEnumerable<工作清單> GetAllMember()
        {
            return dbEIP.工作清單;
        }




    }
}