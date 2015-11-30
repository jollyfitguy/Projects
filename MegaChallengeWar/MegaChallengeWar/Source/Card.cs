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

        static public List<string> Kinds = new List<string>
        {
            "2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace"
        };
        static public List<string> Suits = new List<string>
        {
            "Spades","Diamonds","Clubs","Hearts"
        };
        
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
            if (Kinds.IndexOf(Kind) > Kinds.IndexOf(card.Kind))
                return true;
            else
                return false;
        }

    }
}