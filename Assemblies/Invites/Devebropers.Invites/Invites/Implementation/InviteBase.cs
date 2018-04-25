using System;
using System.Collections.Generic;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Domains;

namespace Devebropers.Invites
{
    internal abstract class InviteBase : DomainObjectBase<InvitesDomainFactories>, IInvite
    {
        public string Id { get; set; }
        public string TitleText { get; set; }
        public string MessageText { get; set; }
        public string CallToActionText { get; set; }
        public Uri CallToActionUrl { get; set; }
        public IDictionary<string, string> ReferralParams { get; } = new Dictionary<string, string>();

        protected InviteBase(InvitesDomainFactories domainFactories)
            : base(domainFactories)
        {
        }
    }
}