using System;
using Devebropers.Common;

namespace Devebropers.Authentication
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AuthenticateAttribute : Attribute
    {
        private readonly ISession _session;

        public AuthenticateAttribute(ISession session)
        {
            _session = session.AssignOrThrowIfNull(nameof(session));
        }

        public bool IsAuthenticated()
        {
            return _session.IsAuthenticated;
        }
    }
}