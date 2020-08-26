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
            get; set;
        }

        // METHODS
        public string DisplayCurrentHand()
        {
            List<string> cardList = new List<string>();
            foreach(List<string> card in this.CardHand)
            {
                cardList.Add($"[{card[0]}, {card[1]}]");
            }
            string display = $"[{string.Join(",", cardList)}]";
            return display;
        }
        public void CalculateScore()
        {
            int total = 0;
            foreach(List<string> card in this.CardHand)
            {
                total += DetermineCardValue(card, total);
            }
            this.Score = total;
        }

        public void AddCardToHand(List<string> card)
        {
            this.CardHand.Add(new List<string> {card[0], card[1]});
        }

        private int DetermineCardValue(List<string> card, int total)
        {
            int cardValue = 0;
            if (card[0] == "JACK" || card[0] == "QUEEN" || card[0] == "KING")
            {
                cardValue += 10;
            }
            else if (card[0] == "ACE")
            {
                if (total < 11) {
                    cardValue += 11;
                }
                else
                {
                    cardValue += 1;
                }
            }
            else
            {
                cardValue = Convert.ToInt32(card[0]);
            }
            return cardValue;
        }
    }
}