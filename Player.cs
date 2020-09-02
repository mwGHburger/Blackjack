using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player
    {
        // CONSTRUCTOR
        public Player(string name)
        {
            this.Name = name;
            this.CardHand = new List<List<string>>();
            this.Score = 0;
        }

        // PROPERTIES
        public string Name
        {
            get; 
            private set;
        }

        public List<List<string>> CardHand
        {
            get;
        }

        public int Score
        {
            get 
            {
                return CalculateScore();
            }

            private set{}
        }

        // METHODS
        public string GetCurrentHand()
        {
            List<string> cardList = new List<string>();
            foreach(List<string> card in this.CardHand)
            {
                cardList.Add($"[{card[0]}, '{card[1]}']");
            }
            string currentHand = $"[{string.Join(",", cardList)}]";
            return currentHand;
        }
        public int CalculateScore()
        {
            int total = 0;
            foreach(List<string> card in this.CardHand)
            {
                total += Deck.DetermineCardValue(card, total);
            }
            return total;
        }

        public void AddCardToHand(List<string> card)
        {
            this.CardHand.Add(new List<string> {card[0], card[1]});
        }

    }
}