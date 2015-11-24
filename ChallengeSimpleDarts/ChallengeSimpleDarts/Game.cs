using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Game
    {
        private Random random = new Random();
        private Dart dart;

        public int Player1Score { get; set; }
        public int Player2Score { get; set; }

        public Game ()
        {
            dart = new Dart(random);
            Player1Score = 0;
            Player2Score = 0;
        }

        public void Play()
        {
            while (Player1Score < 300 && Player2Score < 300)
            {
                Player1Score += takeTurn();
                Player2Score += takeTurn();
            }
        }

        private int takeTurn()
        {
            int turnScore = 0;
            for (int i = 0; i < 3; i++)
            {
                dart.Throw();
                turnScore += Score.ScoreDartThrow(dart);
            }
            return turnScore;
        }
    }
}