namespace Devebropers.Users
{
    /// <summary>
    /// An anonymous <see cref="IUser"/>
    /// </summary>
    public interface IAnonymousUser : IUser, IAnonymousUserIdentifier
    {
        
    }
}