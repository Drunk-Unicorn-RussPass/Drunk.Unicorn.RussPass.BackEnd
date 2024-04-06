using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Drunk.Unicorn.RussPass.Users.General.Expansions
{
    public static class StringExpansions
    {
        public static bool CanParseToInt(this string number)
        {
            try
            {
                int.Parse(number);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool CanParseToFloat(this string number)
        {
            try
            {
                float.Parse(number);
            }
            catch
            {
                return false;
            }

            return true;
        }

        //Смысла проверять как-то лучше никакого. 
        public static bool IsEmail(this string email) => email.CorrectRegex(@"/.+@.+\..+/i");

        public static bool IsPhone(this string phone) => phone.CorrectRegex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");

        public static bool CorrectRegex(this string text, string regex) => Regex.IsMatch(text, regex);

        public static bool AllElementsOfNumber(this string[] elements) =>
            elements.All(x => x.CanParseToFloat());

        public static string[] ToArray(this string elements) => elements.Split(',');
    }
}
