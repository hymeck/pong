using static Pong.Engine.PhysicsChecker;

namespace Pong.Engine
{
    public class BallMovementController
    {
        private readonly BallMover _ballMover;
        private readonly Map _map;

        public BallMovementController(BallMover ballMover, Map map)
        {
            _ballMover = ballMover;
            _map = map;
        }
        private void ReflectByMapIfPossible(int x, int y)
        {
            if (CanMapReflect(_map, x, y)) 
                _ballMover.ReflectBall(GetReflectionAxis(x, y));
        }

        private void ReflectByBoardIfPossible(int x, int y)
        {
            var currentDirection = _ballMover.CurrentMovementDirection;
            if (CanBoardReflect(_map.LeftBoard, x, y) && !currentDirection.IsRight) 
                _ballMover.ReflectBall(Axis.X);
        }

        private Axis GetReflectionAxis(int ballX, int ballY)
        {
            // angles
            if ((ballX == _map.Width || ballX == 1) && (ballY == _map.Height || ballY == 1))
                return Axis.XY;
            
            // vertical
            if (ballY <= 1 || ballY >= _map.Height)
                return Axis.Y;

            // horizontal
            return Axis.X;
        }
        
        // this signature is required for System.Threading.Timer
        public void OnMoveOccured(object state = null)
        {
            var (x, y) = _ballMover.CurrentPosition;
            System.Diagnostics.Debug.WriteLine($"({x.ToString()}, {y.ToString()})");
            ReflectByBoardIfPossible(x, y);
            ReflectByMapIfPossible(x, y);
            
            _ballMover.Move();
        }
    }
}
