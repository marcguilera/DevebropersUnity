using System;
using System.Reactive;
using Devebropers.Data.Entities;

namespace Devebropers.Users
{
    internal class User : EntityBase<string, UserModel>, IAuthenticatedUser, IAnonymousUser
    {
        public bool IsAnonymous => _model.IsAnonymous;
        public string Name => _model.Name;
        public bool IsEmailVerified => _model.IsEmailVerified;
        public Uri PhotoUrl => _model.PhotoUrl;
        
        public User(UserModel model) 
            : base(model)
        {
        }

        public override IObservable<Unit> Save()
        {
            return null;
        }

        public override IObservable<Unit> Delete()
        {
            return null; // TODO
        }

        
    }
}