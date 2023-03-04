using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;

namespace idp.Dal.Models.Relationships
{
    public class BeneficiaryNotLawHelp
    {
        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public int NotLawHelpId { get; set; }
        public DNotLawHelp NotLawHelp { get; set; }
    }
}
