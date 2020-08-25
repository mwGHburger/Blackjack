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
            int playerScore;

            // PICK CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing First card to player...");
            int firstCardPosition = dealCard(cardDeck.Count, rnd);
            playerHand.Add(new List<string> {cardDeck[firstCardPosition][0], cardDeck[firstCardPosition][1]});
            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(firstCardPosition);
            // DISPLAY HAND
            System.Console.WriteLine($"Current hand is {displayHand(playerHand)}");

            System.Console.WriteLine("\n");

            // PICK UP CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing Second card to player...");
            int secondCardPosition = dealCard(cardDeck.Count, rnd);
            playerHand.Add(new List<string> {cardDeck[firstCardPosition][0], cardDeck[firstCardPosition][1]});
            System.Console.WriteLine($"Current hand is {displayHand(playerHand)}");
            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(secondCardPosition);
            
            System.Console.WriteLine(cardDeck.Count);
            

            // DEALER'S TURN
        }

        private static int dealCard(int deckSize, Random obj)
        {
            return obj.Next(deckSize);
        }

        private static string displayHand(List<List<string>> cardHand)
        {
            List<string> cardList = new List<string>();
            foreach(List<string> card in cardHand)
            {
                cardList.Add($"[{card[0]}, {card[1]}]");
            }
            
            string display = $"[{string.Join(",", cardList)}]";
            return display;
        }
    }
}
