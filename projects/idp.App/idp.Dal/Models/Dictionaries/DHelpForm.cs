using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idp.Dal.Models.Dictionaries
{
    public class DHelpForm : DictionaryLookup
    {
        public static string CODE_CASE = "PU";
        public static string CODE_IPA = "MD";
        public static string CODE_RED = "ZP";

        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
    }
}
