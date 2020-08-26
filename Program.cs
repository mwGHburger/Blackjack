using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            // INSTANTIATE DECK
            var cardDeck = new Deck();
            Console.WriteLine($"Deck size is {cardDeck.Size}\n");
            
            // INSTANTIATE PLAYERS
            Player newPlayer = new Player("New Player");
            System.Console.WriteLine($"\n{newPlayer.Name} has been created!\n");
            Player dealer = new Player("Dealer");
            System.Console.WriteLine($"\n{dealer.Name} has been created!\n");

            // DEAL FIRST CARD TO NEW PLAYER AND DEALER
            cardDeck.DealCardTo(newPlayer);
            cardDeck.DealCardTo(dealer);

            // DEAL SECOND CARD TO NEW PLAYER AND DEALER
            cardDeck.DealCardTo(newPlayer);
            cardDeck.DealCardTo(dealer);    

            

            // DEBUG
            System.Console.WriteLine($"PLAYER: current hand is {newPlayer.DisplayCurrentHand()}");
            System.Console.WriteLine($"DEALER: current hand is {dealer.DisplayCurrentHand()}");
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
                    cardDeck.DealCardTo(newPlayer);
                    System.Console.WriteLine($"DEALER's score is {newPlayer.Score}");
                }
                else
                {
                    break;
                }
            }
            
            // CHECK FOR BUST
            if (newPlayer.Score > 21) {
                System.Console.WriteLine($"Deck size is {cardDeck.Size}");
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
                    cardDeck.DealCardTo(dealer);
                    System.Console.WriteLine($"DEALER's score is {dealer.Score}");
                }
                else
                {
                    System.Console.WriteLine("DEALER can decide to stay...");
                    break;
                }
            }

            if (dealer.Score > 21) {
                System.Console.WriteLine($"Deck size is {cardDeck.Size}");
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

    }
}
