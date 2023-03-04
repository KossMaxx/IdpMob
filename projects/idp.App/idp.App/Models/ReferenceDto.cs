using System;
using System.Collections.Generic;
using System.Text;

namespace idp.App.Models
{
    public  class ReferenceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
