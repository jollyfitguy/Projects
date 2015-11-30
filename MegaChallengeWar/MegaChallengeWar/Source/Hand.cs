using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Source
{
    public class Hand
    {
        public Queue<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new Queue<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Enqueue(card);
        }
        public Card PlayCard()
        {
            return Cards.Dequeue();
        }

    }
}