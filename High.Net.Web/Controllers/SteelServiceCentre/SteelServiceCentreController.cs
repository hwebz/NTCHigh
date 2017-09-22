using High.Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace High.Net.Web.Controllers.SteelServiceCentre
{
    public class SteelServiceCentreController<T> : BasePageController<T>
          where T : BasePageData
    {
    }
}