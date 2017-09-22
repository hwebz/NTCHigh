using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Core;

namespace High.Net.Models.RealEstateGroup.Blocks
{
    [ContentType(GroupName = SiteGroups.REG,
        DisplayName = "Project Portfolio Block",
        GUID = "F2E17933-D9AB-4C7E-B395-4BB586CE6814",
        Description = "Project Portfolio Block",
        Order = 8060)]
    public class ProjectPortfolioBlock : RealEstateGroupBlockData
    {
        #region Content

        [Display(Name = "Building Id", Order = 1)]
        public virtual string BuildingId { get; set; }

        [Display(Name = "Building Name Address", Order = 100)]
        public virtual string BuildingNameAddress { get; set; }

        [Display(Name = "Portfolio Project", Order = 200)]
        public virtual string PortfolioProject { get; set; }

        [Display(Name = "Total Sqft", Order = 300)]
        public virtual string TotalSqft { get; set; }

        [Display(Name = "Asset Manager", Order = 400)]
        public virtual string AssetManager { get; set; }

        #endregion
    }
}