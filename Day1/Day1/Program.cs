using System.Text.RegularExpressions;
using System.Collections.Generic;


//part 1
var input = File.ReadAllLines("Input.json");
var total = 0;

foreach (var line in input)
{
    var digits = line.Where(char.IsDigit).ToList();

    if (digits.Count > 0)
    {
        var value = int.Parse($"{digits.First()}{digits.Last()}");
        total += value;
    }
}

Console.WriteLine("Part 1: " + total);


total = 0;
//part 2

Dictionary<string, string> wordToDigit = new()
{
    { "zero", "0" }, { "one", "1" }, { "two", "2" },
    { "three", "3" }, { "four", "4" }, { "five", "5" },
    { "six", "6" }, { "seven", "7" }, { "eight", "8" },
    { "nine", "9" }
};

foreach (var line in input)
{
    List<string> digitsFound = new();

    for (int i = 0; i< line.Length; i++)
    {
        if (char.IsDigit(line[i]))
        {
            digitsFound.Add(line[i].ToString());
            continue;
        }

        foreach (var kvp in wordToDigit)
        {
            var word = kvp.Key; 
            if (i + word.Length <= line.Length && line.Substring(i, word.Length).Equals(word, StringComparison.OrdinalIgnoreCase))
            {
                digitsFound.Add(kvp.Value);
                break;
            }
        }
    }

    if (digitsFound.Count >= 1)
    {
        var combined = digitsFound[0] + digitsFound[^1];

        total += int.Parse(combined);
    }
}

Console.WriteLine("Part 2:" + total);

