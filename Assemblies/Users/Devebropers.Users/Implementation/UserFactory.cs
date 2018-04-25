using System;

namespace Devebropers.Users
{
    internal class UserFactory : IUserFactory
    {
        public IAnonymousUser CreateAnonymousUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(nameof(id));
            }

            var model = new UserModel
            {
                Id = id,
                IsAnonymous = true
            };
            
            return NewUser(model);
        }

        public IAuthenticatedUser CreateAuthenticatedUser(string id, string name, bool isEmailVerified = false, Uri photoUrl = null)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(nameof(id));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }
            
            var model = new UserModel
            {
                Id = id,
                Name = name,
                IsEmailVerified = isEmailVerified,
                IsAnonymous = false,
                PhotoUrl = photoUrl
            };
            
            return NewUser(model);
        }

        private User NewUser(UserModel model)
        {
            return new User(model);
        }
    }
}