using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TflRestApi.Logic
{
    public interface ITflApiServices
    {
        string GetDisplayName(string roadId);
        string GetStatusSeverity(string roadId);
        string GetStatusSeverityDescription(string roadId);
        string GetMessage(string roadId);
        int GetHttpStatusCode(string roadId);
        string GetHttpStatus(string roadId);


    }
}
