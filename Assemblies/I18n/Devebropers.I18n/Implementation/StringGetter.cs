using System.Globalization;
using Devebropers.Domains;
using NGettext;

namespace Devebropers.I18n
{
    internal class StringGetter : DomainObjectBase<I18nDomainFactories>, IStringGetter
    {
        private ICatalog _catalog => _domainFactories.StringAuthorityInternal.Catalog;
        
        public StringGetter(I18nDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }

        public string Get(string str, params object[] values)
        {
            return _catalog
                .GetString(str, values);
        }

        public string GetPlural(string singular, string plural, int count, params object[] values)
        {
            return _catalog
                .GetPluralString(singular, plural, count, values);
        }
        
    }
}