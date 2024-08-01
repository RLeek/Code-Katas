using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingGame
{
    internal class Strike : IModifier
    {

        private List<int> scores = new List<int>();

        public void AddScore(int score)
        {
            if (scores.Count >= 2)
            {
                // Throw exception
                // Or do we just make it so that it returns a value each time
                // Then at the end it just returns a score???
                // I think that would be more functional, but not really sure


                // FYI, I thought this was supposed to be easy??
            }
            scores.Add(score);
        }

        public bool IsComplete()
        {
            return scores.Count == 2;
        }

        public int Score()
        {
            return scores.Sum();
        }
    }
}
