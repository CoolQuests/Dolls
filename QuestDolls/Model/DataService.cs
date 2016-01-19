using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using DiscretInputDriver;
using MainLoop;
using Microsoft.Practices.ServiceLocation;
using Modbus.Device;
using Modbus.IO;
using QuestDolls.Settings;
using RelayDriver;

namespace QuestDolls.Model
{
    public class DataService : IDataService
    {
        private readonly IDictionary<string,bool> _doorState = new Dictionary<string, bool>();

        private readonly ILoops _loops = new Loops();

        private readonly IDictionary<string, IModbusMaster> _ports = new Dictionary<string, IModbusMaster>();

        private readonly Func<Type, string, object> _ioc;

        private readonly IMainSettings _settings;

        private IRelay _relay;

        private IDiscretInputs _discretInputs;
        private bool _isNeedAutoupdate = false;

        public DataService(Func<Type, string, object> ioc, IMainSettings settings)
        {
            _ioc = ioc;
            _settings = settings;
        }

        #region Init
        /// <summary>
        /// Инициализировать настройки
        /// </summary>
        public void Init()
        {

            if(_settings!=null)
                InitSetiings();
            if (_ioc != null)
            {
                _relay = _ioc(typeof(IRelay), "Relay") as IRelay;
                _discretInputs = _ioc(typeof(IDiscretInputs), "DiscretInput") as IDiscretInputs;
            }
        }

        private void InitSetiings()
        {
            var ports = new List<string>();
            foreach (var devicePort in _settings.DevicePorts)
            {
                if(ports.Contains(devicePort.Value.Name))
                    throw new DuplicateNameException(devicePort.Value.Name);
                ports.Add(devicePort.Value.Name);
                var port = new SerialPort(devicePort.Value.Name, devicePort.Value.Rate, devicePort.Value.Parity,
                    devicePort.Value.DataBits, devicePort.Value.StopBits)
                {
                    ReadTimeout = devicePort.Value.ReadTimeout,
                    WriteTimeout = devicePort.Value.WriteTimeout
                };
                var modbus = ModbusSerialMaster.CreateRtu(port);
                _ports.Add(devicePort.Key, modbus);
                _loops.AddLocker(devicePort.Key, modbus, null);
            }
        }
        #endregion

        #region Implementation IDataService
        /// <summary>
        /// Запуск автоопроса модуля дискретных входов
        /// </summary>
        public void StartAutoUpdate()
        {
            _isNeedAutoupdate = true;
            _loops.StartMiddleAction("DiscretInput", AutoUpdateInputs);
        }

        /// <summary>
        /// Остановка автоопроса модуля дискретных входов
        /// </summary>
        public void StopAutoUpdate()
        {
            _isNeedAutoupdate = false;
        }

        /// <summary>
        /// Получить последнее состояние заданного дискретного входа
        /// </summary>
        /// <param name="index">индекс дискретного входа</param>
        /// <returns>значение</returns>
        public bool GetLastStateDi(int index)
        {
            return _discretInputs.GetLastInputState(index);
        }

        /// <summary>
        /// Событие о том что состояние дискретных входов изменилось (аргумент - сприсок изменившихся дискретных входов)
        /// </summary>
        public event Action<IEnumerable<int>> InputStateChanged;

        /// <summary>
        /// Установить новое состояние реле
        /// </summary>
        /// <param name="index">индекс реле</param>
        /// <param name="value">состояние</param>
        public void SetRelayState(int index, bool value)
        {
            _loops.StartMiddleAction("Relay", (mb) => _relay.SetRelayState(mb as IModbusMaster, index, value));
        }

        //public void SetStateDoor(string doorKey, bool value)
        //{
        //    var oldValue = GetStateDoor(doorKey);
        //    if (!_doorState.ContainsKey(doorKey))
        //        _doorState.Add(doorKey, value);
        //    else
        //        _doorState[doorKey] = value;
        //    if (oldValue!=value)
        //        OnDoorStateChanged(new DoorStateEventArg(doorKey, value));
        //}

        //public bool GetStateDoor(string doorKey)
        //{
        //    if (!_doorState.ContainsKey(doorKey))
        //        return false;
        //    else
        //        return _doorState[doorKey];
        //}
        
        //public void GetSateDoors(Action<bool, Exception> callback, string key)
        //{
        //    callback(GetStateDoor(key), null);
        //}

        //public event EventHandler<DoorStateEventArg> DoorStateChanged;

        public void Dispose()
        {
            _loops.Dispose();
        }
        #endregion

        #region Service members
        #region Event Invocators
        //protected virtual void OnDoorStateChanged(DoorStateEventArg e)
        //{
        //    EventHandler<DoorStateEventArg> handler = DoorStateChanged;
        //    if (handler != null) handler(this, e);
        //}

        protected virtual void OnInputStateChanged(IEnumerable<int> obj)
        {
            Action<IEnumerable<int>> handler = InputStateChanged;
            if (handler != null) handler(obj);
        }
        #endregion

        void AutoUpdateInputs(object mb)
        {
            var result = _discretInputs.UpdateAllInputState(mb as IModbusMaster);
            if (result.Any())
                OnInputStateChanged(result);
            if(_isNeedAutoupdate)
                _loops.StartMiddleAction("DiscretInput", AutoUpdateInputs);
        }


        #endregion
    }
}