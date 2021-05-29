using System;
using static Pong.Engine.PhysicsChecker;

namespace Pong.Engine
{
    public class BoardMover
    {
        private readonly Board _board;
        private readonly Map _map;

        public BoardMover(Board board, Map map)
        {
            _board = board;
            _map = map;
        }

        public void Up() => MutateYAndRaiseEvent(-1);

        public void Down() => MutateYAndRaiseEvent(1);

        private void MutateYAndRaiseEvent(int value)
        {
            if (!CanBoardMove(_board, _map, value))
                return;
            
            _board.MutateY(value);
            BoardMoved?.Invoke(this, new BoardMovedEventArgs(_board.CurrentPosition, _board.SizeY));
        }

        public event EventHandler<BoardMovedEventArgs> BoardMoved;
    }
}
