using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class TenthFrame : Frame
    {
        private int? Roll3 { get; set; }
        public override bool IsFrameComplete()
        {
            return ((Roll1 + Roll2 == 10 && Roll1 != null && Roll2 != null && Roll3 != null) ||
                    (Roll1 + Roll2 < 10 && Roll1 != null && Roll2 != null));
        }
        public override void AddRoll(int pins)
        {
            if (IsFrameComplete()) return;

            if (Roll1 == null)
                Roll1 = pins;
            else if(Roll2 == null)
                Roll2 = pins;
            else
                Roll3 = pins;
        }
        public override int Score()
        {
            return (Roll1 ?? 0) + (Roll2 ?? 0) + (Roll3 ?? 0);
        }
    }
}
