/* Restaurant Cipher
Time limit: 1220 ms
Memory limit: 258.5 MB

Ali always asks his chef to cook some specific recipes. They wanted to have some fun, so, they agreed to name some recipes with just the letters: A, B, C, D, E, F and G, and not more. Now, if Ali wants a recipe, he sends a secret message to his chef that asks for a single recipe.

Your task is to break Ali's scheme for creating the secret messages, based on the example messages in the testcase below.

Standard Input
Input begins with an integer 
?
n on a line by itself that indicates how many secret messages are in the input.

The next 
?
n lines each contain a secret message.

Standard Output
For each secret message, output a line with a single letter that indicates which recipe is being requested.

Constraints and notes
1
?
?
?
20
1?n?20
Each message will consist of lowercase letters, spaces, and punctuation. Each message will contain no more than 50,000 characters.
*/

using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    static void Main(String[] args) {
        int messageCount = Convert.ToInt32(Console.ReadLine()); 
        for (int i = 0; i < messageCount; i++)
        {
            string message = Console.ReadLine();
            string recipe = getRecipe(message); 
            Console.WriteLine(recipe);
        }
    }

    static string getRecipe(string mess)
    {
        int aCount = 0;
        int bCount = 0;
        int cCount = 0;
        int dCount = 0;
        int eCount = 0;
        int fCount = 0;
        int gCount = 0;
        foreach (char c in mess)
        {
            if (c == 'a')
                aCount++;
            else if (c == 'b')
                bCount++;
            else if (c == 'c')
                cCount++;
            else if (c == 'd')
                dCount++;
            else if (c == 'e')
                eCount++;
            else if (c == 'f')
                fCount++;
            else if (c == 'g')
                gCount++;
        }

        if (aCount > bCount && aCount > cCount && aCount > dCount && aCount > eCount && aCount > fCount &&
            aCount > gCount)
        {
            return "A";
        }
        else if (bCount > cCount && bCount > dCount && bCount > eCount && bCount > fCount && bCount > gCount)
        {
            return "B";
        }
        else if (cCount > dCount && cCount > eCount && cCount > fCount && cCount > gCount)
        {
            return "C";
        }
        else if (dCount > eCount && dCount > fCount && dCount > gCount)
        {
            return "D";
        }
        else if (eCount > fCount && eCount > gCount)
        {
            return "E";
        }
        else if (fCount > gCount)
        {
            return "F";
        }
        else
        {
            return "G";
        }
    }
}