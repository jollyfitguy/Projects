using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeSimpleDarts
{
    public class Statistics
    {
        private int[] _winHistory;
        public int Length { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        private int _lastIndex;


        public Statistics(int games)
        {
            _winHistory = new int[games];
            Length = _winHistory.Length;
            initializeArray();
            Wins = 0;
            Losses = 0;
            _lastIndex = 0;
        }
        private void initializeArray()
        {
            for (int i = 0; i < Length; i++)
            {
                _winHistory[i] = -1;
            }
        }

        public bool AddGameResult(int result)
        {   
            if (_lastIndex == Length)
                return false;
            else
            {
                _winHistory[_lastIndex] = result;
                determineResult(result);
                return true;
            }
        }

        private void determineResult(int result)
        {
            if (result == 1)
                Wins++;
            else if (result == 0)
                Losses++;
        }
        
        public double GetWinPercentage()
        {
            return 100 * (double)Wins / (double)Length;
        }


    }
}