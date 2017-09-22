using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;

namespace High.Net.Core
{
    [ContentType( 
        DisplayName = "Container Page",
        GUID = "66211746-af4a-45f7-af88-4a2b56a4172f",
        Description = "")]
    [SiteImageUrl]
    public class ContainerPage : IContainerPage
    {
       
    }
}