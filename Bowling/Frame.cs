namespace Bowling
{
    public class Frame : IFrame
    {
        private bool IsStrike => Roll1 == 10;
        private bool IsSpare => (Roll1 + Roll2 == 10 && Roll1 < 10);
        protected int? Roll1 { get; set; }
        protected int? Roll2 { get; set; }

        public IFrame Next;
        public virtual bool IsFrameComplete()
        {
            return (IsStrike && Roll1 != null) || (Roll1 != null && Roll2 != null);
        }
        public virtual void AddRoll(int pins)
        {
            if (IsFrameComplete()) return;

            if (Roll1 == null)
                Roll1 = pins;
            else 
                Roll2 = pins;
        }
        public virtual int Score()
        {
            var score=0;

            if (!IsStrike && !IsSpare)
                score += (Roll1 ?? 0) + (Roll2 ?? 0);
            else if (IsSpare)
                score += (Roll1 ?? 0) + (Roll2 ?? 0) + SpareBonus();
            else if (IsStrike)
                score += (Roll1 ?? 0) +  StrikeBonus();
            return score;
        }

        private int StrikeBonus()
        {
            var bonus = 0;
            if (Next == null) return bonus;
            var nextFrame = (Frame) Next;

            bonus += nextFrame.Roll1 ?? 0;

            if (!nextFrame.IsStrike || Next is TenthFrame)
            {
                bonus += nextFrame.Roll2 ?? 0;
            } else
            {
                if (nextFrame.Next != null)
                {
                    bonus += ((Frame) nextFrame.Next).Roll1 ?? 0;
                }
            }
            return bonus;
        }
        private int SpareBonus()
        {
            var nextFrame = ((Frame)Next);
            return nextFrame != null ? (nextFrame.Roll1 ?? 0) : 0;
        }
    }
}
