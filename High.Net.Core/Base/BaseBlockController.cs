using System.Web.Mvc;
using System.Web.Security;
using EPiServer.Web.Mvc;

namespace High.Net.Core
{
    /// <summary>
    /// All controllers that renders pages should inherit from this class so that we can 
    /// apply action filters, such as for output caching site wide, should we want to.
    /// </summary>
    public abstract class BaseBlockController<T> : BlockController<T>
        where T : BaseBlockData
    {
       
    }
}
