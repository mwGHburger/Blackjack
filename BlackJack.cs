using System;

namespace Blackjack
{
    public class BlackJack
    {
        public BlackJack()
        {}

        public void StartGame()
        {
            var cardDeck = new Deck();
            Player player = new Player();
            Player dealer = new Dealer();
            this.DealTwoCardsToEachPlayer(cardDeck, player, dealer);
            
            player.BeginTurn(cardDeck);

            if (this.IsBust(player))
            {
                DeclareWinnerFromBust(player);
                return;
            }

            dealer.BeginTurn(cardDeck);

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
                int positionInDeck = cardDeck.PickRandomCardFromDeck();
                cardDeck.DealCardTo(player, positionInDeck);
                cardDeck.Cards.RemoveAt(positionInDeck);

                int positionInDeck2 = cardDeck.PickRandomCardFromDeck();
                cardDeck.DealCardTo(dealer, positionInDeck2);
                cardDeck.Cards.RemoveAt(positionInDeck2);
            }
        }

        public static void HitPlayer(Player player, Deck cardDeck)
        {
            int positionInDeck = cardDeck.PickRandomCardFromDeck();
            cardDeck.DealCardTo(player, positionInDeck);
            DisplayCardDrawn(player, cardDeck, positionInDeck);
            cardDeck.Cards.RemoveAt(positionInDeck);
        }

        private bool IsBust(Player player)
        {
            return (player.Score > BUSTNUMBER) ? true : false;
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

        private static void DisplayCardDrawn(Player player, Deck cardDeck, int positionInDeck)
        {
            System.Console.WriteLine($"{player.Name} draw [{cardDeck.Cards[positionInDeck].Rank}, '{cardDeck.Cards[positionInDeck].Suit}']\n");
        }
        public const int BUSTNUMBER = 21;
    }
}
