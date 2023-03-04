using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace idp.App.Services.Contracts
{
    public interface ILogService
    {
        Task WriteLog(Exception exception);
        Task DownloadLogs();
    }
}
