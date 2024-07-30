using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingGame
{
    internal class EmptyModifier : IModifier
    {
        public void AddScore(int score)
        {
            // Should we throw an exception 
            // if we attempt to do this?
            // does it matter?
            return;
        }

        public bool IsComplete()
        {
            return true;
        }

        public int Score()
        {
            return 0;
        }
    }
}
