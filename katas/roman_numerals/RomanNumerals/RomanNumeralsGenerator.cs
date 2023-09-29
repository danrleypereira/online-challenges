using System.Collections.Generic;
using System.Text;

namespace RomanNumerals
{
    public static class RomanNumeralsGenerator
    {
        private static readonly Dictionary<string, int> RomanMapping = new Dictionary<string, int>
        {
            {"M", 1000},
            {"CM", 900},
            {"D", 500},
            {"CD", 400},
            {"C", 100},
            {"XC", 90},
            {"L", 50},
            {"XL", 40},
            {"X", 10},
            {"IX", 9},
            {"V", 5},
            {"IV", 4},
            {"I", 1}
        };
        public static string DecimalToRomanNumeralsParser(int number)
        {
            int remainingAmount = number;
            StringBuilder romanNumber = new StringBuilder();
            foreach(var item in RomanMapping)
            {
                if(remainingAmount >= item.Value)
                {
                    int timesItemValueFits = remainingAmount / item.Value;
                    for(int i=0; i < timesItemValueFits; i++)
                        romanNumber.Append(item.Key);
                    remainingAmount -= item.Value * timesItemValueFits;
                }
            }
            return romanNumber.ToString();
        }
    }
}