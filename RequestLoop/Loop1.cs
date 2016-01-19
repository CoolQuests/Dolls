using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RequestLoop
{
    class Loop1:ILoop
    {
        public Loop1()
        {
            _mineThread = new Thread(DoLoop);
        }

        private LoopState _state;
        private bool _isNeedStop = false;
        private bool _isNeedPause = false;
        private AutoResetEvent _pausedCancel = new AutoResetEvent(true);
        private EventWaitHandle _paused = null;
        private EventWaitHandle _started = null;
        private EventWaitHandle _stoped = null;

        private Thread _mineThread = null;

        private TimeSpan _timeoutBetwenCommand = TimeSpan.FromMilliseconds(10);
        private TimeSpan _timeoutIterations = TimeSpan.FromMilliseconds(10);

        #region Implementation of ILoop

        public void SetTimeoutBetwenCommand(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public void SetTimeoutIterations(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public void StartLoop()
        {
            throw new NotImplementedException();
        }

        public void StartLoop(EventWaitHandle wh)
        {
            throw new NotImplementedException();
        }

        public void StopLoop()
        {
            throw new NotImplementedException();
        }

        public void StopLoop(EventWaitHandle wh)
        {
            throw new NotImplementedException();
        }

        public void PauseLoop(bool paused)
        {
            throw new NotImplementedException();
        }

        public void PauseLoop(EventWaitHandle wh, bool paused)
        {
            throw new NotImplementedException();
        }

        public void AddToLoop(Action act)
        {
            throw new NotImplementedException();
        }

        public void AddToLoop(Action act, EventWaitHandle wh)
        {
            throw new NotImplementedException();
        }

        public event EventHandler LoopIterationEnd;

        public void OnLoopIterationEnd(EventArgs e)
        {
            EventHandler handler = LoopIterationEnd;
            if (handler != null) handler(this, e);
        }

        #endregion

        private void DoLoop()
        {
            _state = LoopState.Work;
            if (_started != null)
                _started.Set();
            while (!_isNeedStop)
            {
                if (_isNeedPause)
                {
                    _state = LoopState.Paused;
                    if (_paused != null)
                        _paused.Set();
                    _pausedCancel.WaitOne();
                    _state = LoopState.Work;
                }



                OnLoopIterationEnd(null);
            }
            if (_stoped != null)
                _stoped.Set();
        }
    }
}
