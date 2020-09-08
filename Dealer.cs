using System;

namespace Blackjack
{
    public class Dealer : Player
    {
        public Dealer()
        {
            Name = "Dealer";
        }

        public override void PlayTurn(Deck cardDeck)
        {
            while (Score < BlackJack.BUSTNUMBER)
            {
                Console.WriteLine($"{Name} is at {Score}\nwith the hand {GetCurrentHand()}\n");
                if (Score < 17)
                {
                    System.Console.WriteLine("Dealer hits...");
                    BlackJack.HitPlayer(this, cardDeck);
                }
                else
                {
                    System.Console.WriteLine($"{Name} decided to stay...\n");
                    break;
                }
            }
        }

    }
}