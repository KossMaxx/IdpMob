using System;
using System.Collections.Generic;
using System.Text;

namespace idp.App.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Fio { get; set; }
        public int? OfficeId { get; set; }
    }
}
