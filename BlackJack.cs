using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class BlackJack
    {
        public BlackJack()
        {}

        public void StartGame()
        {
            var cardDeck = new Deck();
            var playerList = new List<Player>();
            HumanPlayer humanPlayer = new HumanPlayer();
            Dealer dealer = new Dealer();
            playerList.Add(humanPlayer);
            playerList.Add(dealer);
            this.DealTwoCardsToEachPlayer(cardDeck, humanPlayer, dealer);
            foreach(Player player in playerList)
            {
                player.PlayTurn(cardDeck);
                if (this.IsBust(player))
                {
                    DeclareWinnerFromBust(player);
                    return;
                }
            }
            this.CheckScores(humanPlayer, dealer);
        }

        private void DealTwoCardsToEachPlayer(Deck cardDeck, HumanPlayer player, Dealer dealer)
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

        private void DeclareWinner(HumanPlayer humanPlayer, Dealer dealer, bool isTie = false)
        {
            if(isTie)
            {
                Console.WriteLine($"Tie game! Both player and dealer have the same score! {humanPlayer.Score} to {dealer.Score}");
                return;
            }
            
            if (humanPlayer.Score < dealer.Score)
            {
                Console.WriteLine($"Dealer wins! {dealer.Score} to {humanPlayer.Score}.");
                return;
            }
            else
            {
                Console.WriteLine($"You win! {humanPlayer.Score} to {dealer.Score}.");
                return;
            }
        }

        private void CheckScores(HumanPlayer player, Dealer dealer)
        {
            if (player.Score == dealer.Score)
            {
                DeclareWinner(player, dealer, true);
            } 
            else
            {
                DeclareWinner(player, dealer);
            }
        }

        private static void DisplayCardDrawn(Player player, Deck cardDeck, int positionInDeck)
        {
            System.Console.WriteLine($"{player.Name} draw [{cardDeck.Cards[positionInDeck].Rank}, '{cardDeck.Cards[positionInDeck].Suit}']\n");
        }
        public const int BUSTNUMBER = 21;
    }
}
