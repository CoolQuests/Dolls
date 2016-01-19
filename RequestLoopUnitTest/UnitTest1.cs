using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RequestLoop;

namespace RequestLoopUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var loopManager = new RequestLoopManager();
            TaskDescriptor descr0 = null;
            TaskDescriptor descr1 = null;

            var res0 = new TimeSpan();
            var res1 = new TimeSpan();
            const int count = 1000;
            const int delay = 2;
            var st = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                descr0 = loopManager.AddTask(() =>
                {
                    res0 = st.Elapsed;
                    Thread.Sleep(delay);
                    return true;
                }, 0);
            }
            descr1 = loopManager.AddTask(() =>
            {
                res1 = st.Elapsed;
                Thread.Sleep(delay);
                return true;
            }, 1);
            
            if (descr0!=null)
                descr0.IsDone.WaitOne();
            if (descr1!=null)
                descr1.IsDone.WaitOne();

            var res = st.Elapsed;
            var maxTime = count*Math.Max(delay*2.05, 1.0);
            Console.Write(string.Format("res.TotalMilliseconds = {0} < maxTime = {1}", res.TotalMilliseconds, maxTime));
            Console.Write(string.Format("res1 = {0} < res0 = {1}", res1, res0));
            Assert.IsTrue(res.TotalMilliseconds < maxTime);
            Assert.IsTrue(res1 < res0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var loopManager = new RequestLoopManager();
            IList<Task<bool>> descrs = new List<Task<bool>>();
            var st = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                descrs.Add(loopManager.AddTaskAsync(() => true, 0));
            }
            Task.WaitAll(descrs.ToArray());
            var result = st.Elapsed;
            Assert.IsTrue(result.TotalMilliseconds < 100);
        }
    }
}
