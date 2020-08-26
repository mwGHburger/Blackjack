using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
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

        public void DealCardTo(Player player)
        {
            Random rnd = new Random(); // TODO: CAN PROBABLY MOVE THIS OUT

            int positionInDeck = PickRandomCard(this.Size, rnd);
            player.AddCardToHand(this.Cards[positionInDeck]);
            System.Console.WriteLine($"{player.Name} draw [{this.Cards[positionInDeck][0]}, '{this.Cards[positionInDeck][1]}']\n");
            this.Cards.RemoveAt(positionInDeck);
            player.CalculateScore();
        }
        private int PickRandomCard(int deckSize, Random obj)
        {
            return obj.Next(deckSize);
        }
    }
}
