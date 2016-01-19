using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestDolls.Model
{
    public interface IDataService:IDisposable
    {
        /// <summary>
        /// Инициализировать настройки
        /// </summary>
        void Init();
        /// <summary>
        /// Запуск автоопроса модуля дискретных входов
        /// </summary>
        void StartAutoUpdate();
        /// <summary>
        /// Остановка автоопроса модуля дискретных входов
        /// </summary>
        void StopAutoUpdate();
        /// <summary>
        /// Получить последнее состояние заданного дискретного входа
        /// </summary>
        /// <param name="index">индекс дискретного входа</param>
        /// <returns>значение</returns>
        bool GetLastStateDi(int index);
        /// <summary>
        /// Событие о том что состояние дискретных входов изменилось (аргумент - сприсок изменившихся дискретных входов)
        /// </summary>
        event Action<IEnumerable<int>> InputStateChanged;

        /// <summary>
        /// Установить новое состояние реле
        /// </summary>
        /// <param name="index">индекс реле</param>
        /// <param name="value">состояние</param>
        void SetRelayState(int index, bool value);

        //void GetSateDoors(Action<bool, Exception> callback, string key);
        //void SetStateDoor(string doorKey, bool value);
        //bool GetStateDoor(string doorKey);
        //event EventHandler<DoorStateEventArg> DoorStateChanged;
    }
}
