using Devebropers.Common;
using Firebase.RemoteConfig;

namespace Devebropers.Settings
{
    internal class Setting : ISetting
    {
        private readonly ConfigValue _configValue;
        
        public string Name { get; }
        public string StringValue => _configValue.StringValue;
        public long LongValue => _configValue.LongValue;
        public double DoubleValue => _configValue.DoubleValue;
        
        public Setting(string name, ConfigValue configValue)
        {
            Name = name.AssignOrThrowIfNullOrWhiteSpace(nameof(name));
            _configValue = configValue.AssignOrThrowIfNull(nameof(configValue));
        }
    }
}