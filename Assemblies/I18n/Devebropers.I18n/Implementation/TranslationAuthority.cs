using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Devebropers.Domains;
using NGettext;
using NGettext.Loaders;
using NGettext.PluralCompile;

namespace Devebropers.I18n
{
    internal class TranslationAuthority : DomainObjectBase<I18nDomainFactories>, IStringAuthority_Internal
    {
        private CultureInfo _defaultLocale => new CultureInfo("en-EN");
        private CultureInfo _currentLocale => _domainFactories.LocalizationAuthority.CultureInfo;
        
        public ICatalog Catalog { get; private set; }
        
        public TranslationAuthority(I18nDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }
        
        public void SetupTranslation(string localePath)
        {
            try
            {
                Catalog = new Catalog(new MoAstPluralLoader(localePath), _currentLocale);
            }
            catch (Exception e1)
            {
                try
                {
                    Catalog = new Catalog(new MoAstPluralLoader(localePath), _defaultLocale);
                }
                catch (Exception e2)
                {
                    throw new I18nException($"Couldnt load {_currentLocale} nor {_defaultLocale}", e1, e2);
                }
            }
            
        }
    }
}
