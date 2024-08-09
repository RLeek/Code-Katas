using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (!isValid(numbers))
            {
                throw new Exception("Unexpected input");
            }

            if (numbers == string.Empty)
            {
                return 0;
            }
         
            var numberRegex = new Regex("[0-9]*");
            var matches = numberRegex.Matches(numbers);
            var sum = 0;
            foreach (var match in matches.ToList())
            {
                if (match.Value!= string.Empty)
                {
                    sum+= Convert.ToInt32(match.Value.ToString());
                }
            }

            return sum;
        }

        private bool isValid(string numbers)
        {
            if (numbers.Length == 0)
            {
                return true;
            }

            var validCharactersRegex = new Regex("^[0-9,]*$");
            if (!validCharactersRegex.IsMatch(numbers))
            {
                return false;
            }

            // Invalid sequence is any sequence of ',,' or longer
            var validSequenceRegex = new Regex(",,");
            if (validSequenceRegex.IsMatch(numbers))
            {
                return false;
            }

            if (numbers.First() == ',' || numbers.Last() == ',')
            {
                return false;
            }

            return true;
        }

    }
}
