using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var cardDeck = Deck.CreateDeck();

            Console.WriteLine($"Deck size is {cardDeck.Count}\n");
            
            // DEAL TO BOTH PLAYER AND DEALER
            Random rnd = new Random();
            int deckPosition;

            List<List<string>> playerHand = new List<List<string>>();
            int playerScore;

            List<List<string>> dealerHand = new List<List<string>>();
            int dealerScore;

            // PICK CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing First card to PLAYER...");
            deckPosition = dealCard(cardDeck.Count, rnd);
            System.Console.WriteLine($"Deck position at {deckPosition}");
            playerHand.Add(new List<string> {cardDeck[deckPosition][0], cardDeck[deckPosition][1]});
            System.Console.WriteLine($"PLAYER picked up [{cardDeck[deckPosition][0]}, {cardDeck[deckPosition][1]}]\n");

            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(deckPosition);
            
            // PICK CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing First card to DEALER...");
            deckPosition = dealCard(cardDeck.Count, rnd);
            System.Console.WriteLine($"Deck position at {deckPosition}");
            dealerHand.Add(new List<string> {cardDeck[deckPosition][0], cardDeck[deckPosition][1]});
            System.Console.WriteLine($"DEALER picked up [{cardDeck[deckPosition][0]}, {cardDeck[deckPosition][1]}]\n");

            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(deckPosition);

            // PICK UP CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing Second card to PLAYER...");
            deckPosition = dealCard(cardDeck.Count, rnd);
            System.Console.WriteLine($"Deck position at {deckPosition}");
            playerHand.Add(new List<string> {cardDeck[deckPosition][0], cardDeck[deckPosition][1]});
            System.Console.WriteLine($"PLAYER picked up [{cardDeck[deckPosition][0]}, {cardDeck[deckPosition][1]}]\n");
            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(deckPosition);

            // PICK CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing Second card to DEALER...");
            deckPosition = dealCard(cardDeck.Count, rnd);
            System.Console.WriteLine($"Deck position at {deckPosition}");
            dealerHand.Add(new List<string> {cardDeck[deckPosition][0], cardDeck[deckPosition][1]});
            System.Console.WriteLine($"DEALER picked up [{cardDeck[deckPosition][0]}, {cardDeck[deckPosition][1]}]\n");
            
            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(deckPosition);

            // DEBUG
            System.Console.WriteLine($"PLAYER: current hand is {displayHand(playerHand)}");
            System.Console.WriteLine($"DEALER: current hand is {displayHand(dealerHand)}");
            
            playerScore = calculateScore(playerHand);
            dealerScore = calculateScore(dealerHand);
            
            System.Console.WriteLine($"PLAYER score is {playerScore}");
            System.Console.WriteLine($"DEALER score is {dealerScore}");
            
            
            // PLAYER'S TURN
            while (playerScore < 21)
            {
                Console.WriteLine($"You are currently at {playerScore}\nwith the hand {displayHand(playerHand)}");
                Console.Write("\nHit or stay? (Hit = 1, Stay = 0): ");
                string playerInput = Console.ReadLine();
                if (playerInput == "1")
                {
                    // DEAL CARD
                    int cardPosition = dealCard(cardDeck.Count, rnd);
                    List<string> drawnCard =  cardDeck[cardPosition];
                    Console.WriteLine($"You draw [{drawnCard[0]}, {drawnCard[1]}]");
                    playerHand.Add(new List<string> {cardDeck[cardPosition][0], cardDeck[cardPosition][1]});
                    cardDeck.RemoveAt(cardPosition);
                    playerScore = calculateScore(playerHand);
                }
                else
                {
                    break;
                }
            }

            // CHECK FOR BUST
            if (playerScore > 21) {
                System.Console.WriteLine($"Deck size is {cardDeck.Count}");
                Console.WriteLine($"You are currently at a Bust!\nwith the hand {displayHand(playerHand)}");
                Console.WriteLine("The dealer wins!");
                return;
            }

            // DEALER'S TURN
            while (dealerScore < 21)
            {
                Console.WriteLine($"Dealer is at {dealerScore}\nwith the hand {displayHand(dealerHand)}");
                if (dealerScore < 17)
                {
                    System.Console.WriteLine("DEALER hits himself...");
                    int cardPosition = dealCard(cardDeck.Count, rnd);
                    List<string> drawnCard =  cardDeck[cardPosition];
                    Console.WriteLine($"Dealer draws [{drawnCard[0]}, {drawnCard[1]}]");
                    dealerHand.Add(new List<string> {cardDeck[cardPosition][0], cardDeck[cardPosition][1]});
                    cardDeck.RemoveAt(cardPosition);
                    dealerScore = calculateScore(dealerHand);
                    System.Console.WriteLine($"DEALER's score is {dealerScore}");
                }
                else
                {
                    System.Console.WriteLine("DEALER can decide to stay...");
                    break;
                }
            }

            if (dealerScore > 21) {
                System.Console.WriteLine($"Deck size is {cardDeck.Count}");
                Console.WriteLine($"Dealer busts!\nwith the hand {displayHand(dealerHand)}");
                Console.WriteLine("The player wins!");
                return;
            }

            // TIE
            if (playerScore == dealerScore)
            {
                System.Console.WriteLine("Tie game! Both player and dealer have the same score!");
            } 
            else if (playerScore > dealerScore)
            {
                Console.WriteLine($"The player wins! {playerScore} to {dealerScore}.");
            }
            else
            {
                Console.WriteLine($"The dealer wins! {dealerScore} to {playerScore}.");
            }
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
                cardValue = Convert.ToInt32(card[0]);
            }
            return cardValue;
        }
    }
}
