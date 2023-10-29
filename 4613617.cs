using System;
using System.Collections.Generic;

class Solution {
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] inputParts = input.Split(' ');
        long start = Convert.ToInt64(inputParts[0]);
        long end = Convert.ToInt64(inputParts[1]);
        
        List<long> unhappyNumbers = new List<long>();

        int count = 0;
        for (long i = start; i <= end; i++)
        {
            if (isHappy(i, unhappyNumbers))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    static bool isHappy(long num, List<long> unhappyNumbers)
    {
        HashSet<long> seen = new HashSet<long>();
        while (num != 1 && !seen.Contains(num) && num != 4)
        {
            if (unhappyNumbers.Contains(num)) 
                return false;

            seen.Add(num);
            long sum = 0;
            while (num > 0)
            {
                long rem = num % 10;
                sum += rem * rem;
                num /= 10;
            }
            num = sum;

            if (unhappyNumbers.Contains(num)) 
                return false;
        }

        if (num == 1)
        {
            return true;
        }
        else
        {
            unhappyNumbers.Add(num); 
            return false;
        }
    }
}