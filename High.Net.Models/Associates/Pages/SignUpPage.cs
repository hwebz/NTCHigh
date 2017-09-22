using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;

namespace High.Net.Models.Associates.Pages
{
    [ContentType(
        GroupName = SiteGroups.HA,
        DisplayName = "SignUpPage",
        GUID = "eb499b64-456f-471b-b9a9-ce265a103c1a",
        Description = "This page will displayed after sign up",
        Order = 7080)]
    public class SignUpPage : AssociatesPageData
    {
       
    }
}