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

        private void MutateYAndRaiseEvent(int value)
        {
            _board.MutateY(value);
            BoardMoved?.Invoke(this, new BoardMovedEventArgs(_board.CurrentPosition, _board.SizeY));
        }

        private void MutateYAndRaiseEventIfPossible(int value)
        {
            if (CanBoardMove(_board, _map, value)) 
                MutateYAndRaiseEvent(value);
        }

        public void Up() => 
            MutateYAndRaiseEventIfPossible(-1);
        
        public void Down() => 
            MutateYAndRaiseEventIfPossible(1);
        
        public event EventHandler<BoardMovedEventArgs> BoardMoved;
    }
}
