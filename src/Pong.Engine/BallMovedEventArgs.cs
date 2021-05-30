using System;

namespace Pong.Engine
{
    public class BallMovedEventArgs : EventArgs
    {
        public (int x, int y) CurrentPosition { get; }

        public BallMovedEventArgs((int x, int y) currentPosition)
        {
            CurrentPosition = currentPosition;
        }
    }
}
