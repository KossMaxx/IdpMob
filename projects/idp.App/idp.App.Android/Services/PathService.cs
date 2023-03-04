using System;
using System.IO;
using Xamarin.Forms;
using idp.App.Droid.Services;
using idp.App.Services.Contracts;

[assembly: Dependency(typeof(PathService))]
namespace idp.App.Droid.Services
{
    public class PathService : IPathService
    {
        private string GetCustomFilePath(string folder, string filename)
        {
            var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libFolder = Path.Combine(docFolder, folder);
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);

        }

        public string GetDatabaseFilePath(string filename)
        {
            return this.GetCustomFilePath("Databases", filename);
        }
    }
}