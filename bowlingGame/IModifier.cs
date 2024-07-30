using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingGame
{
    public interface IModifier
    {
        public bool IsComplete();

        public int Score();

        public void AddScore(int score);

    }
}
