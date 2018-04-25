using System;
using System.Reactive;

namespace Devebropers.Data.Entities
{
    public abstract class UpdateableResourceBase : ResourceBase, IUpdateableResource
    {
        public abstract override IObservable<Unit> Save();
    }
}