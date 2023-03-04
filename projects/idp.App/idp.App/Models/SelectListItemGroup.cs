using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace idp.App.Models
{
    public class SelectListItemGroup<K,T> : List<T>
    {
        public K GroupName { get; private set; }
        public SelectListItemGroup(K name, List<T> group) : base(group)
        {
            GroupName = name;
        }
    }
}
