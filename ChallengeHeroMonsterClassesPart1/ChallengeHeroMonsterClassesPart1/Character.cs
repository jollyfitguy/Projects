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
        public int AttackBonus { get; set; }
        private Random random = new Random();

        public int Attack()
        {
            return random.Next(1, DamageMaximum) + AttackBonus;
        }
        public int Defend(int damage)
        {
            Health -= damage;
            return Health;
        }


    }
}