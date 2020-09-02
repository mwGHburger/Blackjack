using System;

namespace Blackjack
{
    public class BlackJack
    {
        // CONSTRUCTOR
        public BlackJack()
        {}

        // METHODS
        public void StartGame()
        {
            var cardDeck = new Deck();
            Player player = new Player("You");
            Player dealer = new Player("Dealer");

            this.DealTwoCardsToEachPlayer(cardDeck, player, dealer);

            System.Console.WriteLine($"Game starts from here...\n");
            
            this.BeginPlayerTurn(player, cardDeck);

            if (this.IsBust(player))
            {
                DeclareWinnerFromBust(player);
                return;
            }

            this.BeginDealerTurn(dealer, cardDeck);

            if(this.IsBust(dealer))
            {
                DeclareWinnerFromBust(dealer);
                return;
            }

            this.CheckScores(player, dealer);
        }

        private void DealTwoCardsToEachPlayer(Deck cardDeck, Player player, Player dealer)
        {
            for(int i = 0; i < 2; i++)
            {
                int positionInDeck = cardDeck.DealCardTo(player);
                cardDeck.Cards.RemoveAt(positionInDeck);

                int positionInDeck2 = cardDeck.DealCardTo(dealer);
                cardDeck.Cards.RemoveAt(positionInDeck2);
            }
        }

        private void BeginPlayerTurn(Player player, Deck cardDeck)
        {
            while (player.Score < BUSTNUMBER)
            {
                Console.WriteLine($"You are currently at {player.Score}\nwith the hand {player.GetCurrentHand()}\n");
                Console.Write("Hit or stay? (Hit = 1, Stay = 0): ");
                string playerInput = Console.ReadLine();
                if (playerInput == "1")
                {
                    HitPlayer(player, cardDeck);
                }
                else
                {
                    break;
                }
            }
        }

        private void BeginDealerTurn(Player player, Deck cardDeck)
        {
            while (player.Score < BUSTNUMBER)
            {
                Console.WriteLine($"{player.Name} is at {player.Score}\nwith the hand {player.GetCurrentHand()}\n");
                if (player.Score < 17)
                {
                    System.Console.WriteLine("Dealer hits...");
                    HitPlayer(player, cardDeck);
                }
                else
                {
                    System.Console.WriteLine($"{player.Name} can decide to stay...\n");
                    break;
                }
            }
        }

        private void HitPlayer(Player player, Deck cardDeck)
        {
            int positionInDeck = cardDeck.DealCardTo(player);
            //player.CalculateScore();
            DisplayCardDrawn(player, cardDeck, positionInDeck);
            cardDeck.Cards.RemoveAt(positionInDeck);
            System.Console.WriteLine($"Deck size is {cardDeck.Size}");
        }

        private bool IsBust(Player player)
        {
            if (player.Score > BUSTNUMBER) {
                return true;
            }
            return false;
        }

        private void DeclareWinnerFromBust(Player player)
        {
            if (player.Name == "Dealer")
            {
                Console.WriteLine($"{player.Name} busts!\nwith the hand {player.GetCurrentHand()}");
                Console.WriteLine("You beat the dealer! Dealer busted.");
            }
            else
            {
                Console.WriteLine($"You are currently at a Bust!\nwith the hand {player.GetCurrentHand()}");
                Console.WriteLine($"Dealer wins! You busted.");
            }
        }

        private void DeclareWinner(Player player1, Player player2, bool isTie = false)
        {
            if(isTie)
            {
                Console.WriteLine($"Tie game! Both player and dealer have the same score! {player1.Score} to {player2.Score}");
                return;
            }
            
            if (player1.Name == "Dealer")
            {
                Console.WriteLine($"Dealer wins! {player2.Score} to {player1.Score}.");
                return;
            }
            else
            {
                Console.WriteLine($"You win! {player1.Score} to {player2.Score}.");
                return;
            }
        }

        private void CheckScores(Player player, Player dealer)
        {
            if (player.Score == dealer.Score)
            {
                DeclareWinner(player, dealer, true);
            } 
            else if (player.Score > dealer.Score)
            {
                DeclareWinner(player, dealer);
            }
            else
            {
                DeclareWinner(dealer, player);
            }
        }

        private void DisplayCardDrawn(Player player, Deck cardDeck, int positionInDeck)
        {
            System.Console.WriteLine($"{player.Name} draw [{cardDeck.Cards[positionInDeck][0]}, '{cardDeck.Cards[positionInDeck][1]}']\n");
        }

        // CONSTANT
        private const int BUSTNUMBER = 21;
    }
}
