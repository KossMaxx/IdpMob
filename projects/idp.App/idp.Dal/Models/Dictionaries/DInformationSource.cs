using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idp.Dal.Models.Dictionaries
{
    public class DInformationSource : DictionaryLookup
    {
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
    }
}
