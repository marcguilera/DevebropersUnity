using System;
using System.Globalization;

namespace Devebropers.I18n
{
    internal class LocalizationAuthority : ILocalizationAuthority
    {
        private CultureInfo _cultureInfo = CultureInfo.CurrentUICulture;

        public CultureInfo CultureInfo
        {
            get { return _cultureInfo; }
            set { _cultureInfo = value ?? throw new ArgumentNullException(nameof(value)); }
        }
    }
}