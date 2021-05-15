using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCustomerDemo.Logic
{
    public static class Extensions
    {
        public static string StripToNumbers(this string me)
        {
            char[] charArray = me.ToCharArray();
            string output = string.Empty;

            foreach (var item in charArray)
            {
                if (item >= 48 && item <= 57) output += item.ToString();
            }

            return output;
        }
    }
}
