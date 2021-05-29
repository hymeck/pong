using System;

namespace Pong.Engine.Exceptions
{
    public class BoardSizeException : Exception
    {
        public BoardSizeException(int sizeY) : base($"{sizeY} is not valid")
        {
        }
    }
}
