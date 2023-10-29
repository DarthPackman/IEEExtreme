using System;
using System.Collections.Generic;

class Solution {
    static void Main(String[] args)
    {
        string input = Console.ReadLine();
        string[] counts = input.Split(' ');
        int rhymeCount = int.Parse(counts[0]);
        string[][] rhymes = new string[rhymeCount][];
        int sentenceCount = int.Parse(counts[1]);
        string[][] sentences = new string[sentenceCount][];
        string rhymescheme = "";
        

        // Read rhymes
        for (int i = 0; i < rhymeCount; i++)
        {
            string rhymeInput = Console.ReadLine();
            rhymes[i] = rhymeInput.Split(' ');
        }
        
        Console.ReadLine();

        // Read sentences and determine rhyme scheme
        for (int i = 0; i < sentenceCount; i++)
        {
            string sentenceInput = Console.ReadLine();
            sentences[i] = sentenceInput.Split(' ');
            int lastWordPOS = sentences[i].Length - 1;
            string lastWord = sentences[i][lastWordPOS];
            bool found = false;

            for (int j = 0; j < rhymeCount; j++)
            {
                if (Array.Exists(rhymes[j], word => word.Equals(lastWord, StringComparison.OrdinalIgnoreCase)))
                {
                    rhymescheme = rhymescheme + j;
                    found = true;
                    break; // Exit the loop once a rhyme is found
                }
            }

            if (!found)
            {
                rhymescheme = rhymescheme + "X";
            }
        }

        rhymescheme = ConvertNumbersToLetters(rhymescheme);
        Console.WriteLine(rhymescheme);
    }
    
    static string ConvertNumbersToLetters(string input)
    {
        char[] charArray = input.ToCharArray();
        
        for (int i = 0; i < charArray.Length; i++)
        {
            if (char.IsDigit(charArray[i]))
            {
                int number = int.Parse(charArray[i].ToString());
                if (number < 88)
                    charArray[i] = (char)('A' + number); // Convert to corresponding letter
                else
                    charArray[i] = (char)('A' + number + 1);
            }
        }
        
        return new string(charArray);
    }
}