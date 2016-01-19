using System.Collections.Generic;

namespace QuestDolls.Settings
{
    public interface IMainSettings
    {
        Dictionary<string, int> DiscretInputKeys { get; }
        Dictionary<string, int> RelayKeys { get; }
        Dictionary<string, PortSettings> DevicePorts { get; }
    }
}