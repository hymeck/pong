using System;
using System.Threading;

namespace Pong.Engine
{
    public class BallMovementTrigger
    {
        private readonly Timer _timer;
        
        public BallMovementTrigger(double speed, TimerCallback callback)
        {
            _timer = new Timer(callback, null, 0, FindTriggerTime(speed));
        }

        private int FindTriggerTime(double speed)
        {
            // 1 -> 1000
            // 2 -> 500
            // 3 -> 333
            // 4 -> 250
            // 5 -> 200
            return Convert.ToInt32(1000 / speed);
        }

        public void Dispose() => _timer?.Dispose();
    }
}
