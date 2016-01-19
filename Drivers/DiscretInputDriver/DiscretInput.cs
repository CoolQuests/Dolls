using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Device;

namespace DiscretInputDriver
{
    public class DiscretInputs : IDiscretInputs
    {
        readonly byte _address;

        private const int RegisterStartInputs = 3;
        private const int CountRegistersInputs = 2;

        private ushort[] _lastState = null;

        public DiscretInputs(byte address)
        {
            this._address = address;
        }

        /// <summary>
        /// Проверка наличия измененеий в состоянии входов
        /// </summary>
        /// <param name="master">Транспорт</param>
        /// <returns>Список изменившихся входов</returns>
        public IEnumerable<int> UpdateAllInputState(IModbusMaster master)
        {
            List<int> res = new List<int>();
            var answer = master.ReadInputRegisters(_address, RegisterStartInputs, CountRegistersInputs);
            if (_lastState == null)
            {
                _lastState = answer;
                for (int i = 0; i < (_lastState.Length * 16); i++)
                    res.Add(i);
            }
            else
            {
                for(int i = 0; i< answer.Length; i++)
                {
                    if(answer[i]==_lastState[i])
                        continue;
                    for(int bit = 0; bit<16; bit++)
                        if (GetBitFromUShortArray(_lastState, (i * 16 + bit)) != GetBitFromUShortArray(answer, (i * 16 + bit)))
                            res.Add(i * 16 + bit);
                }
            }
            return res;
        }

        /// <summary>
        /// Получить последнее прочитанное состояние дискретного входа 
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Состояние</returns>
        public bool GetLastInputState(int index)
        {
            return GetBitFromUShortArray(_lastState, index);
        }

        /// <summary>
        /// Прочитать состояние одного дискретного входа 
        /// </summary>
        /// <param name="master">Транспорт</param>
        /// <param name="index">Индекс входа</param>
        /// <returns>Значение дискретного входа</returns>
        public bool GetInput(IModbusMaster master, int index)
        {
            var answer = master.ReadInputRegisters(_address, RegisterStartInputs, CountRegistersInputs);

            return GetBitFromUShortArray(answer, index);
        }

        private bool GetBitFromUShortArray(ushort[] array, int index)
        {
            if(array == null)
                throw new NullReferenceException();
            var indexUshort = index/16;
            if(indexUshort>=array.Length)
                throw new IndexOutOfRangeException();
            ushort aimUshort = array[indexUshort];
            var indexBit = index%16;
            ushort bitsAnswer = (ushort) (aimUshort & (ushort)(1 >> indexBit));
            return bitsAnswer != 0;
        }
    }
}
