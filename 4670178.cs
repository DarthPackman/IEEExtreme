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