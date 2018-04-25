using System;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Storage.Remote;
using Devebropers.Storage.Remote.Deletions;

namespace Devebropers.Remote.Storage
{
    internal abstract class FileBase : DomainObjectBase<RemoteStorageDomainFactories>, IFile
    {
        public abstract string Route { get; }
        public abstract long SizeBytes { get; }

        protected FileBase(RemoteStorageDomainFactories domainFactories)
            : base (domainFactories)
        {
        }

        public IObservable<Unit> Delete()
        {
            return _domainFactories
                .Deleter
                .Delete(Route);
        }
    }
}