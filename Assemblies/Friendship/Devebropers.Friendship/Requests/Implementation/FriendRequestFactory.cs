using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Devebropers.Domains;
using Devebropers.Friendship.Requests.Entities;
using Devebropers.Users;

namespace Devebropers.Friendship.Requests
{
    internal class FriendRequestFactory : DomainObjectBase<FriendshipDomainFactories>, IFriendRequestFactory
    {
        public event OnFriendRequestSentEventHandler OnFriendRequestSent;
        
        public FriendRequestFactory(FriendshipDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }

        
        public IObservable<IEnumerable<IIncomingFriendRequest>> GetIncomingFriendRequests(IUserIdentifier user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            return _domainFactories
                .FriendRequestEntityFactory
                .GetIncomingFriendRequests(user.Id)
                .Select(requests => requests.Select(ToIncomingFriendRequest));
        }

        public IObservable<IEnumerable<IOutgoingFriendRequest>> GetOutgoingFriendRequests(IUserIdentifier user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            return _domainFactories
                .FriendRequestEntityFactory
                .GetOutgoingFriendRequests(user.Id)
                .Select(requests => requests.Select(ToOutgoingRequest));
        }

        public IObservable<IOutgoingFriendRequest> SendRequest(IUser source, IUser target)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            
            var request = _domainFactories
                .FriendRequestEntityFactory
                .CreateFriendRequest(source.Id, source.Name, target.Id, target.Name);

            return request
                .Save()
                .Select(nothing => ToOutgoingRequest(request))
                .Do(InvokeOnFriendRequestSent);
        }

        private IIncomingFriendRequest ToIncomingFriendRequest(IFriendRequestEntity entity)
        {
            return new IncomingFriendRequest(entity);
        }
        
        private IOutgoingFriendRequest ToOutgoingRequest(IFriendRequestEntity entity)
        {
            return new OutgoingFriendRequest(entity);
        }

        private void InvokeOnFriendRequestSent(IFriendRequest friendRequest)
        {
            OnFriendRequestSent?.Invoke(friendRequest);
        }
    }
}