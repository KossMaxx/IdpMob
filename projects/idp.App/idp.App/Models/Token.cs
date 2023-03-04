using System;
using System.Collections.Generic;
using System.Text;

namespace idp.App.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string access_token { get; set; }
        public DateTime expires_in { get; set; }
    }
}
