using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestDolls.Model
{
    public class DoorStateEventArg: EventArgs
    {
        public DoorStateEventArg(string key, bool newValue)
        {
            NewValue = newValue;
            Key = key;
        }

        public string Key { get; private set; }
        public bool NewValue { get; private set; }
    }
}
