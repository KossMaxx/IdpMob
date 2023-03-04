namespace idp.Dal.Models.Dictionaries
{
    public class DOffice : DictionaryLookup
    {
        public int? BenStartNo { get; set; }
        public int AreaId { get; set; }
        public virtual DArea Area { get; set; }
    }
}
