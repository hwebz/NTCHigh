using System.Collections.Generic;

namespace High.Net.Web.Business.Services
{
    public interface ILogFileService
    {
        IEnumerable<LogFileItem> LogFiles();
        string ReadFile(LogFileItem item);
        string PhysicalPathTo(LogFileItem item = null);
    }
}