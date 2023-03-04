using System;
using System.Collections.Generic;
using System.Text;

namespace idp.App.Models
{
    public class BeneficiariesSynchronizationResponse
    {
        public List<int> SuccessSyncIds { get; set; } = new List<int>();
        public List<FailSyncBeneficiary> FailBeneficiaries { get; set; } = new List<FailSyncBeneficiary>();
        public int CreatedContacts { get; set; } = 0;
    }
}
