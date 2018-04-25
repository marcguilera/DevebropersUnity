using System;
using System.Reactive;
using Devebropers.Common;
using Devebropers.Remote.Storage;
using Devebropers.Storage.Remote.Deletions;

namespace Devebropers.Storage.Remote.Downloads
{
    internal class DownloadedFile : FileBase, IDownloadedFile
    {
        public override string Route { get; }
        public override long SizeBytes => Bytes.LongLength;
        public byte[] Bytes { get; }

        private readonly IDeleter _deleter;
        
        public DownloadedFile(RemoteStorageDomainFactories domainFactories, byte[] bytes, string route)
            : base(domainFactories)
        {
            Bytes = bytes;
            Route = route.AssignOrThrowIfNullOrWhiteSpace(nameof(route));
        }
    }
}