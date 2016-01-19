using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using QuestDolls.Model;
using QuestDolls.Settings;

namespace QuestDolls.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private readonly IMainSettings _settings;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, IMainSettings settings)
        {
            _dataService = dataService;
            _settings = settings;
            _dataService.Init();
            _dataService.InputStateChanged += _dataService_InputStateChanged;
            //Doors = new DoolsViewModel(_dataService);
            DiscretInputs = new DiscretInputsViewModel(_settings.DiscretInputKeys.Keys);
            Relays = new RelaysViewModel(_settings.RelayKeys.Keys, (key, value) => _dataService.SetRelayState(_settings.RelayKeys[key], value));
        }

        void _dataService_InputStateChanged(IEnumerable<int> changedIndexes)
        {
            var indexes = changedIndexes as int[] ?? changedIndexes.ToArray();
            foreach (var input in DiscretInputs.Inputs)
            {
                var index = _settings.DiscretInputKeys[input.Name];
                if (indexes.Contains(index))
                    input.Value = _dataService.GetLastStateDi(index);
            }
        }

        //public ICommand OperDoor
        //{
        //    get
        //    {
        //        return new RelayCommand<string>((arg) =>
        //            _dataService.SetStateDoor(arg, !_dataService.GetStateDoor(arg)));
        //    }
        //}

        private DoolsViewModel _doors;
        public DoolsViewModel Doors
        {
            get { return _doors; }
            set { Set(ref _doors, value); }
        }

        private DiscretInputsViewModel _discretInputs;
        private RelaysViewModel _relays;

        public DiscretInputsViewModel DiscretInputs
        {
            get { return _discretInputs; }
            set { Set(ref _discretInputs, value); }
        }

        public RelaysViewModel Relays
        {
            get { return _relays; }
            set { Set(ref _relays, value); }
        }

        public override void Cleanup()
        {
            // Clean up if needed
            _dataService.InputStateChanged -= _dataService_InputStateChanged;
            base.Cleanup();
        }
    }
}