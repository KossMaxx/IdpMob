using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.App.Services.Contracts;
using Plugin.SimpleLogger;
using Xamarin.Forms;

namespace idp.App.Services
{
    public class LogService : ILogService
    {
        public async Task WriteLog(Exception exception)
        {
            var fileWorker = DependencyService.Get<IFileWorkerService>();
            var fileName = $"{DateTime.Today:dd.MM.yy}.log.txt";
            if (!await fileWorker.ExistsAsync(fileName))
            {
                await fileWorker.SaveTextAsync(fileName, $"Created IDP\n{DateTime.Now}-{exception?.Message}\n{exception?.StackTrace}");
            }
            else
            {
                var fileText = await fileWorker.LoadTextAsync(fileName);
                await fileWorker.SaveTextAsync(fileName, $"{fileText}\n\n{DateTime.Now}-{exception?.Message}\n{exception?.StackTrace}");
            }
        }

        public async Task DownloadLogs()
        {
            var fileWorker = DependencyService.Get<IFileWorkerService>();
            var logFilesList = await fileWorker.GetFilesAsync();
            var filesList = logFilesList.ToList();

            if (filesList.Any())
            {
                var logsText = new StringBuilder();
                foreach (var file in filesList)
                {
                    var fileText = await fileWorker.LoadTextAsync(file);
                    logsText.Append($"{fileText}\n\n");
                    await fileWorker.DeleteAsync(file);
                }

                logsText.Append($"==============================================\n{CrossSimpleLogger.Current.GetAllLogContent()}\n==============================================\n\n");

                await fileWorker.DownLoadFileAsync(logsText.ToString());
            }
        }
    }
}
