using System;
using System.Collections.Generic;
using System.Text;
using idp.Dal.Models.Dictionaries;

namespace idp.App.Models
{
    public class LookupModelOther
    {
        public LookupModelOther()
        {
            SelectedIds = new int[0];
            SelectedCodes = new string[0];
            LookupItems = new DictionaryLookup[0];
        }
        public int[] SelectedIds { get; set; }
        public string[] SelectedCodes { get; set; }
        public DictionaryLookup[] LookupItems { get; set; }
        public string OtherValue { get; set; }
    }
}
