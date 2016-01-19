using System.Linq.Expressions;
using GalaSoft.MvvmLight;
using QuestDolls.Model;

namespace QuestDolls.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DoolsViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// Initializes a new instance of the DoolsViewModel class.
        /// </summary>
        public DoolsViewModel(IDataService dataService)
        {
            _dataService = dataService;
            //_dataService.GetSateDoors((item, error) => { Door0 = item; }, "0");
            //_dataService.DoorStateChanged += _dataService_DoorStateChanged;

        }

        void _dataService_DoorStateChanged(object sender, DoorStateEventArg e)
        {
            switch (e.Key)
            {
                case "0": Door0 = e.NewValue; break;
                case "1": Door1 = e.NewValue; break;
                case "2": Door2 = e.NewValue; break;
                case "3": Door3 = e.NewValue; break;
                case "4": Door4 = e.NewValue; break;
                case "5": Door5 = e.NewValue; break;
                case "6": Door6 = e.NewValue; break;
                case "7": Door7 = e.NewValue; break;
                case "8": Door8 = e.NewValue; break;
                case "9": Door9 = e.NewValue; break;
            }
        }

        private bool _door0;
        public bool Door0{ get { return _door0; } set { Set(ref _door0, value); }}

        private bool _door1;
        public bool Door1{ get { return _door1; } set { Set(ref _door1, value); }}

        private bool _door2;
        public bool Door2{ get { return _door2; } set { Set(ref _door2, value); }}

        private bool _door3;
        public bool Door3{ get { return _door3; } set { Set(ref _door3, value); }}

        private bool _door4;
        public bool Door4{ get { return _door4; } set { Set(ref _door4, value); }}

        private bool _door5;
        public bool Door5{ get { return _door5; } set { Set(ref _door5, value); }}

        private bool _door6;
        public bool Door6{ get { return _door6; } set { Set(ref _door6, value); }}

        private bool _door7;
        public bool Door7{ get { return _door7; } set { Set(ref _door7, value); }}

        private bool _door8;
        public bool Door8{ get { return _door8; } set { Set(ref _door8, value); }}

        private bool _door9;
        public bool Door9{ get { return _door9; } set { Set(ref _door9, value); }}
    }
}