using High.Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace High.Net.Web.Controllers.HighHotels
{
    public class HighHotelsController<T> : BasePageController<T>
         where T : BasePageData
    {

    }
}