using System.Collections.Generic;

namespace idp.Dal.Models.Dictionaries
{
    public class DActivityForm : DictionaryLookup
    {
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
    }
}
