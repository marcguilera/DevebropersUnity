using System;
using Devebropers.Common;

namespace Devebropers.Diagnostics
{
    public abstract class ReporterBase <TClass> : IReporter
    {
        protected readonly IEventSender _eventSender;
        protected readonly TClass _target;

        protected ReporterBase(IEventSender eventSender, TClass target)
        {
            _eventSender = eventSender.AssignOrThrowIfNull(nameof(eventSender));
            _target = target.AssignOrThrowIfNull(nameof(target));
        }

        public abstract void StartReporting();
        public abstract void StopReporting();
    }
}