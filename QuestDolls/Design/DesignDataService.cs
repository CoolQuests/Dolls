using System;
using System.Collections.Generic;
using QuestDolls.Model;

namespace QuestDolls.Design
{
    public class DesignDataService : IDataService
    {
        private DataItem item;

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data
            item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }

        public void GetSateDoors(Action<bool, Exception> callback, string key)
        {
            throw new NotImplementedException();
        }

        public void SetStateDoor(string doorKey, bool value)
        {
            if (item == null)
                return;
            int index;
            if (!int.TryParse(doorKey, out index))
                return;
        }

        public bool GetStateDoor(string doorKey)
        {
            if(item == null)
                return false;
            int index;
            if(!int.TryParse(doorKey, out index))
                return false;
            return false;
        }

        public event EventHandler<DoorStateEventArg> DoorStateChanged;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void StartAutoUpdate()
        {
            throw new NotImplementedException();
        }

        public void StopAutoUpdate()
        {
            throw new NotImplementedException();
        }

        public bool GetLastStateDi(int index)
        {
            throw new NotImplementedException();
        }

        public event Action<IEnumerable<int>> InputStateChanged;
        public void SetRelayState(int index, bool value)
        {
            throw new NotImplementedException();
        }
    }
}