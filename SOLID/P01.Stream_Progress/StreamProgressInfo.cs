using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IResult result;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IResult result)
        {
            this.result = result;
        }

        public int CalculateCurrentPercent()
        {
            return (this.result.BytesSent * 100) / this.result.Length;
        }
    }
}
