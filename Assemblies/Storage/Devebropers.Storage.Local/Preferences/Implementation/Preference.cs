using Devebropers.Common;
using Devebropers.Domains;
using UnityEngine;

namespace Devebropers.Storage.Local.Preferences
{
    internal class Preference : DomainObjectBase<LocalStorageDomainFactories>, IPreference
    {
        public string Name { get; }
        public bool HasValue => PlayerPrefs.HasKey(Name);

        public double DoubleValue
        {
            get { return PlayerPrefs.GetFloat(Name); }
            set { PlayerPrefs.SetFloat(Name, (float) value); Save(); }
        }

        public long LongValue 
        {
            get { return PlayerPrefs.GetInt(Name); }
            set { PlayerPrefs.SetInt(Name, (int) value); Save(); }
        }
        
        public string StringValue 
        {
            get { return PlayerPrefs.GetString(Name); }
            set { PlayerPrefs.SetString(Name, value); Save();}
        }

        public Preference(LocalStorageDomainFactories domainFactories, string name)
            : base (domainFactories)
        {
            Name = name.AssignOrThrowIfNullOrWhiteSpace(nameof(name));
        }
        
        public void Delete()
        {
            PlayerPrefs.DeleteKey(Name);
            Save();
        }

        private void Save()
        {
            _domainFactories.PreferenceFactory.Save();
        }
    }
}