using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cardsInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> cards = new List<string>();

            foreach (string card in cardsInfo)
            {
                string[] singleCardsInfo = card.Split();

                string cardsFace = singleCardsInfo[0];
                string cardsSuit = singleCardsInfo[1];

                try
                {
                    string currCard = GetCard(cardsFace, cardsSuit);
                    cards.Add(currCard);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(string.Join(' ', cards));
        }

        static string GetCard(string face, string suit)
        {

            string[] expectedCardsFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] expectedCardsSuits = new string[] { "S", "H", "D", "C" };

            string newCard = string.Empty;

            if (expectedCardsFaces.Contains(face))
            {
                if (expectedCardsSuits.Contains(suit))
                {
                    if (suit == "S")
                    {
                        suit = "\u2660";
                    }
                    else if (suit == "H")
                    {
                        suit = "\u2665";
                    }
                    else if (suit == "D")
                    {
                        suit = "\u2666";
                    }
                    else if (suit == "C")
                    {
                        suit = "\u2663";
                    }

                    newCard = $"[{face}{suit}]";
                }
                else
                {
                    throw new ArgumentException("Invalid card!");
                }
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }

            return newCard;
        }
    }
}
