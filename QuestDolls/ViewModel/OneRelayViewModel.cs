using System;
using GalaSoft.MvvmLight;

namespace QuestDolls.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class OneRelayViewModel : ViewModelBase
    {
        private Action<bool> _setRelayState;
        private string _header;
        private bool _value;

        /// <summary>
        /// Initializes a new instance of the OneRelayViewModel class.
        /// </summary>
        public OneRelayViewModel(string header, bool value, Action<bool> setRelayState)
        {
            _header = header;
            _value = value;
            _setRelayState = setRelayState;
        }

        public string Header
        {
            get { return _header; }
            set { Set(ref _header, value); }
        }

        public bool Value
        {
            get { return _value; }
            set
            {
                Set(ref _value, value);
                _setRelayState(value);
            }
        }
    }
}