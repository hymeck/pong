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

        private void ChangeBallPositionAndRaiseEvent(MovementDirection movementDirection)
        {
            var (dx, dy) = movementDirection;
            _ball.MutateXAndY(dx, dy);
            
            _currentMovementDirection = movementDirection;
            
            BallMoved?.Invoke(this, new BallMovedEventArgs(_ball.CurrentPosition, _currentMovementDirection));
        }
        
        // public void MoveUpRight()
        // {
        //     ChangeBallPositionAndRaiseEvent(MovementDirection.UpRight);
        // }
        //
        // public void MoveDownRight()
        // {
        //     ChangeBallPositionAndRaiseEvent(MovementDirection.DownRight);
        // }
        //
        // public void MoveDownLeft()
        // {
        //     ChangeBallPositionAndRaiseEvent(MovementDirection.DownLeft);
        // }
        //
        // public void MoveUpLeft()
        // {
        //     ChangeBallPositionAndRaiseEvent(MovementDirection.UpLeft);
        // }

        public void Move(MovementDirection movementDirection)
        {
            ChangeBallPositionAndRaiseEvent(movementDirection);
        }
        
        public void Move()
        {
            Move(_currentMovementDirection);
        }
        
        public (int x, int y) CurrentPosition => _ball.CurrentPosition;
        public MovementDirection CurrentMovementDirection => _currentMovementDirection;

        public BallMover ChangeDirection(MovementDirection movementDirection)
        {
            _currentMovementDirection = movementDirection;
            return this;
        }

        public BallMover ReflectBall(Axis mapAxis)
        {
            if (mapAxis == Axis.Y)
                _currentMovementDirection = _currentMovementDirection.ReverseY();
            else if (mapAxis == Axis.X)
                _currentMovementDirection = _currentMovementDirection.ReverseX();
            else if (mapAxis == Axis.XY)
                _currentMovementDirection = _currentMovementDirection.ReverseXY();

            return this;
        }
        
        public event EventHandler<BallMovedEventArgs> BallMoved;
    }
}
