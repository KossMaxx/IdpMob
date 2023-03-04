using System.Collections.Generic;

namespace idp.Dal.Models.Dictionaries
{
    public class DVpoOrVictimOfConflict : DictionaryLookup
    {
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
    }
}
