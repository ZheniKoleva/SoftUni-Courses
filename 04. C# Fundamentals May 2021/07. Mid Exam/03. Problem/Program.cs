using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialCardDeck = Console.ReadLine()
                .Split(':', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> newCardDeck = new List<string>();

            string line = Console.ReadLine();

            while (line != "Ready")
            {
                string[] cardData = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = cardData[0];

                switch (command)
                {
                    case "Add":
                        string cardToAdd = cardData[1];

                        if (!IsCardExist(initialCardDeck, cardToAdd))
                        {
                            Console.WriteLine("Card not found.");
                            break;
                        }

                        newCardDeck.Add(cardToAdd);
                        break;

                    case "Insert":
                        string cardToInsert = cardData[1];
                        int indxToinsert = int.Parse(cardData[2]);

                        if (!IsValidIndex(newCardDeck, indxToinsert) 
                            || !IsCardExist(initialCardDeck, cardToInsert) )
                        {
                            Console.WriteLine("Error!");
                            break;
                        }

                        newCardDeck.Insert(indxToinsert, cardToInsert);
                        break;

                    case "Remove":
                        string cardToRemove = cardData[1];

                        bool isRemoved = newCardDeck.Remove(cardToRemove);

                        if (!isRemoved)
                        {
                            Console.WriteLine("Card not found.");                            
                        }
                        break;

                    case "Swap":
                        string cardOne = cardData[1];
                        string cardTwo = cardData[2];

                        int indxCardOne = newCardDeck.IndexOf(cardOne);
                        int indxCardTwo = newCardDeck.IndexOf(cardTwo);

                        string temp = newCardDeck[indxCardOne];
                        newCardDeck[indxCardOne] = cardTwo;
                        newCardDeck[indxCardTwo] = temp;
                        break;

                    case "Shuffle":
                        newCardDeck.Reverse();
                        break;
                    
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', newCardDeck));
        }      

        private static bool IsCardExist(List<string> cardsDeck, string cardToAdd)
        {
            return cardsDeck.Contains(cardToAdd);
        }

        private static bool IsValidIndex(List<string> cardsDeck, int indxToinsert)
        {
            return indxToinsert >= 0 && indxToinsert < cardsDeck.Count;
        }
    }
}
