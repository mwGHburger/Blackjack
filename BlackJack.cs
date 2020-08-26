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
            Player newPlayer = new Player("You");
            Player dealer = new Player("Dealer");

            blackJack.DealTwoCardsToEachPlayer(cardDeck, newPlayer, dealer);

            System.Console.WriteLine($"Game starts from here...\n");
            
            blackJack.BeginPlayerTurn(newPlayer, cardDeck);

            if (blackJack.CheckForBust(newPlayer))
            {
                return;
            }

            blackJack.BeginDealerTurn(dealer, cardDeck);

            if(blackJack.CheckForBust(dealer))
            {
                return;
            }

            blackJack.CheckScores(newPlayer, dealer);
        }

        public void DealTwoCardsToEachPlayer(Deck cardDeck, Player player, Player dealer)
        {
            for(int i = 0; i < 2; i++)
            {
                cardDeck.DealCardTo(player);
                cardDeck.DealCardTo(dealer);
            }
        }

        public void BeginPlayerTurn(Player player, Deck cardDeck)
        {
            while (player.Score < 21)
            {
                Console.WriteLine($"You are currently at {player.Score}\nwith the hand {player.DisplayCurrentHand()}\n");
                Console.Write("Hit or stay? (Hit = 1, Stay = 0): ");
                string playerInput = Console.ReadLine();
                if (playerInput == "1")
                {
                    cardDeck.DealCardTo(player);
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
                Console.WriteLine($"{player.Name} is at {player.Score}\nwith the hand {player.DisplayCurrentHand()}\n");
                if (player.Score < 17)
                {
                    System.Console.WriteLine("Dealer hits...");
                    cardDeck.DealCardTo(player);
                }
                else
                {
                    System.Console.WriteLine($"{player.Name} can decide to stay...\n");
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
                    Console.WriteLine("You beat the dealer! Dealer busted.");
                    return true;
                }
                return false;
            }
            else
            {
                if (player.Score > 21) {
                    Console.WriteLine($"You are currently at a Bust!\nwith the hand {player.DisplayCurrentHand()}");
                    Console.WriteLine($"Dealer wins! You busted.");
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
                Console.WriteLine($"You win! {player.Score} to {dealer.Score}.");
            }
            else
            {
                Console.WriteLine($"Dealer wins! {dealer.Score} to {player.Score}.");
            }
        }

    }
}
