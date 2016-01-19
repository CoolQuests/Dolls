using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using GalaSoft.MvvmLight;

namespace QuestDolls.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RelaysViewModel : ViewModelBase
    {
        private readonly IEnumerable<OneRelayViewModel> _relays;

        /// <summary>
        /// Initializes a new instance of the RelaysViewModel class.
        /// </summary>
        public RelaysViewModel(IEnumerable<string> relayNames, Action<string, bool> setRelayState)
        {
            _relays = relayNames.Select((el) => new OneRelayViewModel(el, false, val => setRelayState(el, val)));
        }

        public IEnumerable<OneRelayViewModel> Relays
        {
            get { return _relays; }
        }
    }
}