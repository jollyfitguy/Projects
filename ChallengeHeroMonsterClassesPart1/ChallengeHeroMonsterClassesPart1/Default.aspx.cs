using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChallengeHeroMonsterClassesPart1;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            Character hero = new Character();
            Dice heroDice = new Dice();

            hero.Name = "Hercules";
            hero.Health = 100;
            hero.DamageMaximum = 10;
            hero.AttackBonus = false;
            heroDice.Sides = hero.DamageMaximum;

            Character monster = new Character();
            Dice monsterDice = new Dice();

            monster.Name = "Hydra";
            monster.Health = 75;
            monster.DamageMaximum = 15;
            monster.AttackBonus = true;
            monsterDice.Sides = monster.DamageMaximum;

            string battle = "";
            if (hero.AttackBonus && !monster.AttackBonus)
            {
                battle += "Bonus Hero Attack! " + performAttack(hero, heroDice, monster) + "<br/><hr>";
            }
            else if (monster.AttackBonus && !hero.AttackBonus)
            {
                battle += "Surprise attack! " + performAttack(monster, monsterDice, hero) + "<br/><hr>";
            }

            while (hero.Health > 0 && monster.Health > 0)
            {
                battle += performAttack(hero, heroDice, monster) + "<br/>";
                battle += performAttack(monster, monsterDice, hero) + "<br/>";
                battle += "<hr>";
            }

            resultLabel.Text += battle;

            displayStats(hero, monster);
            displayResults(hero,monster);
        }

        private void displayStats(Character hero, Character monster)
        {
            resultLabel.Text += String.Format("{0}: {1} HP&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{2}: {3} HP<br/>" +
                "Max Damage: {4}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Max Damage: {5}<br/>" +
                "Attack Bonus: {6}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Attack Bonus: {7}<br/><br/>",
                hero.Name, hero.Health,
                monster.Name, monster.Health,
                hero.DamageMaximum, monster.DamageMaximum,
                hero.AttackBonus.ToString(), monster.AttackBonus.ToString());            
        }

        private void displayResults(Character opponent1, Character opponent2)
        {
            string winner, loser;
            if (opponent1.Health <= 0)
            {
                winner = opponent2.Name;
                loser = opponent1.Name;
            }
            else
            {
                winner = opponent1.Name;
                loser = opponent2.Name;
            }
            resultLabel.Text += string.Format("{0} defeated {1}!<br/>", winner, loser);
        }

        private string performAttack(Character attacker, Dice attackerDice, Character defender)
        {
            int attack = attacker.Attack(attackerDice);
            defender.Defend(attack);
            return String.Format("{0} attacks {1} and deals {2} damage!", attacker.Name, defender.Name, attack);            
        }
    }
}