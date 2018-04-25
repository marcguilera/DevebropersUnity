namespace Devebropers.Storage.Local.Preferences
{
    public interface IPreferenceFactory
    {
        IPreference GetPreference(string name);
        void DeleteAll();
        void Save();
    }
}