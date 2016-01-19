using DiscretInputDriver;
using GalaSoft.MvvmLight;

namespace QuestDolls.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class OneInputViewModel : ViewModelBase
    {
        private string _name;
        private bool _value;

        /// <summary>
        /// Initializes a new instance of the OneInputViewModel class.
        /// </summary>
        public OneInputViewModel(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        public bool Value
        {
            get { return _value; }
            set { Set(ref _value, value); }
        }
    }
}