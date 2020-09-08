using System;

namespace Blackjack
{
    public class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            Name = "You";
        }
        public override void PlayTurn(Deck cardDeck)
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