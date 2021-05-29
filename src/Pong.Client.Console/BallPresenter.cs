using Pong.Engine;

namespace Pong.Client.Console
{
    public class BallPresenter
    {
        private readonly Ball _ball;
        private int _ballX;
        private int _ballY;

        public BallPresenter(Ball ball)
        {
            _ball = ball;
            (_ballX, _ballY) = _ball.CurrentPosition;
        }

        public BallPresenter Print()
        {
            var (x, y) = _ball.CurrentPosition;
            
            PrintBallAt(x, y);

            if (HasPositionChanged(x, y))
            {
                SetCursorAt(_ballX, _ballY);
                ClearChar();

                _ballX = x;
                _ballY = y;
            }

            return this;
        }

        private bool HasPositionChanged(int x, int y) => _ballX != x || _ballY != y;

        private void PrintBallAt(int x, int y)
        {
            SetCursorAt(x, y);
            System.Console.Write("\u25A1");
        }

        private static void SetCursorAt(int x, int y) => System.Console.SetCursorPosition(x, y);

        private static void ClearChar() => System.Console.Write("\b");
    }
}
