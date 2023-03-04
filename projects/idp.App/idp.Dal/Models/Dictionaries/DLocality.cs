using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using idp.Dal.Models.Enums;

namespace idp.Dal.Models.Dictionaries
{
    public class DLocality : DictionaryLookup
    {
        public string UNHCRInterventionZone { get; set; }

        public TerritoryControlSign TerritoryControl { get; set; }

        public int AreaId { get; set; }
        
        public virtual DArea Area { get; set; }

        public int RegionId { get; set; }

        public virtual DRegion Region { get; set; }

        public string GetNameWithControlAttr()
        {
            return $"{Name} ({TerritoryControl.ToString()})/ {UNHCRInterventionZone} {Code}";
        }

    }
}
