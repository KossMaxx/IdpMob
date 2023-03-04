

namespace idp.Dal.Models.Dictionaries
{
    public class DArea : DictionaryLookup
    {
        public string GetCode()
        {
            return Name.Substring(0, 2);
        }
    }
}
