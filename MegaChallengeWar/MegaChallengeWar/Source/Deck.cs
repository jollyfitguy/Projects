using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaChallengeWar.Source
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        private Random _random;

        public Deck (Random random)
        {
            Cards = new List<Card>();
            _random = random;
            foreach (string suit in Card.Suits)
                foreach(string kind in Card.Kinds)
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
