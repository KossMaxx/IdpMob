using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace idp.App.Infrastructure
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            if (enumValue == null)
                return null;

            var en = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();

            if (en == null)
                return null;

            var enAttr = en.GetCustomAttribute<DisplayAttribute>();

            return enAttr != null ? enAttr.GetName() : enumValue.ToString();
        }
    }
}
