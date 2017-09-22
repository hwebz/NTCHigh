using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;

namespace High.Net.Models.Rollover.Blocks
{
    [ContentType(GroupName = SiteGroups.RO, Order = 11060, DisplayName = "Portfolio Listing Block", GUID = "03047d3e-2a45-446a-9648-f5ea81fd6380", Description = "")]
    public class PortfolioListingBlock : RolloverBlockData
    {
        
    }
}