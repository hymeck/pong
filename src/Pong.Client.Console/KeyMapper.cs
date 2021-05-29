using System;
using System.Collections.Generic;

namespace Pong.Client.Console
{
    public class KeyMapper
    {
        private readonly Dictionary<ConsoleKey, Action> _actions;

        public KeyMapper(Dictionary<ConsoleKey, Action> actions)
        {
            _actions = actions;
        }

        public bool HasKey(ConsoleKey consoleKey) => _actions.ContainsKey(consoleKey);

        // todo: crap, idk how to remove nullable
        public Action this[ConsoleKey key] => _actions[key];

    }
}
