using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Points.General.Expansions
{
    public static class EnumsExpansions
    {
        public static Expected GetAttributeValue<T, Expected>(this Enum enumeration, Func<T, Expected> expression)
    where T : Attribute
        {
            T attribute =
              enumeration
                .GetType()
                .GetMember(enumeration.ToString())
                .Where(member => member.MemberType == MemberTypes.Field)
                .FirstOrDefault()
                .GetCustomAttributes(typeof(T), false)
                .Cast<T>()
                .SingleOrDefault();

            if (attribute == null)
                return default(Expected);

            return expression(attribute);
        }
    }
}
