using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private int FrameNumber { get; set;}
        private IFrame _firstFrame;
        private IFrame _currentFrame;
        public Game()
        {
            FrameNumber = 0;
        }

        public void Roll(int pins)
        {
            if (FrameNumber == 10 && _currentFrame.IsFrameComplete())
                throw new Exception(
                    $"You have already played 10 frames. Your game is over. You Scored {Score()}. To play again, start a new game.");

            if (_currentFrame == null)
            {
                var newFrame = new Frame();
                FrameNumber++;
                newFrame.AddRoll(pins);
                newFrame.Next = null;
                _currentFrame = newFrame;
                _firstFrame = newFrame;
            }
            else
            {
                if (_currentFrame.IsFrameComplete())
                {
                    var newFrame = FrameNumber == 9 ? new TenthFrame() : new Frame();
                    FrameNumber++;
                    newFrame.AddRoll(pins);
                    newFrame.Next = null;
                    ((Frame) _currentFrame).Next = newFrame;
                    _currentFrame = newFrame;
                }
                else
                {
                    _currentFrame.AddRoll(pins);
                }
            }
        }

        public int Score()
        {
            var temp = _firstFrame;
            var gameScore = 0;

            while(temp!=null)
            {
                gameScore += temp.Score();
                temp = ((Frame)temp).Next;
            }

            return gameScore;
        }
    }
}
