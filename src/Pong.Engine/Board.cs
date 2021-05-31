namespace Pong.Engine
{
    public class Board
    {
        private readonly int _sizeY;
        private readonly int _x;
        private int _y;

        public Board(int sizeY, int x, int y)
        {
            _sizeY = sizeY;
            _x = x;
            _y = y;
        }

        public Board MutateY(int stepY)
        {
            _y += stepY;
            return this;
        }

        public bool HasTakenPlace(int x, int y) => x == _x && y >= TopY && y <= BottomY;
        public (int x, int y) CurrentPosition => (_x, _y);
        public int X => _x;
        public int Y => _y;
        public int SizeY => _sizeY;
        public int HalfSize => _sizeY >> 1;
        public int TopY => _y - HalfSize;
        public int BottomY => _y + HalfSize;
    }
}
