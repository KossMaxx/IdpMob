using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;

namespace idp.Dal.Models.Relationships
{
    public class BeneficiaryHelpForm
    {
        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public int HelpId { get; set; }
        public DHelpForm Help { get; set; }
    }
}
