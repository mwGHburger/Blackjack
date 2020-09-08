using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Player
    {
        public Player()
        {
            this.Name = "You";
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
            get 
            {
                return CalculateScore();
            }

            private set{}
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
        public int CalculateScore()
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
                    total += Card.DetermineCardValue(card, total);
                }
            }
            foreach(Card ace in aceTracker)
            {
                total += Card.DetermineCardValue(ace, total);
            }
            return total;
        }

        public void AddCardToHand(Card card)
        {
            this.CardHand.Add(card);
        }

        public virtual void PlayTurn(Deck cardDeck)
        {
            while (Score < BlackJack.BUSTNUMBER)
            {
                Console.WriteLine($"You are currently at {Score}\nwith the hand {GetCurrentHand()}\n");
                Console.Write("Hit or stay? (Hit = 1, Stay = 0): ");
                string playerInput = Console.ReadLine();
                if (playerInput == "1")
                {
                    BlackJack.HitPlayer(this, cardDeck);
                }
                else
                {
                    break;
                }
            }
        }

    }
}