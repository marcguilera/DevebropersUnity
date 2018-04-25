using System;
using System.Reactive;
using System.Runtime.CompilerServices;
using Devebropers.Common;
using Devebropers.Domains;
using Devebropers.Remote.Storage;
using Devebropers.Storage.Remote.Deletions;
using Firebase.Storage;

namespace Devebropers.Storage.Remote.Uploads
{
    internal class UploadedFile : FileBase, IUploadedFile
    {
        public Uri DownloadUrl => _meta.DownloadUrl;
        public string Name => _meta.Name;
        public override string Route => _meta.Path;
        public override long SizeBytes => _meta.SizeBytes;
        
        private readonly StorageMetadata _meta;

        public UploadedFile(RemoteStorageDomainFactories domainFactories, StorageMetadata meta)
            : base(domainFactories)
        {
            _meta = meta.AssignOrThrowIfNull(nameof(meta));
        }
    }
}