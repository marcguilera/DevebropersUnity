using Devebropers.Domains;
using UnityEngine;

namespace Devebropers.Storage.Local.Preferences
{
    internal class PreferenceFactory : DomainObjectBase<LocalStorageDomainFactories>, IPreferenceFactory
    {
        public PreferenceFactory(LocalStorageDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }
        
        public IPreference GetPreference(string name)
        {
            return new Preference(_domainFactories, name);
        }

        public void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
        }

        public void Save()
        {
            PlayerPrefs.Save();
        }
    }
}