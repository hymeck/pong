using System;
using System.Drawing;

namespace Pong.Engine
{
    public class BoardMovedEventArgs : EventArgs
    {
        public (int x, int y) CurrentPosition { get; }
        public int SizeY { get; }
        

        public BoardMovedEventArgs((int x, int y) currentPosition, int sizeY)
        {
            CurrentPosition = currentPosition;
            SizeY = sizeY;
        }
    }
}
