using System;
using Devebropers.Domains;

namespace Devebropers.Random
{
    /// <summary>
    /// The random domain
    /// </summary>
    public class RandomDomainFactories : IDomainFactories
    {
        /// <summary>
        /// Gets a <see cref="IRandom"/>
        /// </summary>
        public virtual IRandom Random { get; }
        
        /// <summary>
        /// Gets a <see cref="ICodeGenerator"/>
        /// </summary>
        public virtual ICodeGenerator CodeGenerator { get; }

        public RandomDomainFactories()
        {
            Random = new Random(this);
            CodeGenerator = new CodeGenerator(this);
        }
    }
}