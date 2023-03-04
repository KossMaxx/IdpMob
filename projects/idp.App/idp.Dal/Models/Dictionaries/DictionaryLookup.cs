using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace idp.Dal.Models.Dictionaries
{
    public class DictionaryLookup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

        [Required]
        public string Code { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
