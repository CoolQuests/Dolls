using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RequestLoop
{
    public class RequestLoopManager
    {
        private readonly IDictionary<int, Loop> _loops = new Dictionary<int, Loop>();

        public async Task<bool> AddTaskAsync(Func<bool> task, int priority)
        {
            if (!_loops.ContainsKey(priority))
                _loops.Add(priority, new Loop());
            return await _loops[priority].AddTaskAsync(task);
        }

        public TaskDescriptor AddTask(Func<bool> task, int priority)
        {
            if(!_loops.ContainsKey(priority))
                _loops.Add(priority, new Loop());
            return _loops[priority].AddTask(task);
        }
    }
}
