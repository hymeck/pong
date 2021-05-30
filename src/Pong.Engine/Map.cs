namespace Pong.Engine
{
    public class Map
    {
        public readonly int Width;
        public readonly int Height;
        public Board LeftBoard { get; set; }
        public Board RightBoard { get; set; }

        public Map(int width, int height, Board leftBoard = null, Board rightBoard = null)
        {
            Width = width;
            Height = height;
            LeftBoard = leftBoard;
            RightBoard = rightBoard;
        }
    }
}
