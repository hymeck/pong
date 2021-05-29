using System;
using Pong.Engine;

namespace Pong.Client.Console
{
    public class KeyHandler
    {
        private readonly BoardMover _boardMover;
        private char _up;
        private char _down;

        public KeyHandler(BoardMover boardMover, char up = 'w', char down = 's')
        {
            _boardMover = boardMover;
            _up = up;
            _down = down;
        }

        public void Handle()
        {
            var key = System.Console.ReadKey(true);
            HandleKey(key);
        }

        private void HandleKey(ConsoleKeyInfo keyInfo)
        {
            var keyChar = keyInfo.KeyChar;
            if (keyChar == _up)
                _boardMover.Up();
            else if (keyChar == _down)
                _boardMover.Down();
        }
    }
}
