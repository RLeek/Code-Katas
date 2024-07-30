using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace bowlingGame
{
    public class Frame : IFrame
    {
        private int score = 0; // (probably be better to define as remaining pins - esh)
        private int totalRolls = 0; 

        private IModifier modifer = new EmptyModifier();

        public void BonusScore(int pinsKnockedDown)
        {
            // validate pinsKNockedDown
            if (pinsKnockedDown > 10 || pinsKnockedDown < 0)
            {
                // throw exception
            }
            // validate if valid modifier
            if (modifer.IsComplete())
            {
                // throw exception
            }

            modifer.AddScore(pinsKnockedDown);
        }

        public bool IsComplete()
        {
            return (modifer.IsComplete() && this.IsRollsComplete());
        }

        public bool IsRollsComplete()
        {
            return (score == 10 || totalRolls == 2);
        }

        public int RemainingPins()
        {
            return 10 - score;
        }

        public void Roll(int pinsKnockedDown)
        {
            if (this.IsRollsComplete())
            {
                // throw exception;
            }

            if (pinsKnockedDown < 0 || pinsKnockedDown >= 10-score)
            {
                // throw exception
            }

            score += pinsKnockedDown;
            totalRolls += 1;

            if (score == 10 && totalRolls == 1)
            {
                modifer = new Strike();
            } else if (score == 10 && totalRolls == 2) 
            {
                modifer = new Spare();
            }
        }

        public int Score()
        {
            return score + modifer.Score();
        }

    }
}
