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
            System.Console.WriteLine($"Player score is {calculateScore(playerHand)}");
            System.Console.WriteLine("\n");

            // PICK UP CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing Second card to player...");
            int secondCardPosition = dealCard(cardDeck.Count, rnd);
            playerHand.Add(new List<string> {cardDeck[firstCardPosition][0], cardDeck[firstCardPosition][1]});
            System.Console.WriteLine($"Current hand is {displayHand(playerHand)}");
            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(secondCardPosition);
            
            playerScore = calculateScore(playerHand);
            
            System.Console.WriteLine($"Player score is {playerScore}");
            System.Console.WriteLine($"Deck size is {cardDeck.Count}");

            while (playerScore < 21)
            {
                Console.WriteLine($"You are currently at {playerScore}\nwith the hand {displayHand(playerHand)}");
                Console.Write("\nHit or stay? (Hit = 1, Stay = 0): ");
                string playerInput = Console.ReadLine();
                if (playerInput == "1")
                {
                    int cardPosition = dealCard(cardDeck.Count, rnd);
                    List<string> drawnCard =  cardDeck[cardPosition];
                    Console.WriteLine($"You draw [{drawnCard[0]}, {drawnCard[1]}]");
                    playerHand.Add(new List<string> {cardDeck[cardPosition][0], cardDeck[cardPosition][1]});
                    playerScore = calculateScore(playerHand);
                }
                else
                {
                    break;
                }
            }

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

        private static int calculateScore(List<List<string>> playerHand)
        {
            int total = 0;
            foreach(List<string> card in playerHand)
            {
                total += determineCardValue(card, total);
            }
            return total;
        }

        private static int determineCardValue(List<string> card, int total)
        {
            int cardValue = 0;
            if (card[0] == "JACK" || card[0] == "QUEEN" || card[0] == "KING")
            {
                cardValue += 10;
            }
            else if (card[0] == "ACE")
            {
                if (total < 11) {
                    cardValue += 11;
                }
                else
                {
                    cardValue += 1;
                }
            }
            else
            {
                System.Console.WriteLine($"Converting {card[0]} to number...");
                cardValue = Convert.ToInt32(card[0]);
            }
            return cardValue;
        }
    }
}
