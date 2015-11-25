using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        private Random _random;
        private int _ring;
        public int Score { get; private set; }
        public int RingMultiplier { get; private set; }

        public Dart(Random random)
        {
            _random = random;
        }

        public void Throw()
        {
            Score = _random.Next(0, 21);
            _ring = _random.Next(1, 21);
            if (Score == 0)
                determineRingMultiplier();
            else
                determineBullsEyeMultiplier();
        }

        private void determineRingMultiplier()
        {
            if (_ring == 20)
                RingMultiplier = 2;
            else
                RingMultiplier = 1;
        }

        private void determineBullsEyeMultiplier()
        {
            if (_ring == 19)
                RingMultiplier = 2;
            else if (_ring == 20)
                RingMultiplier = 3;
            else
                RingMultiplier = 1;
        }
    }
}
