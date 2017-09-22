using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.Rollover.Blocks
{
    [ContentType(
        GroupName = SiteGroups.RO, 
        Order = 11070, 
        DisplayName = "Commercial MultiFamily", 
        GUID = "102539A8-62FE-4D6F-8346-5F5DD718C057",
        Description = "This block contains Commercial MultiFamily")]
    public class CommercialMultiFamily : RolloverBlockData
    {
        
    }
}