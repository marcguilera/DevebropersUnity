using Devebropers.Domains;

namespace Devebropers.Firebase.Invites
{
    public class FirebaseInvitesDomainFactories : IDomainFactories
    {
        public virtual IFirebaseInvites FirebaseInvites { get; }

        public FirebaseInvitesDomainFactories()
        {
            FirebaseInvites = new FirebaseInvites();
        }
    }
}