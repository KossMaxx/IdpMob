using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using idp.Dal.Models.Dictionaries;

namespace idp.App.Services.Contracts
{
    public interface IDictionaryService
    {
        Task<bool> SyncDictAsync();
        void GetDictionariesData();
        DOffice GetOffice(int id);
    }
}
