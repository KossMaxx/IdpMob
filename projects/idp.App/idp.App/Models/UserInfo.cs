using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;

namespace idp.App.Models
{
    public class UserInfo
    {
        public string Fio { get; set; }
        public DOffice Office { get; set; }
    }
}
