﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbEIPEntities : DbContext
    {
        public dbEIPEntities()
            : base("name=dbEIPEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MeetingRoom> MeetingRoom { get; set; }
        public virtual DbSet<MeetingRoomBooking> MeetingRoomBooking { get; set; }
        public virtual DbSet<pjAdvice> pjAdvice { get; set; }
        public virtual DbSet<pjHandOverList> pjHandOverList { get; set; }
        public virtual DbSet<pjMeeting> pjMeeting { get; set; }
        public virtual DbSet<pjOverall> pjOverall { get; set; }
        public virtual DbSet<pjProject> pjProject { get; set; }
        public virtual DbSet<pjReport> pjReport { get; set; }
        public virtual DbSet<pjTeam> pjTeam { get; set; }
        public virtual DbSet<pj建立> pj建立 { get; set; }
        public virtual DbSet<pj控管> pj控管 { get; set; }
        public virtual DbSet<pj結案> pj結案 { get; set; }
        public virtual DbSet<pj進度表> pj進度表 { get; set; }
        public virtual DbSet<pj會議> pj會議 { get; set; }
        public virtual DbSet<pj會議記錄> pj會議記錄 { get; set; }
        public virtual DbSet<pj團隊> pj團隊 { get; set; }
        public virtual DbSet<pj總表> pj總表 { get; set; }
        public virtual DbSet<出差細項> 出差細項 { get; set; }
        public virtual DbSet<加班別> 加班別 { get; set; }
        public virtual DbSet<加班細項> 加班細項 { get; set; }
        public virtual DbSet<打卡系統> 打卡系統 { get; set; }
        public virtual DbSet<行事曆> 行事曆 { get; set; }
        public virtual DbSet<佈告欄> 佈告欄 { get; set; }
        public virtual DbSet<表單類別> 表單類別 { get; set; }
        public virtual DbSet<個人資料> 個人資料 { get; set; }
        public virtual DbSet<通知> 通知 { get; set; }
        public virtual DbSet<通知類別> 通知類別 { get; set; }
        public virtual DbSet<假別> 假別 { get; set; }
        public virtual DbSet<請假細項> 請假細項 { get; set; }
    }
}
