using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOneDeck = FillList();
            List<int> playerTwoDeck = FillList();

            bool isGameOn = true;
           
            while (isGameOn)
            {
                int cardOne = playerOneDeck[0];
                int cardTwo = playerTwoDeck[0];

                if (cardOne > cardTwo)
                {
                    playerOneDeck.Add(cardOne);
                    playerOneDeck.Add(cardTwo);
                }
                else if (cardOne < cardTwo)
                {
                    playerTwoDeck.Add(cardTwo);
                    playerTwoDeck.Add(cardOne);                    
                }

                playerOneDeck.RemoveAt(0);
                playerTwoDeck.RemoveAt(0);

                if (playerOneDeck.Count == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {playerTwoDeck.Sum()}");
                    isGameOn = false;
                }
                else if (playerTwoDeck.Count == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {playerOneDeck.Sum()}");
                    isGameOn = false;
                }

            }

        }

        private static List<int> FillList()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}
