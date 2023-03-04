using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace idp.App.Services.Contracts
{
    public interface IHttpService
    {
        event Action UnauthorizedRequest;
        Task<string> PostAsync(string url, string jsonData);
        string Post(string url, string jsonData);
        Task<string> GetAsync(string url);
        string Get(string url);
        Task<string> LoginAsync(string userName, string password);
        Task CheckConnectionWithServerAsync();
    }
}
