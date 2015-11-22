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
        int[] reelsInt;
        double money = 100;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                reelsInt = new int[3]; // initialize reels
                ViewState.Add("money", money);  
                ViewState.Add("reelsInt", reelsInt);
                pullLever();  //Generate Reel images
                moneyLabel.Text = string.Format("Player's Money: {0:C}", money);             //display starting values
            }
        }

        protected void goButton_Click(object sender, EventArgs e)
        {
            money = (double)ViewState["money"];
            reelsInt = (int[])ViewState["reelsInt"];
            double bet = placeBet();
            calculateWin(bet);
            displayMoney();
        }

        private double placeBet ()
        {
            double bet = 0;
            if (tryTakeBet(out bet) && validateBet(bet) && validateMoney(money, bet))
            {
                pullLever();     //Generate Reel images
                updateMoney(-bet);    //subract bet from money
                resultLabel.Text = "";
            }
            return bet;
        }
        private void calculateWin(double bet)
        {
            double multiplier = getMultiplier();
            if (multiplier == 0)
                resultLabel.Text = String.Format("Sorry, you lost {0:C}. Better luck next time.", bet);
            else
            {
                updateMoney(bet * multiplier);
                resultLabel.Text = string.Format("You bet {0:C} and won {1:C}!", bet, bet * multiplier);
            }
        }

        // generates the images for the three reels in the slot machine
        private void pullLever()
        {
            generateRandomReelInts(reelsInt);
            reelImage1.ImageUrl = getReelImage(reelsInt[0]);
            reelImage2.ImageUrl = getReelImage(reelsInt[1]);
            reelImage3.ImageUrl = getReelImage(reelsInt[2]);
        }

        //Test method
        private void test_pullLever(int reel1, int reel2, int reel3)
        {
            test_generateRandomReelInts(reelsInt, reel1, reel2, reel3);
            reelImage1.ImageUrl = getReelImage(reelsInt[0]);
            reelImage2.ImageUrl = getReelImage(reelsInt[1]);
            reelImage3.ImageUrl = getReelImage(reelsInt[2]);
        }

        // Test Method
        private int[] test_generateRandomReelInts(int[] reelsInt, int reel1, int reel2, int reel3)
        {
            reelsInt[0] = reel1;
            reelsInt[1] = reel2;
            reelsInt[2] = reel3;
            return reelsInt;
        }

        
        private int[] generateRandomReelInts(int[] reelsInt)
        {
            for (int i = 0; i < reelsInt.Length; i++)
            {
                reelsInt[i] = generateReelInt();
            }
            return reelsInt;
        }

        // generates random image index
        private int generateReelInt ()
        {
            return random.Next(1, numberOfImages);
        }

        // returns string to be used in imageURL
        private string getReelImage(int imageNumber)
        {
            return "..\\Images\\" + getImage(imageNumber);
        }

        // gets image name associated to number
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

        // updates the the players money and stores it back in ViewState
        private void updateMoney(double amount)
        {
            money = (double)ViewState["money"];
            money += amount;
            ViewState["money"] = money;
        }

        // validates money to make sure player can still play
        private bool validateMoney (double money, double bet)
        {
            if (money - bet < 0)
            {
                resultLabel.Text = "You don't have that much money!";
                return false;
            }
            else
                return true;
        }

        // Validates to make sure that the bet is a positive number
        private bool validateBet(double bet)
        {
            if (bet <= 0)
            {
                resultLabel.Text = "Please enter a positive value for your bet.";
                return false;
            }
            else
                return true;
        }

        // returns true if was able to parse textbox.text and get a bet. Sets output parameter to value in betTextbox.Text
        private bool tryTakeBet(out double bet)
        {
            if(!double.TryParse(betTextBox.Text, out bet))
            {
                resultLabel.Text = "Please enter a valid number.";
                return false;
            }
            return true;
        }

        // gets win multiplier from reel results
        private double getMultiplier ()
        {
            int cherries = countCherries();
            if (reelsInt[0] == 1 || reelsInt[1] == 1 || reelsInt[2] == 1) return 0.0;
            else if (reelsInt[0] == 10 && reelsInt[1] == 10 && reelsInt[2] == 10) return 100.0;
            else if (cherries == 0) return 0;
            else
                return cherries + 1;
        }

        // counts the number of cherries on the reels
        private int countCherries ()
        {
            int count = 0;
            for (int i = 0; i < reelsInt.Length; i++)
            {
                if (reelsInt[i] == 3) count++;
            }
            return count;
        }

        //updates Players money label
        private void displayMoney()
        {
            moneyLabel.Text = string.Format("Player's Money: {0:C}", (double)ViewState["money"]);
        }
    }
}