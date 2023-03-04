using System;
using System.Collections.Generic;
using System.Text;

namespace idp.App.Models
{
    public class LocalityReferenceDto : ReferenceDto
    {
        public int AreaId { get; set; }
        public int RegionId { get; set; }
    }
}
