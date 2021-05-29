using Pong.Engine;
using static Pong.Client.Console.ConsoleUtils;

namespace Pong.Client.Console
{
    public class BoardPresenter
    {
        private readonly Board _board;
        private readonly int _boardX;
        private int _boardY;
        private readonly int _sizeY;

        public BoardPresenter(Board board)
        {
            _board = board;
            (_boardX, _boardY) = _board.CurrentPosition;
            _sizeY = _board.SizeY;
        }

        public BoardPresenter Print()
        {
            var y = _board.Y;
            if (HasPositionChanged(y))
            {
                ClearBoard();
                _boardY = y;
            }
            
            PrintBoardAt(_boardY);

            return this;
        }

        private void ClearBoard()
        {
            var half = _sizeY >> 1; // div by 2
            var topY = _boardY - half;
            for (var i = 0; i < _sizeY; i++)
            {
                SetCursorAt(_boardX, topY++);
                ClearCharAtCurrentCursorPosition();
            }
        }

        private void PrintBoardAt(int y)
        {
            var half = _sizeY >> 1; // div by 2
            var topY = y - half;
            for (var i = 0; i < _sizeY; i++)
            {
                SetCursorAt(_boardX, topY++);
                // System.Console.Write('#');
                // System.Console.Write("\u25AE");
                System.Console.Write("\u258C");
            }
        }

        private bool HasPositionChanged(int y) => _boardY != y;

        public void OnBoardMoved(object sender, BoardMovedEventArgs e)
        {
            Print();
        }
    }
}
