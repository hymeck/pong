using System;

namespace Pong.Engine
{
    public class BallMover
    {
        private readonly Ball _ball;
        private MovementDirection _currentMovementDirection;

        public BallMover(Ball ball, MovementDirection currentMovementDirection)
        {
            _ball = ball;
            _currentMovementDirection = currentMovementDirection;
        }

        private void MutateBallPositionAndRaiseEvent()
        {
            var (dx, dy) = _currentMovementDirection;
            _ball.MutateXAndY(dx, dy);
            BallMoved?.Invoke(this, new BallMovedEventArgs(_ball.CurrentPosition, _currentMovementDirection));
        }
        
        private void ChangeBallPositionAndRaiseEvent(MovementDirection movementDirection)
        {
            _currentMovementDirection = movementDirection;
            MutateBallPositionAndRaiseEvent();
        }
        
        public BallMover ChangeDirection(MovementDirection movementDirection)
        {
            _currentMovementDirection = movementDirection;
            return this;
        }

        public BallMover ReflectBall(Axis reverseAxis)
        {
            var newDirection = _currentMovementDirection.GetReversedDirection(reverseAxis);
            return ChangeDirection(newDirection);
        }
        
        public void MoveUpRight() => ChangeBallPositionAndRaiseEvent(MovementDirection.UpRight);
        public void MoveDownRight() => ChangeBallPositionAndRaiseEvent(MovementDirection.DownRight);
        public void MoveDownLeft() => ChangeBallPositionAndRaiseEvent(MovementDirection.DownLeft);
        public void MoveUpLeft() => ChangeBallPositionAndRaiseEvent(MovementDirection.UpLeft);
        public void Move() => MutateBallPositionAndRaiseEvent();
        public (int x, int y) CurrentPosition => _ball.CurrentPosition;
        public int CurrentX => _ball.X;
        public int CurrentY => _ball.Y;
        public MovementDirection CurrentMovementDirection => _currentMovementDirection;

        public event EventHandler<BallMovedEventArgs> BallMoved;
    }
}
