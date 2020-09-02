using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        // ENUMS
        enum Suits {
                DIAMOND,
                HEARTS,
                SPADES,
                CLUBS
            };

        // CONSTRUCTOR
        public Deck()
        {
            this.Cards = new List<List<string>>(this.CreateNewDeck());
            this.Size = this.Cards.Count;
        }

        // PROPERTIES
        public List<List<string>> Cards
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

        //private List<List<string>> CreateNewDeck()
        private List<List<string>> CreateNewDeck()
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

            List<List<string>> cardDeck = new List<List<string>>();

            foreach (string rank in ranks)
            {
                foreach (string suit in suits)
                {
                    cardDeck.Add(new List<string> {rank, suit});
                }
            }

            return cardDeck;
        }

        // TODO: NOT A FAN THAT THIS METHOD RETURNS INT
        public int DealCardTo(Player player)
        {
            Random rnd = new Random(); // TODO: CAN PROBABLY MOVE THIS OUT

            int positionInDeck = PickRandomCard(this.Size, rnd);
            player.AddCardToHand(this.Cards[positionInDeck]);
            return positionInDeck;
        }
        private int PickRandomCard(int deckSize, Random obj)
        {
            return obj.Next(deckSize);
        }

        public static int DetermineCardValue(List<string> card, int total)
        {
            int cardValue = 0;
            if (card.Contains("JACK") || card.Contains("QUEEN") || card.Contains("KING"))
            {
                cardValue += 10;
            }
            else if (card[0] == "ACE")
            {
                cardValue += total < 11 ? 11 : 1;
            }
            else
            {
                cardValue += Convert.ToInt32(card[0]);
            }
            return cardValue;
        }
    }
}
