using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeHeroMonsterClassesPart1
{
    public class Dice
    {
        public int Sides { get; set; }
        private Random random = new Random();

        public int Roll()
        {
            return random.Next(1, Sides);
        }
    }
}