using System;
using System.Dynamic;

namespace Devebropers.Common.Patterns
{
    public abstract class Singleton <TClass>
        where TClass : class
    {
        private TClass _instance;
        
        public TClass Instance
        {
            get
            {
                lock (_instance)
                {
                    if (_instance == null)
                    {
                        _instance = CreateInstance();
                    }
                    return _instance;
                }
            }
        }

        protected abstract TClass CreateInstance();
    }

    public class DelegateSingleton<TClass> : Singleton<TClass>
        where TClass : class
    {
        private readonly Func<TClass> _classGetter;

        public DelegateSingleton(Func<TClass> classGetter)
        {
            _classGetter = classGetter.AssignOrThrowIfNull(nameof(classGetter));
        }

        protected override TClass CreateInstance()
        {
            return _classGetter();
        }
    }
}