using System;

namespace Pong.Engine
{
    public class BallMovedEventArgs : EventArgs
    {
        public (int x, int y) CurrentPosition { get; }
        public MovementDirection MovementDirection { get; }

        public BallMovedEventArgs((int x, int y) currentPosition, MovementDirection movementDirection)
        {
            CurrentPosition = currentPosition;
            MovementDirection = movementDirection;
        }
    }
}
