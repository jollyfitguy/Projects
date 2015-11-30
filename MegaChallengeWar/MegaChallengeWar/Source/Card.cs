using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Source
{
    public class Card
    {
        public string Kind { get; set; }
        public string Suit { get; set; }
        
        override public string ToString()
        {
            return Kind + " of " + Suit;
        }

        public bool isSameKind(Card card)
        {
            if (Kind == card.Kind)
                return true;
            else
                return false;
        }
        public bool isBetterThan(Card card)
        {
            if (Deck.Kinds.IndexOf(Kind) > Deck.Kinds.IndexOf(card.Kind))
                return true;
            else
                return false;
        }
    }
}