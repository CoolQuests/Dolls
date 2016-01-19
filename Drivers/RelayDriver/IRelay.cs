using Modbus.Device;

namespace RelayDriver
{
    public interface IRelay
    {
        /// <summary>
        /// Get state relay by index
        /// </summary>
        /// <param name="master">modbus transport</param>
        /// <param name="index">aim index</param>
        /// <returns>state relay</returns>
        bool GetRelayState(IModbusMaster master, int index);

        /// <summary>
        /// Set state relay by index
        /// </summary>
        /// <param name="master">modbus transport</param>
        /// <param name="index">aim index relay</param>
        /// <param name="value">aim value relay</param>
        void SetRelayState(IModbusMaster master, int index, bool value);
    }
}