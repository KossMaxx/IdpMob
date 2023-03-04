using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;

namespace idp.Dal.Models.Relationships
{
    public class BeneficiaryConvoyProblems
    {
        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public int ConvoyProblemId { get; set; }
        public DProblem ConvoyProblem { get; set; }
    }
}
