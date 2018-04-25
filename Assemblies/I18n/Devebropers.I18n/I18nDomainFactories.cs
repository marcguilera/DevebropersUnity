using System;
using Devebropers.Domains;

namespace Devebropers.I18n
{
    public class I18nDomainFactories : IDomainFactories
    {
        internal IStringAuthority_Internal StringAuthorityInternal { get; }
        
        public ILocalizationAuthority LocalizationAuthority { get; }
        public ITranslationAuthority TranslationAuthority => StringAuthorityInternal;
        public IStringGetter StringGetter { get; }

        public I18nDomainFactories()
        {
            LocalizationAuthority = new LocalizationAuthority();
            StringAuthorityInternal = new TranslationAuthority(this);
            StringGetter = new StringGetter(this);
        }
    }
}