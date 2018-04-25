using System;
using System.Collections.Generic;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Firebase.Settings;

namespace Devebropers.Settings
{
    internal class SettingFactory : DomainObjectBase<SettingsDomainFactories>, ISettingFactory
    {
        private readonly IFirebaseSettings _firebaseSettings;
        public SettingFactory(SettingsDomainFactories domainFactories, IFirebaseSettings firebaseSettings)
            : base (domainFactories)
        {
            _firebaseSettings = firebaseSettings.AssignOrThrowIfNull(nameof(firebaseSettings));
        }

        public void SetDefaults(IReadOnlyDictionary<string, object> defaultValues)
        {
            if (!defaultValues.IsNullOrEmpty())
            {
                _firebaseSettings.SetDefaults(defaultValues.ToDictionary());
            }
        }

        public ISetting Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            try
            {
                var setting = _firebaseSettings.GetValue(name);
                return new Setting(name, setting);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}