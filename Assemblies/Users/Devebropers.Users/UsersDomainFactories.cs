using Devebropers.Domains;

namespace Devebropers.Users
{
    /// <summary>
    /// Represents a user domain factory
    /// </summary>
    public class UsersDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IUserFactory"/>
        /// </summary>
        public virtual IUserFactory UserFactory { get; }

        /// <summary>
        /// Creates a <see cref="UsersDomainFactories"/>
        /// </summary>
        public UsersDomainFactories()
        {
            UserFactory = new UserFactory();
        }
    }
}