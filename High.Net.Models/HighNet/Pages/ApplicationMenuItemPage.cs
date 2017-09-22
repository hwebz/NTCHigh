using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.HighNet.Pages
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Application Menu Item",
        GUID = "DDF37F3D-2C3F-420B-B3C9-06AC87B8C7AA",
        Description = "Menu item for running application form",
        Order = 10050)]
    public class ApplicationMenuItemPage: BasePageData,IContainerPage
    {

    }
}
