using Pong.Engine.Exceptions;

namespace Pong.Engine
{
    public class Board
    {
        private readonly int _sizeY;
        private readonly int _x;
        private int _y;

        public Board(int sizeY, int x, int y)
        {
            // if (sizeY <= 0 || sizeY % 2 != 0) // less than zero or even
            //     throw new BoardSizeException(sizeY);
            
            _sizeY = sizeY;
            _x = x;
            _y = y;
        }
        
        #if DEBUG
        public Board(int x, int y) : this(5, x, y)
        {
        }
        #endif

        public Board MutateY(int stepY)
        {
            _y += stepY;
            return this;
        }
        
        public (int x, int y) CurrentPosition => (_x, _y);
        
        public int X => _x;
        public int Y => _y;

        public int SizeY => _sizeY;
    }
}
