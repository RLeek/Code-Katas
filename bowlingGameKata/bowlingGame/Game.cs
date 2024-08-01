using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace bowlingGame
{
    // Represents game object
    // Determines maximum number of frames and type of frames for rules
    public class Game
    {
        // Frame frames[10] = new array[frames](10)

        // Maintain scores
        // With each frame = score + modifier: {None | Strike {value} | Spare {value1, value2}}
        // Frame isComplete();
        // Frame isRollCompletes();
        // If rolls finished then restart
        // Frame score();
        // If not complete, then add value? (Then pop at end of list??)
        // Yeah that's fine
        // Frame roll(); <- that is fine and validates

        // How to deal with 10th frame?
        // Add special type of 10th frame?
        // frane = score + score + modifier {None | strike | spare } | tenthScore (subclass) : score/score/score
      
        // Assume 10 games are fixed

        // Current active frame number
        private int currFrameNumber = 1;
        private IFrame currentFrame = new Frame(); 
        
        // Frames that are yet to be complete
        private List<IFrame> activeFrames = new List<IFrame>();
        private List<IFrame> completeFrames = new List<IFrame>();

        // Current roll
        void Roll(int pinsKnockedDown)
        {
            // Check if there are any valid rolls remaining
            if (currFrameNumber == 10 && currentFrame.IsComplete())
            {
                // Nothing to do
                // Throw exception ???
            }

            // Common logic
            // Validate pinsKnockedDown is valid
            if (!IsValidPinsKnockedDown(pinsKnockedDown))
            {
                // Throw exception??
                // Is there an alternative way of handling errors properly??
            }

            // Assuming if valid:
            foreach (Frame frame in activeFrames)
            {
                if (frame.IsRollsComplete())
                {
                    frame.BonusScore(pinsKnockedDown);
                } else
                {
                    frame.Roll(pinsKnockedDown);
                }
            }
            activeFrames = activeFrames.Where(frame => !frame.IsComplete()).ToList();
            completeFrames.AddRange(activeFrames.Where(frame => frame.IsComplete()).ToList());

            // Check if currentFrame has finished
            if (currentFrame.IsRollsComplete())
            {
                if (currFrameNumber == 9)
                {
                    currFrameNumber += 1;
                    currentFrame = new FinalFrame();
                    activeFrames.Append(currentFrame);
                }
                else if (currFrameNumber < 9)
                {
                    currFrameNumber += 1;
                    currentFrame = new Frame();
                    activeFrames.Append(currentFrame);
                }
            }
        }

        private bool IsValidPinsKnockedDown(int pinsKnockedDown)
        {
            return !(pinsKnockedDown < 0 || pinsKnockedDown > currentFrame.RemainingPins());
        }

        // Total score
        int Score()
        {
            return activeFrames.Sum(frame => frame.Score()) + completeFrames.Sum(frame => frame.Score());
        }

    }
}
