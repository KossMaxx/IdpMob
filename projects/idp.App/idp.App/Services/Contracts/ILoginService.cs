using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace idp.App.Services.Contracts
{
    public interface ILoginService
    {
        Task<bool> OffLineLoginAsync(string username, string password);
        Task<bool> OnLineLoginAsync(string username, string password);
    }
}
