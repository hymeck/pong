namespace Pong.Engine
{
    public class Ball
    {
        private int _x;
        private int _y;

        public Ball()
        {
        }

        public Ball(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Ball MutateX(int stepX)
        {
            _x += stepX;
            return this;
        }
        
        public Ball MutateY(int stepY)
        {
            _y += stepY;
            return this;
        }

        public (int x, int y) CurrentPosition => (_x, _y);

        public int X => _x;
        public int Y => _y;
    }
}
