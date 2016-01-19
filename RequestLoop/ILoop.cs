using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RequestLoop
{
    interface ILoop
    {
        void SetTimeoutBetwenCommand(TimeSpan timeout);
        void SetTimeoutIterations(TimeSpan timeout);

        void StartLoop();
        void StartLoop(EventWaitHandle wh);

        void StopLoop();
        void StopLoop(EventWaitHandle wh);

        void PauseLoop(bool paused);
        void PauseLoop(EventWaitHandle wh, bool paused);

        void AddToLoop(Action act);
        void AddToLoop(Action act, EventWaitHandle wh);

        event EventHandler LoopIterationEnd;
    }
}
