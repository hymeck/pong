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
        
        // this signature is required for System.Threading.Timer
        public void OnMoveOccured(object state = null)
        {
            var (currentX, currentY) = _ballMover.CurrentPosition;
            var currentMovement = _ballMover.CurrentMovementDirection;

            var nextX = currentX + currentMovement.Dx;
            var nextY = currentY + currentMovement.Dy;

            if (IsBallOnMap(_map, nextX, nextY))
            {
                _ballMover.Move();
                return;
            }

            var mapAxis = GetAxis(nextX, nextY);
            _ballMover
                .ReflectBall(mapAxis)
                .Move();
        }

        private Axis GetAxis(int ballX, int ballY)
        {
            // angles
            if ((ballX == _map.Width + 1 || ballX == 0) && (ballY == _map.Height + 1 || ballY == 0))
                return Axis.XY;
            
            // vertical
            if (ballY <= 0 || ballY >= _map.Height + 1)
                return Axis.Y;

            // horizontal
            return Axis.X;
        }
    }
}
