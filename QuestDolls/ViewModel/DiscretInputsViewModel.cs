using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;

namespace QuestDolls.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DiscretInputsViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the DiscretInputsViewModel class.
        /// </summary>
        public DiscretInputsViewModel(IEnumerable<string> inputNames)
        {
            _inputs = new ObservableCollection<OneInputViewModel>( inputNames.Select((el) => new OneInputViewModel(el)));
            foreach (var input in _inputs)
            {
                input.PropertyChanged +=input_PropertyChanged;
            }
        }

        void input_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var input = sender as OneInputViewModel;
            if(input==null)
                return;
            for (int i = 0; i < _inputs.Count; ++i)
            {
                if(input.Name == _inputs[i].Name)
                    OnPropertyChanged( i);
            }
        }

        private void OnPropertyChanged(int indexInput)
        {
            var handler = this.PropertyChangedHandler;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(string.Format("Inputs[{0}].Value", indexInput)));
        }

        private readonly ObservableCollection<OneInputViewModel> _inputs;
        private bool _in00;

        public ObservableCollection<OneInputViewModel> Inputs
        {
            get { return _inputs; }
        }

        public override void Cleanup()
        {
            // Clean up if needed
            if (_inputs!=null)
                foreach (var input in _inputs)
                {
                    input.PropertyChanged -= input_PropertyChanged;
                }
            base.Cleanup();
        }
    }
}