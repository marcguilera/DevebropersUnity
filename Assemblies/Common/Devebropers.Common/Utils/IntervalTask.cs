using System;
using System.Timers;

namespace Devebropers.Common.Utils
{
    /// <summary>
    /// Performs an action every set interval
    /// </summary>
    public class IntervalTask : IDisposable
    {
        private Timer _timer;
        private readonly Action _action;
    
        public IntervalTask(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// Starts performing its action every <paramref name="interval"/>
        /// </summary>
        /// <param name="interval">The interval</param>
        public void Start(TimeSpan interval)
        {
            Dispose();
            
            _timer = new Timer { AutoReset = false, Interval = interval.Milliseconds };
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }
    
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _action();
        }
    
        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Dispose()
        {
            if (_timer == null)
            {
                return;
            }
            
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }
    }
}