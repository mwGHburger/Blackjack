using System;
namespace Blackjack
{
    public class Card
    {
        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public string Rank { get; private set; }
        public string Suit { get; private set; }

        private static bool CardIsRoyal(Card card)
        {
            return card.Rank == ("JACK") || card.Rank == ("QUEEN") || card.Rank == ("KING");
        }

        public static int DetermineCardValue(Card card, int total)
        {
            int cardValue = 0;
            if (CardIsRoyal(card))
            {
                cardValue += 10;
            }
            else if (card.Rank == "ACE")
            {
                cardValue += total < 11 ? 11 : 1;
            }
            else
            {
                cardValue += Convert.ToInt32(card.Rank);
            }
            
            return cardValue;
        }
    }
}