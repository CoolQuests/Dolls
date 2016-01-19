using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestDolls.Settings
{
    class MainSettings : IMainSettings
    {
        public static MainSettings LoadSettings()
        {
            return new MainSettings()
            {
                DevicePorts = new Dictionary<string, PortSettings>()
                {
                    {"DiscretInput", new PortSettings(){Name = "COM1", Rate = 9600, Parity = Parity.None, DataBits = 8, StopBits = StopBits.One, ReadTimeout = 1000, WriteTimeout = 1000}},
                    {"Relay", new PortSettings(){Name = "COM2", Rate = 9600, Parity = Parity.None, DataBits = 8, StopBits = StopBits.One, ReadTimeout = 1000, WriteTimeout = 1000}}
                },
                DiscretInputKeys = new Dictionary<string, int>()
                {
                    {"1 вход", 0}, {"2 вход", 1}, {"3 вход", 2}, {"4 вход", 3}, {"5 вход", 4}, {"6 вход", 5},
                    {"7 вход", 6}, {"8 вход", 7}, {"9 вход", 8}, {"10 вход", 9}, {"11 вход", 10}, {"12 вход", 11},
                    {"13 вход", 12}, {"14 вход", 13}, {"15 вход", 14},
                },
                RelayKeys = new Dictionary<string, int>()
                {
                    {"1 выход", 0}, {"2 выход", 1}, {"3 выход", 2}, {"4 выход", 3}, {"5 выход", 4}, {"6 выход", 5},
                    {"7 выход", 6}, {"8 выход", 7}, {"9 выход", 8}, {"10 выход", 9}, {"11 выход", 10}, {"12 выход", 11},
                }
            };
        }

        public Dictionary<string, int> DiscretInputKeys { get; set; }
        public Dictionary<string, int> RelayKeys { get; set; }
        public Dictionary<string, PortSettings> DevicePorts { get; set; } 
    }
}
