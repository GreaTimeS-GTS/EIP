using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class LoginViewModel
    {
        public int EmployeeID { get; set; }
        [DisplayName("員工密碼")]
        [Required(ErrorMessage = "請輸入員工密碼")]
        public string EmployeePW { get; set; }
        public string 受雇日期 { get; set; }
        public string 中文姓名 { get; set; }
        public string 英文姓名 { get; set; }
        public string 職稱 { get; set; }
        public string 狀態 { get; set; }
        public string 部門 { get; set; }
        public string 性別 { get; set; }
        public string 出生年月日 { get; set; }
        [DisplayName("員工帳號")]
        [Required(ErrorMessage = "請輸入員工帳號")]
        public string 信箱 { get; set; }
        public string 電話 { get; set; }
        public string 居住地 { get; set; }
        public string 婚姻狀況 { get; set; }
        public string 年資 { get; set; }
        public string 薪資 { get; set; }
        public string 特休 { get; set; }
        public string RememberMe { get; set; }
    }
}