using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;

namespace Drunk.Unicorn.RussPass.Images.General.Expansions
{
    public static class TypeExpansions
    {
        public static Dictionary<string, string> ToDictionary<T>(this T model)
        {
            var properties = model.GetType().GetProperties();

            var result = new Dictionary<string, string>();

            foreach ( var property in properties)
            {
                result.Add(property.GetName(), property.GetValue(model).ToString());
            }

            return result;
        }

        public static string GetName(this PropertyInfo property) => property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? property.Name;
    }
}
