using System.Collections.Generic;

namespace idp.Dal.Models.Dictionaries
{
    public class DLivingPlace : DictionaryLookup
    {
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
    }
}
