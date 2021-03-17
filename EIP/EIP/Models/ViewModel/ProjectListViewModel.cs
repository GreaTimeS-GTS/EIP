using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class ProjectListViewModel
    {
        public int EmploryeeID { get; set; }

        public string 專案歸類 { get; set; }

        public string 重要性 { get; set; }

        public string 事項名稱 { get; set; }

        public string 回報狀況 { get; set; }

        public string 完成度 { get; set; }

        public string 交辦人 { get; set; }

        public string 完成日 { get; set; }

        public string 專案內容 { get; set; }


        public string 專案建立日期 { get; set; }
    }
}