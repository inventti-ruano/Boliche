using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
    class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            this.rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            // return this.rolls.Select((t, i) => rolls[i]).Sum();
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (this.IsStrike(frameIndex))
                {
                    score += 10 + this.StrikeBonus(frameIndex);
                    frameIndex++;
                } else if (this.IsPare(frameIndex))
                {
                    score += 10 + this.SpareBonus(frameIndex);
                    frameIndex += 2;
                } else
                {
                    score += this.SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;   
                }
            }
            return score;   
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return this.rolls[frameIndex] + this.rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return this.rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return this.rolls[frameIndex + 1] + this.rolls[frameIndex + 2];
        }

        private bool IsPare(int frameIndex)
        {
            return this.rolls[frameIndex] + this.rolls[frameIndex + 1] == 10;
        }
    }
}
