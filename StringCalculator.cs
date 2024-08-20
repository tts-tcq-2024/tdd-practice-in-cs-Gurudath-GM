using System;
using System.Collections.Generic;
using System.Linq;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        string[] delimiters = Util.GetDelimiters(numbers, out string numbersWithoutDelimiters);
        List<int> numberList = Util.ParseNumbers(numbersWithoutDelimiters, delimiters);
        Util.ValidateNegNums(numberList);
        return Util.SumCalculator(numberList);
    }
}
