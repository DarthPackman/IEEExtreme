/*
 * Happy Numbers
Time limit: 620 ms
Memory limit: 258.5 MB

A happy number 
?
n is a positive integer defined by the following process:

Starting with 
?
n, replace it with the sum of the squares of its digits.
Repeat the process until the number reaches 1 (where it will stay in eternal happiness), or repeats in an infinite loop that does not include 1.
Those numbers for which this process ends in 1 are happy numbers.
For example, 23 is a happy number: 23 -> 13 -> 10 -> 1 -> 1.

However, 89 is not a happy number (cycle in bold): 89 -> 145 -> 42 -> 20 -> 4 -> 16 -> 37 -> 58 -> 89 -> 145 -> 42 -> 20 -> 4

Given two numbers 
?
,
?
a,b return the number of happy numbers between 
?
a and 
?
b (inclusive).

Standard Input
Each test contains two space separated integers 
?
,
?
a,b

Standard Output
For each test case, output a single integer, the number of happy numbers between 
?
a and 
?
b (inclusive).

Constraints and notes
1
?
?
?
?
?
1
0
16
1?a?b?10 
16
 */

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