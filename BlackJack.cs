using System;

namespace Blackjack
{
    public class BlackJack
    {
        // CONSTRUCTOR
        public BlackJack()
        {}

        // METHODS
        public static void StartGame()
        {
            BlackJack blackJack = new BlackJack();
            var cardDeck = new Deck();
            Player newPlayer = new Player("New Player");
            Player dealer = new Player("Dealer");

            // DEAL FIRST CARD TO NEW PLAYER AND DEALER 
            blackJack.DealTwoCardsToEachPlayer(cardDeck, newPlayer, dealer);

            System.Console.WriteLine($"Game starts from here...\n");
            
            // PLAYER'S TURN
            blackJack.BeginPlayerTurn(newPlayer, cardDeck);

            // CHECK FOR BUST
            if (blackJack.CheckForBust(newPlayer))
            {
                return;
            }

            // DEALER'S TURN
            blackJack.BeginDealerTurn(dealer, cardDeck);

            // CHECK FOR BUST
            if(blackJack.CheckForBust(dealer))
            {
                return;
            }

            // TIE
            blackJack.CheckScores(newPlayer, dealer);
            System.Console.WriteLine($"Deck size is {cardDeck.Size}");
        }

        public void DealTwoCardsToEachPlayer(Deck cardDeck, Player player, Player dealer)
        {
            // DEAL FIRST CARD TO NEW PLAYER AND DEALER
            cardDeck.DealCardTo(player);
            cardDeck.DealCardTo(dealer);

            // DEAL SECOND CARD TO NEW PLAYER AND DEALER
            cardDeck.DealCardTo(player);
            cardDeck.DealCardTo(dealer);   
        }

        public void BeginPlayerTurn(Player player, Deck cardDeck)
        {
            while (player.Score < 21)
            {
                Console.WriteLine($"You are currently at {player.Score}\nwith the hand {player.DisplayCurrentHand()}");
                Console.Write("\nHit or stay? (Hit = 1, Stay = 0): ");
                string playerInput = Console.ReadLine();
                if (playerInput == "1")
                {
                    // DEAL CARD
                    cardDeck.DealCardTo(player);
                    System.Console.WriteLine($"{player.Name}'s score is {player.Score}");
                }
                else
                {
                    break;
                }
            }
        }

        public void BeginDealerTurn(Player player, Deck cardDeck)
        {
            while (player.Score < 21)
            {
                Console.WriteLine($"{player.Name} is at {player.Score}\nwith the hand {player.DisplayCurrentHand()}");
                if (player.Score < 17)
                {
                    cardDeck.DealCardTo(player);
                    System.Console.WriteLine($"{player.Name}'s score is {player.Score}");
                }
                else
                {
                    System.Console.WriteLine($"{player.Name} can decide to stay...");
                    break;
                }
            }
        }

        public bool CheckForBust(Player player)
        {
            if(player.Name == "Dealer")
            {
                if (player.Score > 21) {
                    Console.WriteLine($"{player.Name} busts!\nwith the hand {player.DisplayCurrentHand()}");
                    Console.WriteLine("You beat the dealer!");
                    return true;
                }
                return false;
            }
            else
            {
                if (player.Score > 21) {
                    Console.WriteLine($"You are currently at a Bust!\nwith the hand {player.DisplayCurrentHand()}");
                    Console.WriteLine("The dealer wins!");
                    return true;
                }
                return false;
            }
            
        }

        public void CheckScores(Player player, Player dealer)
        {
            if (player.Score == dealer.Score)
            {
                System.Console.WriteLine("Tie game! Both player and dealer have the same score!");
            } 
            else if (player.Score > dealer.Score)
            {
                Console.WriteLine($"The player wins! {player.Score} to {dealer.Score}.");
            }
            else
            {
                Console.WriteLine($"The dealer wins! {dealer.Score} to {player.Score}.");
            }
        }

    }
}

// DEBUGGING COMMENTS
// System.Console.WriteLine($"PLAYER: current hand is {newPlayer.DisplayCurrentHand()}");
// System.Console.WriteLine($"DEALER: current hand is {dealer.DisplayCurrentHand()}");
// System.Console.WriteLine($"PLAYER score is {newPlayer.Score}");
// System.Console.WriteLine($"DEALER score is {dealer.Score}");