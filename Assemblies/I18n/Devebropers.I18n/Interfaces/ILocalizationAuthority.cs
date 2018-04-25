using System.Globalization;

namespace Devebropers.I18n
{
    public interface ILocalizationAuthority
    {
        CultureInfo CultureInfo { get; set; }
    }
}