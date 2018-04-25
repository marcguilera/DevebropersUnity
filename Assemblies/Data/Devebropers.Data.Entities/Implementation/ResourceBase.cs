using System;
using System.Reactive;

namespace Devebropers.Data.Entities
{
    public abstract class ResourceBase : IUpdateableResource
    {
        public abstract IObservable<Unit> Save();
    }
}