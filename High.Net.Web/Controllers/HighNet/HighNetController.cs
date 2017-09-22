using High.Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace High.Net.Web.Controllers.HighNet
{
    public class HighNetController<T> : BasePageController<T>
         where T : BasePageData
    {

    }
}