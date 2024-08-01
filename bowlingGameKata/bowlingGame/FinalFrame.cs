using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bowlingGame
{
    internal class FinalFrame : IFrame
    {
        private int score = 0; // should probably just be remainig pins
        private int remainingPins = 10;
        private int totalRolls = 0; // maybe this should be remaining roles instead
            // Not really sure -> Though the logic would be more consistent ehh

        private IModifier modifier = new EmptyModifier();

        public void BonusScore(int pinsKnockedDown)
        {
            // there is no concept of bonus score

            // throw exception here
            // that is really stupid though, sounds like we should have multiple interfaces
                // or use the same logic
            throw new NotImplementedException();
        }

        public bool IsComplete()
        {
            if (modifier is Strike || modifier is Spare)
            {
                return (totalRolls == 3);
            }
            return (totalRolls == 2);
        }

        public bool IsRollsComplete()
        {
            return IsComplete();
        }

        public int RemainingPins()
        {
            return remainingPins;
        }

        // This sucks and is very difficult to read
        // There has to be a better abstraction
        public void Roll(int pinsKnockedDown)
        {
            if (this.IsRollsComplete())
            {
                // throw exception;
            }

            if (pinsKnockedDown < 0 || pinsKnockedDown >= remainingPins)
            {
                // throw exception
            }

            score += pinsKnockedDown;
            remainingPins -= pinsKnockedDown;
            totalRolls += 1;

            if (totalRolls == 3)
            {
                // Nothing more to do
                return;
            }

            if (score == 10 && totalRolls == 1)
            {
                modifier = new Strike();
                remainingPins = 10;
            }
            else if (score == 10 && totalRolls == 2)
            {
                modifier = new Spare();
                remainingPins = 10;
            }
        }

        public int Score()
        {
            return score;
        }
    }
}
