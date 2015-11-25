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
            Game game = new Game();

            game.Play();

            string winningPlayer = "";

            if (game.Player1Score > game.Player2Score)
                winningPlayer = "Player 1";
            else
                winningPlayer = "Player 2";

            resultLabel.Text = String.Format("Player 1: {0}<br/>Player 2: {1}<br/>{2} wins!",
                game.Player1Score,
                game.Player2Score,
                winningPlayer);

        }
    }
}