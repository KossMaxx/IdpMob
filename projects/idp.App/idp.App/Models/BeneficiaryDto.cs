using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;
using idp.Dal.Models.Enums;

namespace idp.App.Models
{
    public class BeneficiaryDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime PollDate { get; set; }
        public string CreatorName { get; set; }
        public string Fio { get; set; }
        public Sex Sex { get; set; }
        public DAgeCategory DAgeCategory { get; set; }
        public string ContactPhoneMain { get; set; }
        public string ProblemDescription { get; set; }
        public string BeneficiaryHelpForms { get; set; }
        public string SyncError { get; set; }
    }
}
