namespace Devebropers.I18n
{
    public interface IStringGetter
    {
        string Get(string str, params object[] values);
        string GetPlural(string singular, string plural, int count, params object[] values);
    }
}