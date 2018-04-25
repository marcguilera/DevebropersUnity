using Devebropers.Data;

namespace Devebropers.Users
{
    internal class UserIdentifier : IdentifierBase<string>, IAuthenticatedUserIdentifier, IAnonymousUserIdentifier
    {
        public UserIdentifier(string id) 
            : base(id)
        {
        }
    }
}