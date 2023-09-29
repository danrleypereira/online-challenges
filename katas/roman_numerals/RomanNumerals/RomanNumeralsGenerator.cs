using System;
using System.Collections.Generic;

namespace RomanNumerals
{
    public static class RomanNumeralsGenerator
    {
        private static readonly Dictionary<int, string> RomanMapping = new Dictionary<int, string>
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };
        public static string DecimalToRomanNumeralsParser(int number)
        {
            int amount_left_to_add_into_roman_number = number;
            string roman_number = "";
            while(amount_left_to_add_into_roman_number > 0)
            {
                foreach (var item in RomanMapping)
                {
                    while(amount_left_to_add_into_roman_number >= item.Key)
                        if(amount_left_to_add_into_roman_number >= item.Key)
                        {
                            roman_number += item.Value;
                            amount_left_to_add_into_roman_number -= item.Key;
                        }
                }
            }
            return roman_number;
        }
    }
}
