using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Shared.Pages
{
    [ContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Container Page",
        Order=5,
        GUID = "6D196D29-F1F0-4409-A7DD-718F8E2475F9",
        Description = "")]
    public class ContainerPage : BasePageData, IContainerPage
    {
       
    }
}