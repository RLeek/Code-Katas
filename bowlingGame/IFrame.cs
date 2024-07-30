using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingGame
{
    public interface IFrame
    {
        public bool IsComplete();

        public bool IsRollsComplete();

        public int Score();

        public void Roll(int pinsKnockedDown);

        public void BonusScore(int pinsKnockedDown);

        public int RemainingPins();

    }
}
