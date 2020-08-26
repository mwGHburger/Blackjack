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
            // PICK CARD AND ADD TO HAND
            System.Console.WriteLine($"{player.Name} hits...");
            System.Console.WriteLine($"Dealing card to {player.Name}...");
            int positionInDeck = PickRandomCard(this.Size, rnd);
            System.Console.WriteLine($"Deck position at {positionInDeck}");
            player.AddCardToHand(this.Cards[positionInDeck]);
            System.Console.WriteLine($"{player.Name} draws [{this.Cards[positionInDeck][0]}, {this.Cards[positionInDeck][1]}]");
            // REMOVE CARD FROM DECK
            System.Console.WriteLine("Removing Card from the Deck");
            this.Cards.RemoveAt(positionInDeck);
            Console.WriteLine($"Deck size is now {this.Size}\n");
            // UPDATE PLAYER SCORE
            player.CalculateScore();
        }
        private int PickRandomCard(int deckSize, Random obj)
        {
            return obj.Next(deckSize);
        }
    }
}

// DEBUGGING COMMENTS:
// Random rnd = new Random(); // TODO: CAN PROBABLY MOVE THIS OUT
// // PICK CARD AND ADD TO HAND
// System.Console.WriteLine($"{player.Name} hits...");
// System.Console.WriteLine($"Dealing card to {player.Name}...");
// int positionInDeck = PickRandomCard(this.Size, rnd);
// System.Console.WriteLine($"Deck position at {positionInDeck}");
// player.AddCardToHand(this.Cards[positionInDeck]);
// System.Console.WriteLine($"{player.Name} draws [{this.Cards[positionInDeck][0]}, {this.Cards[positionInDeck][1]}]");
// // REMOVE CARD FROM DECK
// System.Console.WriteLine("Removing Card from the Deck");
// this.Cards.RemoveAt(positionInDeck);
// Console.WriteLine($"Deck size is now {this.Size}\n");
// // UPDATE PLAYER SCORE
// player.CalculateScore();