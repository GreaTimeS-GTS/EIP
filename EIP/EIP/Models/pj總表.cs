//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EIP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pj總表
    {
        public int pjId { get; set; }
        public string pjName { get; set; }
        public string pjManager { get; set; }
        public string pjCreateId { get; set; }
        public string pjPlannedAndControl { get; set; }
        public string pjMeeting { get; set; }
        public string pjFinalReport { get; set; }
    
        public virtual pj建立 pj建立 { get; set; }
        public virtual pj控管 pj控管 { get; set; }
        public virtual pj結案 pj結案 { get; set; }
        public virtual pj會議 pj會議 { get; set; }
    }
}
