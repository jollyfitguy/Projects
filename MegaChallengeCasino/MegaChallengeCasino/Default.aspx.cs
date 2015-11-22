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
        double money = 100;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState.Add("money", money);
                spinReels();   //Generate Reel images
                displayMoney();     //display starting values
            }
        }

        protected void goButton_Click(object sender, EventArgs e)
        {

            money = (double)ViewState["money"];           
            double bet = 0;
            if (tryTakeBet(out bet) && validateBet(bet) && validateMoney(bet)) 
            {
                spinReels();     //Generate Reel images
                updateMoney(-bet);    //subract bet from money
                resultLabel.Text = "";
            }
            double multiplier = getMultiplier();
            updateMoney(bet * multiplier);
            displayResult(bet, multiplier);            
            displayMoney();
        }
        
        //sets the reel images to random images.
        private void spinReels()
        {
            reelImage1.ImageUrl = getSpunReelImage();
            reelImage2.ImageUrl = getSpunReelImage();
            reelImage3.ImageUrl = getSpunReelImage();
        }

        // returns the image as a imageURL
        private string getSpunReelImage()

        {
            return "..\\Images\\" + spinReel() + ".png";
        }


        // picks a random image out of an array
        private string spinReel()

        {
            string[] images = new string[] {"Bar","Bell","Cherry","Clover","Diamond","HorseShoe","Lemon",
                "Orange", "Plum", "Seven", "Strawberry", "Watermelon"};
            return images[random.Next(11)];
        }
   
        // updates the money

        private void updateMoney(double amount)
        {
            money = (double)ViewState["money"];
            money += amount;
            ViewState["money"] = money;
        }

        // validates if player has enough money to back bet
        private bool validateMoney(double bet)

        {
            if (money - bet < 0)
            {
                resultLabel.Text = "You don't have that much money!";
                return false;
            }
            else

                return true;                    
        }

        // validates that the bet is positive
        private bool validateBet(double bet)
        {
            if (bet <= 0)
            {

                resultLabel.Text = "Please enter a positive bet.";

                return false;
            }
            else
                return true;
        }

        // validates that the bet is a numeric value
        private bool tryTakeBet(out double bet)
        {
            if(!double.TryParse(betTextBox.Text, out bet))
            {
                resultLabel.Text = "Please enter a valid number.";
                return false;
            }
            return true;
        }

        // updates moneyLabel.text with the value of the player's money
        private void displayMoney()
        {
            moneyLabel.Text = string.Format("Player's Money: {0:C}", (double)ViewState["money"]);
        }

        // displays the result of the bet
        private void displayResult(double bet, double multiplier)
        {
            if (multiplier < 1)
                resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time", bet);
            else
                resultLabel.Text = String.Format("You bet {0:C} and won {1:C}", bet, bet * multiplier);
        }

        // determines if a bar has shown up.
        private bool hasBar()
        {
            if (reelImage1.ImageUrl.Contains("Bar.png") || reelImage2.ImageUrl.Contains("Bar.png") || reelImage3.ImageUrl.Contains("Bar.png"))
                return true;
            else
                return false;
        }

        // determines if Jackpot has happened.
        private bool isJackpot()
        {
            if (reelImage1.ImageUrl.Contains("Seven") && reelImage2.ImageUrl.Contains("Seven.png") && reelImage3.ImageUrl.Contains("Seven"))
                return true;
            else
                return false;
        }

        // calculates the multiplier based on the outcome of the spin.
        private double getMultiplier()
        {
            double multiplier;
            if (hasBar()) multiplier = 0;
            else if (isJackpot()) multiplier = 100;
            else if (countCherries() > 0) multiplier = countCherries() + 1;
            else multiplier = 0;
            return multiplier;
        }

        // counts the number cherries in the reel
        private int countCherries()
        {
            int count = 0;
            if (reelImage1.ImageUrl.Contains("Cherry.png")) count++;
            if (reelImage2.ImageUrl.Contains("Cherry.png")) count++;
            if (reelImage3.ImageUrl.Contains("Cherry.png")) count++;
            return count;
        }
    }
}