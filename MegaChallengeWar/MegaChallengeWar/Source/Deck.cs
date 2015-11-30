using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaChallengeWar.Source
{
    public class Deck
    {
        static public List<string> Kinds = new List<string>
        {
            "2","3","4","5","6","7","8","9","10","Jack","Queen","King","Ace"
        };
        static public List<string> Suits = new List<string>
        {
            "Spades","Diamonds","Clubs","Hearts"
        };

        public List<Card> Cards { get; set; }

        private Random _random;        

        public Deck (Random random)
        {
            Cards = new List<Card>();
            _random = random;
            foreach (string suit in Suits)
                foreach(string kind in Kinds)
                    Cards.Add(new Card() { Kind = kind, Suit = suit });
        }

        public Card DealCard()
        {
            int index = _random.Next(0, Cards.Count);
            Card card = Cards.ElementAt(index);
            Cards.RemoveAt(index);
            return card;
        }
        
    }
}
