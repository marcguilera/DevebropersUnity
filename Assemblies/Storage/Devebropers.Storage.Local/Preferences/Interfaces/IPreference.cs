namespace Devebropers.Storage.Local.Preferences
{
    public interface IPreference
    {
        string Name { get; }
        bool HasValue { get; }
        double DoubleValue { get; set; }
        long LongValue { get; set; }
        string StringValue { get; set; }
        void Delete();
    }
}