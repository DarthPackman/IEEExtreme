using System;
using System.Collections.Generic;

class Solution {
    static void Main(String[] args) {
        int gameCount = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < gameCount; i++) {
            string p1Hand = Console.ReadLine();
            string p2Hand = Console.ReadLine();
            Queue<int> p1Queue = StringToIntQueue(p1Hand);
            Queue<int> p2Queue = StringToIntQueue(p2Hand);
            string winner = playGame(p1Queue, p2Queue);
            Console.WriteLine(winner);
        }
    }

    static Queue<int> StringToIntQueue(string input) {
        Queue<int> intQueue = new Queue<int>();
        string[] valueStrings = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string valueString in valueStrings) {
            int cardValue;
            if (TryParseCardValue(valueString, out cardValue)) {
                intQueue.Enqueue(cardValue);
            }
        }
        return intQueue;
    }

    static bool TryParseCardValue(string valueString, out int cardValue) {
        switch (valueString) {
            case "A":
                cardValue = 14;
                return true;
            case "K":
                cardValue = 13;
                return true;
            case "Q":
                cardValue = 12;
                return true;
            case "J":
                cardValue = 11;
                return true;
            case "T":
                cardValue = 10;
                return true;
            default:
                return int.TryParse(valueString, out cardValue);
        }
    }

    static string playGame(Queue<int> p1Queue, Queue<int> p2Queue) {
        while (p1Queue.Count > 0 && p2Queue.Count > 0) {
            int p1Card = p1Queue.Dequeue();
            int p2Card = p2Queue.Dequeue();

            if (p1Card > p2Card) {
                p1Queue.Enqueue(p2Card);
            }
            else if (p2Card > p1Card) {
                p2Queue.Enqueue(p1Card);
            }
            else {
                p1Queue.Enqueue(p1Card);
                p2Queue.Enqueue(p2Card);
                if (drawCheck(p1Queue, p2Queue)) {
                    return "draw";
                }
            }
        }

        return p1Queue.Count == 0 ? "player 2" : "player 1";
    }

    static bool drawCheck(Queue<int> p1Queue, Queue<int> p2Queue) {
        return SequenceEqual(p1Queue, p2Queue);
    }

    static bool SequenceEqual(Queue<int> queue1, Queue<int> queue2) {
        if (queue1.Count != queue2.Count) {
            return false;
        }

        int[] array1 = queue1.ToArray();
        int[] array2 = queue2.ToArray();

        for (int i = 0; i < array1.Length; i++) {
            if (array1[i] != array2[i]) {
                return false;
            }
        }

        return true;
    }
}
