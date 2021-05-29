using System.Linq;
using Pong.Engine;
using static Pong.Client.Console.ConsoleUtils;

namespace Pong.Client.Console
{
    public class MapPresenter
    {
        private readonly Map _map;

        public MapPresenter(Map map)
        {
            _map = map;
        }

        public MapPresenter Print()
        {
            var borderWidth = _map.Width + 2;
            const string borderBlock = "\u2500";
            const string upperLeftCorner = "\u250c";
            const string upperRightCorner = "\u2510";
            const string lowerLeftCorner = "\u2514";
            const string lowerRightCorner = "\u2518";
            const string verticalBorder = "\u2502";

            // var widthBorderBlock = new string(borderBlock, borderWidth);
            // var widthBorderBlock = string.Concat(Enumerable.Repeat(borderBlock, borderWidth));
            var widthBorderBlock = string.Concat(Enumerable.Repeat(borderBlock, _map.Width));
            
            SetCursorAt(0, 0); // upper left corner
            System.Console.Write(upperLeftCorner);
            System.Console.Write(widthBorderBlock);
            System.Console.Write(upperRightCorner);
            
            SetCursorAt(0, _map.Height + 1); //lower left corner
            System.Console.Write(lowerLeftCorner);
            System.Console.Write(widthBorderBlock);
            System.Console.Write(lowerRightCorner);

            for (var i = 1; i <= _map.Height; i++)
            {
                SetCursorAt(0, i);
                System.Console.Write(verticalBorder);
                
                SetCursorAt(borderWidth - 1, i);
                System.Console.Write(verticalBorder);
                
            }
            
            return this;
        }
    }
}
