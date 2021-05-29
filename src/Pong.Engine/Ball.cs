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

        public Ball MutateX(int x)
        {
            _x += x;
            return this;
        }
        
        public Ball MutateY(int y)
        {
            _y += y;
            return this;
        }

        public (int x, int y) CurrentPosition => (_x, _y);

        public int X => _x;
        public int Y => _y;
    }
}
