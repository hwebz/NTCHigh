using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using EPiServer.Web;
using High.Net.Core;
using ImageVault.EPiServer;
using ImageVault.Client.Descriptors;
using ImageVault.Common.Data;

namespace High.Net.Models.Residential.Blocks
{
    [ContentType(GroupName = SiteGroups.BR, 
        DisplayName = "Floor-Plans Block",
        GUID = "935ec565-3a77-4ad7-af3a-f4a7a3c51e26",
        Description = "Block to display floor plans",
        Order = 5540)]
    public class FloorPlansBlock : ResidentialBlockData
    {
        #region content

        [Display(
            Name = "Floor Layout (Width : 179 , Height : 187)",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1100)]
        public virtual MediaReference FloorPlanLayout { get; set; }

        [Display(
            Name = "Rent",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1200)]
        public virtual String Rent { get; set; }

        [Display(
            Name = "Deposit",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1300)]
        public virtual String Deposit { get; set; }

        [Display(
            Name = "Plan PDF",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1400)]
        public virtual MediaReference PdfDocumnet { get; set; }

        [Display(
            Name = "Plan Size",
            Description = "",
            GroupName = Global.Tabs.Content,
            Order = 1500)]
        public virtual String PlanSize { get; set; }

        [Display(
            Name = "Beds/Bath SQ.",
            Description = "Beds/Bath SQ.",
            GroupName = Global.Tabs.Content,
            Order = 1600)]
        public virtual String BedsBathSq { get; set; }

        #endregion  

    }
}