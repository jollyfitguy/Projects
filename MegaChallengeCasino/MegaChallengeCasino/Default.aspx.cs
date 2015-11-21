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
        int numberOfImages = 12;
        double money = 100;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState.Add("money", money);
                //Generate Reel images
                pullLever();

                //Set starting money value
                moneyLabel.Text = string.Format("Player's Money: {0:C}", money);
                //display starting values

                
            }
        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            money = (double)ViewState["money"];
            //take bet
            double bet = 0;
            if(tryTakeBet(out bet) && validateBet(bet))
            {
                //Generate Reel images
                pullLever();
                //subract bet from money
                updateMoney(-bet);
            }
            
            //Calculate win or lose
            //calculate winnings
            //add winnings to money
            //display result
            displayMoney();
        }

        private void pullLever()
        {
            reelImage1.ImageUrl = getReelImage(generateRandomReelInt());
            reelImage2.ImageUrl = getReelImage(generateRandomReelInt());
            reelImage3.ImageUrl = getReelImage(generateRandomReelInt());
        }

        private int generateRandomReelInt ()
        {
            return random.Next(1, numberOfImages);
        }

        private string getReelImage(int imageNumber)
        {
            return "..\\Images\\" + getImage(imageNumber);
        }
        private string getImage(int imageNumber)
        {
            if (imageNumber == 1) return "Bar.png";
            else if (imageNumber == 2) return "Bell.png";
            else if (imageNumber == 3) return "Cherry.png";
            else if (imageNumber == 4) return "Clover.png";
            else if (imageNumber == 5) return "Diamond.png";
            else if (imageNumber == 6) return "HorseShoe.png";
            else if (imageNumber == 7) return "Lemon.png";
            else if (imageNumber == 8) return "Orange.png";
            else if (imageNumber == 9) return "Plum.png";
            else if (imageNumber == 10) return "Seven.png";
            else if (imageNumber == 11) return "Strawberry.png";
            else if (imageNumber == 12) return "Watermelon.png";
            return "Not Found";
        }

        private void updateMoney(double amount)
        {
            money = (double)ViewState["money"];
            money += amount;
            ViewState["money"] = money;
        }

        private bool validateBet(double bet)
        {
            if (bet <= 0)
                return false;
            else
                return true;
        }
        private bool tryTakeBet(out double bet)
        {
            if(!double.TryParse(betTextBox.Text, out bet))
            {
                resultLabel.Text = "Please enter a valid number";
                return false;
            }
            return true;
        }
        private void displayMoney()
        {
            moneyLabel.Text = string.Format("Player's Money: {0:C}", (double)ViewState["money"]);
        }
        
    }
}