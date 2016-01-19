using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Device;

namespace RelayDriver
{
    public class Relay : IRelay
    {
        readonly byte _address;

        private const int RegisterStartRelays = 3;
        private const int CountRegistersRelays = 2;

        public Relay(byte address)
        {
            this._address = address;
        }

        #region implementation IRelay
        /// <summary>
        /// Get state relay by index
        /// </summary>
        /// <param name="master">modbus transport</param>
        /// <param name="index">aim index</param>
        /// <returns>state relay</returns>
        public bool GetRelayState(IModbusMaster master, int index)
        {
            var answer = master.ReadInputRegisters(_address, RegisterStartRelays, CountRegistersRelays);
            return GetBitFromUShortArray(answer, index);
        }

        /// <summary>
        /// Set state relay by index
        /// </summary>
        /// <param name="master">modbus transport</param>
        /// <param name="index">aim index relay</param>
        /// <param name="value">aim value relay</param>
        public void SetRelayState(IModbusMaster master, int index, bool value)
        {
            var answer = master.ReadInputRegisters(_address, RegisterStartRelays, CountRegistersRelays);
            var state = SetBitToUShortArray(answer, index, value);
            master.WriteMultipleRegisters(_address, RegisterStartRelays, state);
        }
        #endregion

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

        private ushort[] SetBitToUShortArray(ushort[] array, int index, bool value)
        {
            if (array == null)
                throw new NullReferenceException();
            var indexUshort = index / 16;
            if (indexUshort >= array.Length)
                throw new IndexOutOfRangeException();
            ushort aimUshort = array[indexUshort];
            var indexBit = index % 16;
            ushort bitsAnswer = value ? (ushort)(aimUshort | (ushort)(1 >> indexBit)) : (ushort)(aimUshort & (~(ushort)(1 >> indexBit)));
            array[indexUshort] = bitsAnswer;
            return array;
        }
    }
}
