using System.Collections.Generic;
using Modbus.Device;

namespace DiscretInputDriver
{
    public interface IDiscretInputs
    {
        /// <summary>
        /// Проверка наличия измененеий в состоянии входов
        /// </summary>
        /// <param name="master">Транспорт</param>
        /// <returns>Список изменившихся входов</returns>
        IEnumerable<int> UpdateAllInputState(IModbusMaster master);

        /// <summary>
        /// Получить последнее прочитанное состояние дискретного входа 
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Состояние</returns>
        bool GetLastInputState(int index);

        /// <summary>
        /// Прочитать состояние одного дискретного входа 
        /// </summary>
        /// <param name="master">Транспорт</param>
        /// <param name="index">Индекс входа</param>
        /// <returns>Значение дискретного входа</returns>
        bool GetInput(IModbusMaster master, int index);
    }
}