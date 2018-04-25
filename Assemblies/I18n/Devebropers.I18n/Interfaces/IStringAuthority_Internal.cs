using NGettext;

namespace Devebropers.I18n
{
    internal interface IStringAuthority_Internal : ITranslationAuthority
    {
        ICatalog Catalog { get; }
    }
}