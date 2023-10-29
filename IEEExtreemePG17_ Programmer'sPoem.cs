/*
 * Programmer's Poem
Time limit: 1220 ms
Memory limit: 258.5 MB

Programmer's Poem


The poem above is meant to be read:

Waka waka bang splat tick tick hash

Caret quote back tick dollar dollar dash

Bang splat equal at dollar underscore

Percent splat waka waka tilde number four

Ampersand bracket bracket dot dot slash

Vertical bar curly bracket comma comma CRASH

Challenge
In this challenge, you need to determine the rhyme scheme used by a passage. A rhyme scheme for a passage with 
?
n lines is a string of uppercase letters of length 
?
n, where the 
?
?
?
i 
th
  letter in the string corresponds to the 
?
?
?
i 
th
  line in the passage. The rules for creating the string are:

1) The lines that rhyme will be labelled with upper-case letters except for X.

2) The first set of lines that rhyme should be labelled with an A. The second set are labelled with a B, and so on, skipping the letter X.

3) Lines that do not rhyme with any other line should be labelled with an X.

Standard input
The input will begin with two space-separated integers 
?
n and 
?
m.

Each of the next 
?
n lines will contain a list of space-separated words that rhyme. The words will consist of lowercase letters only.

Then there will be a blank line.

The next 
?
m lines contain the passage to analyze.

Standard output
Output the rhyme scheme for the passage.

Constraints and notes
1
?
?
?
100
1?n?100
2
?
?
?
50
2?m?50
Each rhyming group will contain between 1 and 100 words, inclusive.

Each word will be made of between 1 and 15 lower-case letters, inclusive.

No word will appear in more than one group of rhyming words.

Each line of the passage will contain between 1 and 100 words, inclusive. The passage will contain only upper- and lower-case letters.

Comparisons should ignore case.

Two words should only be treated as rhyming, if they appear in the same list of rhyming words.

A word rhymes with itself, if and only if, it appears in one of the lists of rhyming words.
 * 
 */

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