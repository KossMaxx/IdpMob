using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using idp.App.Models;

namespace idp.App.Infrastructure
{
    public static class EnumHelpers
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this Type type, T? en)
            where T : struct
        {
            if (!type.IsEnum)
                throw new ArgumentException("Not enum");

            return Enum.GetValues(typeof(T)).Cast<T>().Select(v =>
            {
                var e = v as Enum;
                return new SelectListItem
                {
                    Id = (Convert.ToInt32(e)),
                    Name = e.GetDisplayName()
                };
            });
        }

        public static IEnumerable<SelectListItem> ToSelectList<T>(string value = "")
            where T : struct
        {

            return Enum.GetValues(typeof(T)).Cast<T>().Select(v =>
            {
                var e = v as Enum;
                return new SelectListItem
                {
                    Id = (Convert.ToInt32(e)),
                    Name = e.GetDisplayName()
                };
            });
        }
    }
}
