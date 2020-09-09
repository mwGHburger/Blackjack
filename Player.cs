using System;
using System.Collections.Generic;

namespace Blackjack
{
    public abstract class Player
    {
        public Player()
        {
            this.CardHand = new List<Card>();
            this.Score = 0;
        }

        public string Name
        {
            get; 
            protected set;
        }

        public List<Card> CardHand
        {
            get;
        }

        public int Score
        {
            get;
            private set;
        }

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
        public void CalculateScore()
        {
            int total = 0;
            List<Card> aceTracker = new List<Card>();
            foreach(Card card in this.CardHand)
            {
                if (card.Rank == "ACE")
                {
                    aceTracker.Add(card);
                }
                else
                {
                    total += card.DetermineCardValue(total);
                }
            }
            foreach(Card ace in aceTracker)
            {
                total += ace.DetermineCardValue(total);
            }
            this.Score = total;
        }

        public void AddCardToHand(Card card)
        {
            this.CardHand.Add(card);
        }

        public abstract void PlayTurn(Deck cardDeck);
    }
}