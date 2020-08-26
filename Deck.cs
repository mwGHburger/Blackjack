using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        // CONSTRUCTOR
        public Deck()
        {
            this.Cards = new List<List<string>>(CreateDeck());
            this.Size = this.Cards.Count;
        }

        // PROPERTIES
        public List<List<string>> Cards
        { get; set; }

        public int Size
        { 
            get { return this.Cards.Count; } 
            private set { this.Size = value; }
        }

        public static List<List<string>> CreateDeck()
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
        
    }
}