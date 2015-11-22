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

            hero.Name = "Hercules";
            hero.Health = 100;
            hero.DamageMaximum = 10;
            hero.AttackBonus = 2;

            Character monster = new Character();

            monster.Name = "Hydra";
            monster.Health = 75;
            monster.DamageMaximum = 10;
            monster.AttackBonus = 3;
            
            heroAttackLabel.Text = performAttack(hero, monster);            
            monsterAttackLabel.Text = performAttack(monster, hero);

            displayStats(hero, monster);
        }

        private void displayStats(Character hero, Character monster)
        {
            resultLabel.Text = String.Format("{0}: {1} HP &nbsp;&nbsp;&nbsp; {2}: {3} HP", hero.Name, hero.Health, monster.Name, monster.Health);
        }
        private string performAttack(Character attacker, Character defender)
        {
            int attack = attacker.Attack();
            defender.Defend(attack);
            return String.Format("{0} attacks {1} and deals {2} damage!", attacker.Name, defender.Name, attack);
            
        }
    }
}