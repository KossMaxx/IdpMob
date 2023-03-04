using idp.Dal.Models.Enums;

namespace idp.Dal.Models.Dictionaries
{
    public class DRegion : DictionaryLookup
    {
        public TerritoryControlSign TerritoryControl { get; set; }

        public int AreaId { get; set; }
        public virtual DArea Area { get; set; }

        public string NameWithTerritoryControl()
        {
            return $"{Name} ({TerritoryControl.ToString()})";
        }
    }
}
