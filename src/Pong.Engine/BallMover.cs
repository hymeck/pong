using System;

namespace Pong.Engine
{
    public class BallMover
    {
        private readonly Ball _ball;

        public BallMover(Ball ball)
        {
            _ball = ball;
        }

        private void ChangeBallPositionAndRaiseEvent(int dx, int dy)
        {
            _ball.MutateXAndY(dx, dy);
            BallMoved?.Invoke(this, new BallMovedEventArgs(_ball.CurrentPosition));
        }
        
        public void MoveUpRight()
        {
            ChangeBallPositionAndRaiseEvent(1, -1);
        }

        public void MoveDownRight()
        {
            ChangeBallPositionAndRaiseEvent(1, 1);
        }
        
        public void MoveDownLeft()
        {
            ChangeBallPositionAndRaiseEvent(-1, 1);
        }
        
        public void MoveUpLeft()
        {
            ChangeBallPositionAndRaiseEvent(-1, -1);
        }
        
        public event EventHandler<BallMovedEventArgs> BallMoved;
    }
}
