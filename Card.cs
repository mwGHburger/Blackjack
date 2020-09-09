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

        private bool CardIsRoyal()
        {
            return this.Rank == ("JACK") || this.Rank == ("QUEEN") || this.Rank == ("KING");
        }

        private bool CardIsAce()
        {
            return this.Rank == ("ACE");
        }

        public int DetermineCardValue(int total)
        {
            int cardValue = 0;
            if (CardIsRoyal())
            {
                cardValue += 10;
            }
            else if (CardIsAce())
            {
                cardValue += total < 11 ? 11 : 1;
            }
            else
            {
                cardValue += Convert.ToInt32(this.Rank);
            }
            
            return cardValue;
        }
    }
}