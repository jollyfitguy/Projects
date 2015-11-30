using MegaChallengeWar.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
                      
        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(random);

            string result = "";
            
            result += "<h2>Dealing out cards ...</h2><br/>";
            result += game.DealCards() + "<br/>";
            
            result += "<h2>Begin Game</h2><br/>";
            result += game.PlayGame();

            resultLabel.Text = result;


            if (game.Player1.Cards.Count == game.Player2.Cards.Count)
            {
                winnerLabel.ForeColor = System.Drawing.Color.Black;
                winnerLabel.Text += "<b>Tie game</b><br/>";
            }
            else if (game.Player1.Cards.Count > game.Player2.Cards.Count)
            {
                winnerLabel.ForeColor = System.Drawing.Color.Red;
                winnerLabel.Text = String.Format("<b>Player 1 wins the war!</b><br/>");
            }
            else
            {
                winnerLabel.ForeColor = System.Drawing.Color.Blue;
                winnerLabel.Text = String.Format("<b>Player 2 wins the war!</b>");
            }
            player1ScoreLabel.Text = String.Format("<b>Player 1: {0}</b>", game.Player1.Cards.Count);
            player2ScoreLabel.Text = String.Format("<b>Player 2: {0}</b>", game.Player2.Cards.Count);

            System.GC.Collect();
        }
    }
}