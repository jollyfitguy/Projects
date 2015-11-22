using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeHeroMonsterClassesPart1
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }
        

        public int Attack(Dice die)
        {
            return die.Roll();
        }
        public int Defend(int damage)
        {
            Health -= damage;
            return Health;
        }


    }
}