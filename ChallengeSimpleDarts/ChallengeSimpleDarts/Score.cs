using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public static class Score
    {
        public static int ScoreDartThrow(Dart dart)
        {
            if (dart.Score == 0)
                return 25 * dart.RingMultiplier;
            else
                return dart.Score * dart.RingMultiplier;
        }
    }
}