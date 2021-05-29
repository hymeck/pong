using System;
using Pong.Engine;
using static Pong.Engine.PhysicsChecker;

namespace Pong.Client.Console
{
    public class KeyHandler
    {
        private readonly KeyMapper _keyMapper;

        public KeyHandler(KeyMapper keyMapper)
        {
            _keyMapper = keyMapper;
        }

        public void Handle()
        {
            var keyInfo = System.Console.ReadKey(true);
            HandleKey(keyInfo);
        }

        private void HandleKey(ConsoleKeyInfo keyInfo)
        {
            var consoleKey = keyInfo.Key;
            if (!_keyMapper.HasKey(consoleKey))
                return;
            
            _keyMapper[consoleKey].Invoke();
        }
    }
}
