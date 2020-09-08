using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        public Deck()
        {
            this.Cards = new List<Card>(this.CreateNewDeck());
            this.Size = this.Cards.Count;
        }

        public List<Card> Cards
        { 
            get; 
            private set; 
        }
        
        private int size;
        public int Size
        { 
            get {return this.Cards.Count; }
            private set {this.size = value; }
        }

        private List<Card> CreateNewDeck()
        {
            List<string> suits = new List<string> {
                "DIAMOND",
                "HEARTS",
                "CLUBS",
                "SPADE"
            };

            List<string> ranks = new List<string> {
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "JACK",
                "QUEEN",
                "KING",
                "ACE"
            };

            List<Card> cardDeck = new List<Card>();

            foreach (string rank in ranks)
            {
                foreach (string suit in suits)
                {
                    cardDeck.Add(new Card(rank, suit));
                }
            }
            
            return cardDeck;
        }

        public void DealCardTo(Player player, int positionInDeck)
        {
            player.AddCardToHand(this.Cards[positionInDeck]);
        }

        public int PickRandomCardFromDeck()
        {
            Random rnd = new Random(); // TODO: CAN PROBABLY MOVE THIS OUT

            int positionInDeck = PickRandomCard(this.Size, rnd);
            return positionInDeck;
        }
        
        private int PickRandomCard(int deckSize, Random obj)
        {
            return obj.Next(deckSize);
        }

    }
}
