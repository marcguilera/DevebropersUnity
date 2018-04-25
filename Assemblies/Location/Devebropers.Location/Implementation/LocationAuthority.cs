using System;
using System.Reactive.Subjects;
using Devebropers.Common;
using Devebropers.Common.Utils;
using Devebropers.Domains;
using UnityEngine;

namespace Devebropers.Location
{
    internal class LocationAuthority : DomainObjectBase<LocationDomainFactories>, ILocationAuthority
    {
        private readonly Func<TimeSpan> _intervalGetter;
        private readonly IntervalTask _task;
        private readonly ReplaySubject<ILocation> _locations;
        public ILocation LastLocation { get; private set; }
        public IObservable<ILocation> Locations => _locations;
        public bool IsEnabled => Input.location.isEnabledByUser;

        public LocationAuthority(LocationDomainFactories domainFactories, Func<TimeSpan> intervalGetter) 
            : base(domainFactories)
        {
            _intervalGetter = intervalGetter.AssignOrThrowIfNull(nameof(intervalGetter));
            
            _task = new IntervalTask(Elapsed);
            _locations = new ReplaySubject<ILocation>();
        }
        
        public void Start()
        {
            _task.Start(_intervalGetter());
            Input.location.Start();
        }

        public void Stop()
        {
            _task.Dispose();
            Input.location.Stop();
        }

        private void Elapsed()
        {
            var locationIndo = Input.location.lastData;
            var location = new Location(locationIndo);
            _locations.OnNext(location);
            LastLocation = location;
        }
    }
}