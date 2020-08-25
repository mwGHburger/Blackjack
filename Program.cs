using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            // CREATE CARD DECK
            List<string> suits = new List<string> {
                "DIAMOND",
                "HEARTS",
                "CLUBS",
                "SPADE"
            };

            List<string> ranks = new List<string> {
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "JACK",
                "QUEEN",
                "KING",
                "ACE"
            };

            List<List<string>> cardDeck = new List<List<string>>();

            foreach (string rank in ranks)
            {
                foreach (string suit in suits)
                {
                    cardDeck.Add(new List<string> {rank, suit});
                }
            }
            
            Console.WriteLine($"Deck size is {cardDeck.Count}");

            // PLAYER'S TURN
            List<List<string>> playerHand = new List<List<string>>();
            Random rnd = new Random();
            // PICK 2 CARDS AND ADD TO HAND
            int firstCardPosition = rnd.Next(52);
            playerHand.Add(new List<string> {cardDeck[firstCardPosition][0], cardDeck[firstCardPosition][1]});
            System.Console.WriteLine($"Player hand is size {playerHand.Count}");
            System.Console.WriteLine($"Current hand is [{playerHand[0][0]},{playerHand[0][1]}]");
            // List<string> firstCard = cardDeck[firstCardPosition];
            // System.Console.WriteLine($"Selecting first card at position {firstCardPosition}");
            // System.Console.WriteLine($"Your first card is [{firstCard[0]}, {firstCard[1]}]");
            cardDeck.RemoveAt(firstCardPosition);

            int secondCardPosition = rnd.Next(52);
            playerHand.Add(new List<string> {cardDeck[firstCardPosition][0], cardDeck[firstCardPosition][1]});
            System.Console.WriteLine($"Player hand is size {playerHand.Count}");
            System.Console.WriteLine($"Current hand is [{playerHand[1][0]},{playerHand[1][1]}]");
            // List<string> secondCard = cardDeck[secondCardPosition];
            // System.Console.WriteLine($"Selecting second card at position {secondCardPosition}");
            // System.Console.WriteLine($"Your second card is [{secondCard[0]}, {secondCard[1]}]");
            cardDeck.RemoveAt(secondCardPosition);
            
            System.Console.WriteLine(cardDeck.Count);
            // DEALER'S TURN


        }
    }
}
