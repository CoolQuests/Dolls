using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RequestLoop
{
    public class TaskDescriptor
    {
        #region Constructor
        public TaskDescriptor(Func<bool> task)
        {
            this.Task = task;
            _cancellation = new CancellationTokenSource();
            _cancellationToken = _cancellation.Token;
            _isDone = new AutoResetEvent(false);
        }
        #endregion

        #region Internal Members
        internal Func<bool> Task;

        private readonly CancellationTokenSource _cancellation;
        private readonly CancellationToken _cancellationToken;

        private readonly AutoResetEvent _isDone;

        private bool _result = false;
        #endregion

        #region Cancel
        public void Cancel()
        {
            _cancellation.Cancel();
        }

        public CancellationToken CancelToken { get { return _cancellationToken; } }
        public WaitHandle IsCancel{get { return _cancellationToken.WaitHandle; }}
        #endregion

        #region IsDone
        public WaitHandle IsDone{ get { return _isDone; } }

        internal void SetDone()
        {
            _isDone.Set();
        }
        #endregion

        #region Result
        public bool Result{get { return _result; } internal set { _result = value; }} 
        #endregion
    }
}
