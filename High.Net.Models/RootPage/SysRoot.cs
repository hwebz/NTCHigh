using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;

namespace High.Net.Models.RootPage
{
    [ContentType(DisplayName = "SysRoot", GUID = "3fa7d9e7-877b-11d3-827c-00a024cacfcb", Description = "")]
    public class SysRoot : PageData
    {

        [Display(
            Name = "EnableScheduleJobs",
            Description = "By clicking here it will allows you to exceute jobs",
            GroupName = Global.Tabs.AppSettings,
            Order = 1)]
        public virtual bool ExecuteScheduleJobs { get; set; }
        
    }
}