using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Darts;

namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {
        private Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void okButton_Click(object sender, EventArgs e)
        {

            //Dart dart = new Dart(random);
            //dart.Throw();

            //resultLabel.Text = String.Format("Dart landed on {0} with ringmultiplier {1}x", dart.Score, dart.RingMultiplier);

            int games = 1000000;

            Statistics player1Stats = new Statistics(games);
            Statistics player2Stats = new Statistics(games);

            for (int i = 0; i < player1Stats.Length; i++)
            {
                Game game = new Game();
                game.Play();

                if (game.Player1Score > game.Player2Score)
                {
                    player1Stats.AddGameResult(1);
                    player2Stats.AddGameResult(0);
                }
                else
                {
                    player1Stats.AddGameResult(0);
                    player2Stats.AddGameResult(1);
                }
            }






            resultLabel.Text = String.Format("Player 1 won : {0}% of the time.<br/>Player 2 won : {1}% of the time.<br/>",
                player1Stats.GetWinPercentage().ToString(),
                player2Stats.GetWinPercentage().ToString());

        }
    }
}