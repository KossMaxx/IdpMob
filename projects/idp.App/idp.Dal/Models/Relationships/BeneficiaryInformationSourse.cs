using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;

namespace idp.Dal.Models.Relationships
{
    public class BeneficiaryInformationSourse
    {
        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public int InfomationSourceId { get; set; }
        public DInformationSource InfomationSource { get; set; }
    }
}
