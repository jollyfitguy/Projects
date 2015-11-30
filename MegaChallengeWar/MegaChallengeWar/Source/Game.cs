using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar.Source
{
    public class Game
    {
        public Deck Deck { get; set; }
        public Hand Player1 { get; set; }
        public Hand Player2 { get; set; }
        public int Rounds { get; set; }        
        private List<Card> _bounty;

        public string ListPlayerHand(Hand player)
        {
            string result = "";
            foreach (Card card in player.Cards)
            {
                result += String.Format("&nbsp;&nbsp;{0}<br/>", card.ToString());
            }
            return result;
        }

        public Game (Random random)
        {
            Deck = new Deck(random);
            Player1 = new Hand();
            Player2 = new Hand();            
            Rounds = 20;            
            _bounty = new List<Card>();
        }
        public string DealCards()
        {
            string result = "";
            Card card;     
            while (Deck.Cards.Count > 0)
            {
                card = Deck.DealCard();
                result += String.Format("Player 1 is dealt the {0}.<br/>", card.ToString());
                Player1.AddCard(card);
                card = Deck.DealCard();
                result += String.Format("Player 2 is dealt the {0}.<br/>", card.ToString());
                Player2.AddCard(card);
            }
            return result;
        }

        private void addBounty(Card card)
        {            
            _bounty.Add(card);            
        }

        public string PlayRound ()
        {
            Card player1WarCard = Player1.PlayCard();
            Card player2WarCard = Player2.PlayCard();

            addBounty(player1WarCard);
            addBounty(player2WarCard);

            string result = String.Format("{0} <b>vs</b> {1}<br/>",                 
                player1WarCard.ToString(), 
                player2WarCard.ToString());

            if(player1WarCard.isSameKind(player2WarCard))
            {
                result += "<b>***********WAR*************</b><br/>";
                result += beginWar();
            }
            else if (player1WarCard.isBetterThan(player2WarCard))
            {
                result += String.Format("Bounty:<br/>{0}", rakeCards(Player1));
                result += "<b>Player 1 wins!</b><br/><br/>";
            }
            else
            {
                result += String.Format("Bounty:<br/>{0}", rakeCards(Player2));
                result += "<b>Player 2 wins!</b><br/><br/>";               
            }

            return result;
        }

        private string beginWar()
        {            
            for (int i = 0; i < 3; i++)
            {
                if(Player1.Cards.Count > 1)
                    _bounty.Add(Player1.PlayCard());                
            }
            for (int i = 0; i < 3; i++)
            {
                if (Player2.Cards.Count > 1)
                    _bounty.Add(Player2.PlayCard());
            }
            return PlayRound();
        }

        private string rakeCards(Hand winner)
        {
            string result = "";
            foreach (Card card in _bounty)
            {
                result += "&nbsp;&nbsp;" + card.ToString() + "<br/>";
                winner.AddCard(card);                
            }
            _bounty = new List<Card>();
            return result;
        }

        public string PlayGame()
        {
            string result = "";
            /*
            int i = 0;
            while (Player1.Cards.Count > 0 && Player2.Cards.Count > 0)
            {
                result += String.Format("<b>Round {0}</b><br/>{1}", ++i, PlayRound());
            }
            */
            
            for (int i = 0; i < Rounds; i++)
            {
                result += String.Format("<b>Round {0}</b><br/>{1}", i + 1, PlayRound());
            }
            
            return result;
            
        }
        public string DisplayPlayerCardTotals(Hand player)
        {
            return String.Format("<b>Player 1: {0}</b><br/><b>Player 2: {1}</b>", Player1.Cards.Count, Player2.Cards.Count);
        }
    }
}