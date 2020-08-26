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
            
            // INSTANTIATE PLAYERS
            Player newPlayer = new Player("New Player");
            System.Console.WriteLine($"\n{newPlayer.Name} has been created!\n");
            Player dealer = new Player("Dealer");
            System.Console.WriteLine($"\n{dealer.Name} has been created!\n");

            // PICK CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing First card to PLAYER...");
            deckPosition = dealCard(cardDeck.Count, rnd);
            System.Console.WriteLine($"Deck position at {deckPosition}");
            newPlayer.AddCardToHand(cardDeck[deckPosition]);
            System.Console.WriteLine($"PLAYER picked up [{cardDeck[deckPosition][0]}, {cardDeck[deckPosition][1]}]\n");

            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(deckPosition);
            
            // PICK CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing First card to DEALER...");
            deckPosition = dealCard(cardDeck.Count, rnd);
            System.Console.WriteLine($"Deck position at {deckPosition}");
            dealer.AddCardToHand(cardDeck[deckPosition]);
            System.Console.WriteLine($"DEALER picked up [{cardDeck[deckPosition][0]}, {cardDeck[deckPosition][1]}]\n");

            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(deckPosition);

            // PICK UP CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing Second card to PLAYER...");
            deckPosition = dealCard(cardDeck.Count, rnd);
            System.Console.WriteLine($"Deck position at {deckPosition}");
            newPlayer.AddCardToHand(cardDeck[deckPosition]);
            System.Console.WriteLine($"PLAYER picked up [{cardDeck[deckPosition][0]}, {cardDeck[deckPosition][1]}]\n");
            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(deckPosition);

            // PICK CARD AND ADD TO HAND
            System.Console.WriteLine("Dealing Second card to DEALER...");
            deckPosition = dealCard(cardDeck.Count, rnd);
            System.Console.WriteLine($"Deck position at {deckPosition}");
            dealer.AddCardToHand(cardDeck[deckPosition]);
            System.Console.WriteLine($"DEALER picked up [{cardDeck[deckPosition][0]}, {cardDeck[deckPosition][1]}]\n");
            
            // REMOVE CARD FROM DECK
            cardDeck.RemoveAt(deckPosition);

            // DEBUG
            System.Console.WriteLine($"PLAYER: current hand is {newPlayer.DisplayCurrentHand()}");
            System.Console.WriteLine($"DEALER: current hand is {dealer.DisplayCurrentHand()}");
            
            newPlayer.CalculateScore();
            dealer.CalculateScore();
            
            System.Console.WriteLine($"PLAYER score is {newPlayer.Score}");
            System.Console.WriteLine($"DEALER score is {dealer.Score}");
            
            // PLAYER'S TURN
            while (newPlayer.Score < 21)
            {
                Console.WriteLine($"You are currently at {newPlayer.Score}\nwith the hand {newPlayer.DisplayCurrentHand()}");
                Console.Write("\nHit or stay? (Hit = 1, Stay = 0): ");
                string playerInput = Console.ReadLine();
                if (playerInput == "1")
                {
                    // DEAL CARD
                    int cardPosition = dealCard(cardDeck.Count, rnd);
                    List<string> drawnCard = cardDeck[cardPosition];
                    Console.WriteLine($"You draw [{drawnCard[0]}, {drawnCard[1]}]");
                    newPlayer.AddCardToHand(drawnCard);
                    cardDeck.RemoveAt(cardPosition);
                    newPlayer.CalculateScore();
                }
                else
                {
                    break;
                }
            }

            // CHECK FOR BUST
            if (newPlayer.Score > 21) {
                System.Console.WriteLine($"Deck size is {cardDeck.Count}");
                Console.WriteLine($"You are currently at a Bust!\nwith the hand {newPlayer.DisplayCurrentHand()}");
                Console.WriteLine("The dealer wins!");
                return;
            }

            // DEALER'S TURN
            while (dealer.Score < 21)
            {
                Console.WriteLine($"Dealer is at {dealer.Score}\nwith the hand {dealer.DisplayCurrentHand()}");
                if (dealer.Score < 17)
                {
                    System.Console.WriteLine("DEALER hits himself...");
                    int cardPosition = dealCard(cardDeck.Count, rnd);
                    List<string> drawnCard =  cardDeck[cardPosition];
                    Console.WriteLine($"Dealer draws [{drawnCard[0]}, {drawnCard[1]}]");
                    dealer.AddCardToHand(cardDeck[deckPosition]);
                    cardDeck.RemoveAt(cardPosition);
                    dealer.CalculateScore();
                    System.Console.WriteLine($"DEALER's score is {dealer.Score}");
                }
                else
                {
                    System.Console.WriteLine("DEALER can decide to stay...");
                    break;
                }
            }

            if (dealer.Score > 21) {
                System.Console.WriteLine($"Deck size is {cardDeck.Count}");
                Console.WriteLine($"Dealer busts!\nwith the hand {dealer.DisplayCurrentHand()}");
                Console.WriteLine("The player wins!");
                return;
            }

            // TIE
            if (newPlayer.Score == dealer.Score)
            {
                System.Console.WriteLine("Tie game! Both player and dealer have the same score!");
            } 
            else if (newPlayer.Score > dealer.Score)
            {
                Console.WriteLine($"The player wins! {newPlayer.Score} to {dealer.Score}.");
            }
            else
            {
                Console.WriteLine($"The dealer wins! {dealer.Score} to {newPlayer.Score}.");
            }
        }

        private static int dealCard(int deckSize, Random obj)
        {
            return obj.Next(deckSize);
        }

    }
}
