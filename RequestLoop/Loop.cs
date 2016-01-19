using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RequestLoop
{
    class Loop:IDisposable
    {
        public Loop()
        {
            _threadLoop = new Thread(DoLoop);
            _threadLoop.Start();
        }

        private readonly TimeSpan _deleayLoop = TimeSpan.FromMilliseconds(10);

        private readonly Thread _threadLoop;

        private Task _threadTask = null;

        private readonly Queue<TaskDescriptor> _funcs = new Queue<TaskDescriptor>(); 

        public TaskDescriptor AddTask(Func<bool> task)
        {
            var taskDescriptor = new TaskDescriptor(task);
            lock (_funcs)
            {
                _funcs.Enqueue(taskDescriptor);
            }
            return taskDescriptor;
        }

        public bool Wait(TaskDescriptor descriptor)
        {

            descriptor.IsDone.WaitOne();
            return descriptor.Result;
        }


        public async Task<bool> AddTaskAsync(Func<bool> task)
        {
            var taskDescriptor = new TaskDescriptor(task);
            lock (_funcs)
            {
                _funcs.Enqueue(taskDescriptor);
            } 
            var asyncTask = new Task<bool>(() => Wait(taskDescriptor));

            return await asyncTask;
        }


        private void DoLoop(object param)
        {
            var isCansel = param is CancellationToken ? (CancellationToken) param : new CancellationToken();
            while (!isCansel.IsCancellationRequested)
            {
                if (_threadTask != null || _funcs.Count == 0)
                {
                    isCansel.WaitHandle.WaitOne(_deleayLoop);
                    continue;
                }
                TaskDescriptor start = null;
                lock (_funcs)
                {
                    start = _funcs.Dequeue();
                }
                if (start != null)
                {
                    _threadTask = new Task(() => start.Result = start.Task(), cancellationToken: start.CancelToken);
                    _threadTask.Start();
                    _threadTask.Wait(isCansel);
                    start.SetDone();
                    _threadTask = null;
                }
            }
        }

        public void Dispose()
        {
            if(_threadLoop.IsAlive)
                _threadLoop.Abort();
        }
    }
}
