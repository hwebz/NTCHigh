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
        Order = 11080,
        DisplayName = "Residential MultiFamily",
        GUID = "887A87B4-050F-4BC1-903B-184BA6AAD81F",
        Description = "This block contains Residential MultiFamily")]
    public class ResidentialMultiFamily : RolloverBlockData
    {

    }
}