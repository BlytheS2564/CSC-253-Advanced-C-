using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilentSlope
{
    public class PasswordCheck
    {
        // checks password from CreateNewChar to make sure passwords fit validation rules
        public static int CheckPass(string input)
        {
            int validate = -1;

            if (HasUpperChar(input))
            {
                if (HasLowerChar(input))
                {
                    if (HasSpecialChar(input))
                    {
                        return validate = 0;
                    }
                    else { return validate = 3; }
                }
                else { return validate = 2; }
            }
            else { return validate = 1; }

        }
        // 3 differnet types of validation rules: Special char, Upper char, Lower char
        private static bool HasSpecialChar(string input)
        {
            return input.IndexOfAny("!@#$%^&*?_~-£().,".ToCharArray()) != -1;
        }
        private static bool HasUpperChar(string input)
        {
            return input.Any(c => char.IsUpper(c));
        }
        private static bool HasLowerChar(string input)
        {
            return input.Any(c => char.IsLower(c));
        }

    }
}
