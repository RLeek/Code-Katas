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
        private readonly Regex numberRegex = new Regex("(^[0-9]+)");
        private readonly Regex negativeNumberRegex = new Regex("(^-[0-9]+)");
        private readonly Regex defaultDelimiterRegex = new Regex(@"^//([^\[\]\n]+)\n");
        private readonly Regex multiDelimiterRegex = new Regex(@"\[([^\[\]]+)\]");
        private readonly Regex startRegex = new Regex(@"//");


        private Regex delimiterRegex = new Regex($"(^[,\n])");
        private Regex validCharactersRegex = new Regex("^[0-9,\n]+$");

        private Regex newDelimiterRegex(List<string> delimiter) => new Regex(@$"^({(string.Join('|', delimiter.Select(x=>Regex.Escape(x)).ToList()))}|\n)");


        private char delimiter = ',';


        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }

            if (numbers[numbers.Count() - 1] > '9' && numbers[numbers.Count() -1] < '0' )
            {
                throw new Exception("Invalid argument");
            }

            var match = MatchDefaultDelimiter(numbers);
            if (match.Count != 0)
            {
                delimiterRegex = newDelimiterRegex(match);
                numbers = numbers.Substring(numbers.IndexOf('\n')+1);
            }

            var negativeNumbers = new List<int>();
            var sum = 0;
            while(numbers.Length > 0)
            {
                var number = MatchNumber(numbers);
                var parsedNumber = Convert.ToInt32(number);
                if (parsedNumber < 0)
                {
                    negativeNumbers.Add(parsedNumber);
                }
                if (parsedNumber <= 1000)
                {
                    sum += Convert.ToInt32(parsedNumber);
                }
                numbers = numbers.Substring(number.Count());
                if (numbers.Length == 0)
                {
                    // we could switch this to be a toggle based on the previous token
                    // That would generalize better but ehh
                    break;
                }
                var delimiter = MatchDelimiter(numbers);
                numbers = numbers.Substring(delimiter.Count());
            }

            if (negativeNumbers.Count > 0)
            {
                throw new Exception($"negatives not allowed {string.Join(',', negativeNumbers)}");
            }


            return sum;
        }

        private List<string> MatchDefaultDelimiter(string input)
        {
            var delimiters = new List<string>();
            if (startRegex.IsMatch(input))
            {
                if (defaultDelimiterRegex.IsMatch(input))
                {
                    var value = defaultDelimiterRegex.Match(input);
                    delimiters.Add(defaultDelimiterRegex.Match(input).Groups[1].ToString());
                    return delimiters;
                } else
                {
                    input = input.Substring(2);
                    while (input[0] != '\n')
                    {
                        var match = multiDelimiterRegex.Match(input).Value;
                        if (match.Count() == 0)
                        {
                            throw new Exception("Don't make sense");
                        }
                        delimiters.Add(match.TrimStart('[').TrimEnd(']'));
                        input = input.Substring(match.Count());
                    }
                    return delimiters;
                }
            } else
            {
                return delimiters;
            }
        }

        private string MatchDelimiter(string input)
        {
            if (delimiterRegex.IsMatch(input))
            {
                return delimiterRegex.Match(input).Value;
            }

            throw new Exception("received incorrect token");
        }

        private string MatchNumber(string input)
        {
            if (numberRegex.IsMatch(input))
            {
                return numberRegex.Match(input).Value;
            }
            if (negativeNumberRegex.IsMatch(input))
            {
                return negativeNumberRegex.Match(input).Value;
            }
            throw new Exception("received incorrect token");
        }
    }
}
