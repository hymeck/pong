using System;

namespace Pong.Engine
{
    public class BoardMover
    {
        private readonly Board _board;

        public BoardMover(Board board)
        {
            _board = board;
        }

        public void Up()
        {
            _board.MutateY(-1);
            BoardMoved?.Invoke(this, 
                new BoardMovedEventArgs(_board.CurrentPosition, _board.SizeY));
        }
        
        public void Down()
        {
            _board.MutateY(1);
            BoardMoved?.Invoke(this, 
                new BoardMovedEventArgs(_board.CurrentPosition, _board.SizeY));
        }

        public event EventHandler<BoardMovedEventArgs> BoardMoved;
    }
}
