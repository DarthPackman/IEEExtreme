/*
 War Games
Time limit: 1220 ms
Memory limit: 258.5 MB

In one variant of the game of war, two players are dealt a pile of playing cards. At each turn, both players turn over their top card, and the player with the higher card adds the lower card to the bottom of their deck. The higher card is then discarded. If the cards that are turned over have the same value, both players return their card to the bottom of their pile.

The player that runs out of cards loses the game. If no player will run out of cards, the game ends in a draw.

Your challenge is to determine which player will win a game, given the cards in each player's pile.

Standard Input
Input begins with an integer 
?
n on a line by itself that indicates how many games are in the input.

The next 
2
?
2n lines describe the 
?
n games, with the first line in a pair giving player 1's cards and the second line giving player 2's cards. The cards are listed from the top of the pile to the bottom of the pile, and are described by a single character chosen from the list <2,3,4,5,6,7,8,9,T,J,Q,K,A>. Note that this list gives the cards' values sorted in ascending order.

Standard Output
For each game, output:

player 1 if player 1 will win the game

player 2 if player 2 will win the game

draw if the game will end in a draw

Constraints and notes
1
?
?
?
25
1?n?25
Each player will have between 1 and 51 cards, inclusive.

The players may start with a different number of cards.

The total number of cards for both players will be less than or equal to 52.

There is no restriction on the number of cards of a particular value that may appear. For example, the game may include 52 cards with the value of A.
*/

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
