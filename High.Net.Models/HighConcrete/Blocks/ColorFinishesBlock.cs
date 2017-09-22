using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;
using ImageVault.EPiServer;

namespace High.Net.Models.HighConcrete.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Color Finishes Block",
        GUID = "B90F4D10-BE9D-4FF1-B8F5-79BC09A5A6DA",
        Description = "Color Finishes Block",
        Order = 13050)]
    public class ColorFinishesBlock : HighConcreteBlockData
    {
        #region Image

        [Display(
            Name = "Color image (Width : 108 , Height : 108)",
            GroupName = Global.Tabs.Images,
            Description = "Image of color",
            Order = 1100)]
        public virtual MediaReference ColorImage { get; set; }

        #endregion

        #region Content

        [Display(
           Name = "ID",
           GroupName = Global.Tabs.Content,
           Description = "Id of image to display",
           Order = 2100)]
        public virtual String Id { get; set; }

        [Display(
           Name = "Color",
           GroupName = Global.Tabs.Content,
           Description = "select color of the image",
           Order = 2200)]
        [SelectOne(SelectionFactoryType = typeof(SelectColors))]
        public virtual string Color { get; set; }

        [Display(
          Name = "Texture / Exposure",
          GroupName = Global.Tabs.Content,
          Description = "select Texture / Exposure of the image",
          Order = 2300)]
        [SelectOne(SelectionFactoryType = typeof(SelectTexture))]
        public virtual string Texture { get; set; }

        [Display(
          Name = "Cast Pattern",
          GroupName = Global.Tabs.Content,
          Description = "select Cast Pattern of the image",
          Order = 2400)]
        [SelectOne(SelectionFactoryType = typeof(SelectCastPattern))]
        public virtual string CastPattern { get; set; }

        [Display(
          Name = "See Item",
          GroupName = Global.Tabs.Content,
          Description = "See Item",
          Order = 2500)]
        public virtual string SeeItem { get; set; }

        [Display(
         Name = "Logo",
         GroupName = Global.Tabs.Content,
         Description = "Logo",
         Order = 2600)]
        public virtual string Logo { get; set; }

        [Display(
           Name = "Description",
           GroupName = Global.Tabs.Content,
           Description = "Description of image",
           Order = 2700)]
        public virtual XhtmlString Description { get; set; }

        #endregion
    }
}