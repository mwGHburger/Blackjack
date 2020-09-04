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
            this.CardHand = new List<Card>();
            this.Score = 0;
        }

        // PROPERTIES
        public string Name
        {
            get; 
            private set;
        }

        public List<Card> CardHand
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
            foreach(Card card in this.CardHand)
            {
                cardList.Add($"[{card.Rank}, '{card.Suit}']");
            }
            string currentHand = $"[{string.Join(",", cardList)}]";
            return currentHand;
        }
        public int CalculateScore()
        {
            int total = 0;
            foreach(Card card in this.CardHand)
            {
                total += Card.DetermineCardValue(card, total);
            }
            return total;
        }

        public void AddCardToHand(Card card)
        {
            this.CardHand.Add(card);
        }

    }
}