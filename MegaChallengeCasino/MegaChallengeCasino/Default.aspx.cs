using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

                string[] reels = spinAllReels();
                ViewState.Add("Money", 100);
                displayMoney();
            }
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {

            double bet = 0;
            if (validateBet(out bet)) 
                pullLever(bet);
            else            
                resultLabel.Text = "Please enter a positive numeric value that is less than or equal to your current money.";
            displayMoney();
        }

        private bool validateBet(out double bet)
        {
            if (double.TryParse(betTextBox.Text, out bet) && bet > 0 && bet <= double.Parse(ViewState["Money"].ToString()))
                return true;
            else
                return false;
        }

        private void pullLever (double bet)
        {            
            string[] reels = spinAllReels();            
            displayResult(reels, bet);
        }

        private void displayResult(string[] reels, double bet)
        {
            double winnings = determineWinnings(reels, bet);
            if (winnings > 0)
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}", bet, winnings);
            else
                resultLabel.Text = String.Format("You lost {0:C}. Better luck next time!", bet);
            adjustMoney(bet, winnings);
        }

        private void adjustMoney(double bet, double winnings)
        {
            double money = double.Parse(ViewState["Money"].ToString());
            money -= bet;
            money += winnings;
            ViewState["Money"] = money;
        }

        private double determineWinnings(string[] reels, double bet)
        {
            return bet * determineMultiplier(reels);

        }
   
        private double determineMultiplier(string[] reels)

        {
            int cherryCount = cherriesCount(reels); ;
            if (isBar(reels)) return 0;
            else if (isJackpot(reels)) return 100;
            else if (cherryCount > 0) return cherriesCount(reels) + 1; 
            return 0;
        }

        private bool isBar(string[] reels)
        {
            if (reels[0] == "Bar" || reels[1] == "Bar" || reels[2] == "Bar")
                return true;
            else
                return false;
        }

        private bool isJackpot(string[] reels)
        {
            if (reels[0] == "Seven" && reels[1] == "Seven" && reels[2] == "Seven")

                return true;
            else
                return false;
        }

        private int cherriesCount(string[] reels)

        {
            int cherryCount = 0;
            for (int i = 0; i < reels.Length; i++)
            {
                if (reels[i] == "Cherry")
                    cherryCount++;
            }           
            return cherryCount;
        }


        private string[] spinAllReels()
        {
            string[] reels = new string[] { spinReel(), spinReel(), spinReel() };
            reelImage1.ImageUrl = "/Images/" + reels[0] + ".png";
            reelImage2.ImageUrl = "/Images/" + reels[1] + ".png";
            reelImage3.ImageUrl = "/Images/" + reels[2] + ".png";
            return reels;
        }

        private string spinReel()
        {
            string[] image = new string[] { "Bar", "Bell", "Cherry", "Clover", "Diamond", "HorseShoe", "Lemon",
                "Orange", "Plum", "Seven", "Strawberry", "Watermelon" };
            return image[random.Next(11)];
        }

        private void displayMoney()
        {
            moneyLabel.Text = String.Format("Player's Money: {0:C}", ViewState["Money"]);

        }
    }
}