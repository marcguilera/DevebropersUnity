namespace Devebropers.Diagnostics
{
    public interface IReporter
    {
        void StartReporting();
        void StopReporting();
    }
}