using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace idp.Dal.Models.Dictionaries
{
    public class DAgeCategory : DictionaryLookup
    {
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }

    }
}
