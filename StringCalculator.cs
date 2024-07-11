using System;
using System.Collections.Generic;
using System.Linq;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
            if (IsNullOrEmpty(numbers))
            {
                return 0;
            }

        string[] delimiters = GetDelimiters(numbers, out string numbersWithoutDelimiters);
        List<int> numberList = ParseNumbers(numbersWithoutDelimiters, delimiters);
        ValidateNegNums(numberList);
        return SumCalculator(numberList);
    }

    private bool IsNullOrEmpty(string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }

    private string[] GetDelimiters(string numbers, out string numbersWithoutDelimiters)
    {
        string[] delimiters = new string[] { ",", "\n" };
        numbersWithoutDelimiters = numbers;

        if (numbers.StartsWith("//"))
        {
            int delimiterEndIndex = numbers.IndexOf('\n');
            string customDelimiter = numbers.Substring(2, delimiterEndIndex - 2);
            delimiters = new string[] { customDelimiter };
            numbersWithoutDelimiters = numbers.Substring(delimiterEndIndex + 1);
        }
        return delimiters;
    }

    private List<int> ParseNumbers(string numbers, string[] delimiters)
    {
        return numbers.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToList();
    }

    private void ValidateNegNums(List<int> numbers)
    {
        List<int> negativeNumbers = numbers.Where(n => n < 0).ToList();
        if (negativeNumbers.Any())
        {
            throw new Exception("Negative numbers not allowed: " + string.Join(",", negativeNumbers));
        }
    }

    private int SumCalculator(List<int> numbers)
    {
        return numbers.Where(n => n <= 1000).Sum();
    }
}
