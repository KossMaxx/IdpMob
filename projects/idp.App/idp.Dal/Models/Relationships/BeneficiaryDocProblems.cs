using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;

namespace idp.Dal.Models.Relationships
{
    public class BeneficiaryDocProblems
    {
        public int BeneficiaryId { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public int DocProblemId { get; set; }
        public DProblem DocProblem { get; set; }
    }
}
