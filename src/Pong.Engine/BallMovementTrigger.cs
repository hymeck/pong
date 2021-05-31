using System;
using System.Threading;

namespace Pong.Engine
{
    public class BallMovementTrigger
    {
        private readonly Timer _timer;
        
        public BallMovementTrigger(double speed, TimerCallback callback, int startDelay = 0)
        {
            _timer = new Timer(callback, null, startDelay, FindTriggerTime(speed));
        }

        private int FindTriggerTime(double speed) => Convert.ToInt32(1000 / speed);
        public void Dispose() => _timer?.Dispose();
    }
}
