using System;
using System.Linq;
using System.Text.RegularExpressions;
using Devebropers.Domains;

namespace Devebropers.Random
{
    internal class CodeGenerator : DomainObjectBase<RandomDomainFactories>, ICodeGenerator
    {
        public CodeGenerator(RandomDomainFactories domainFactories) 
            : base(domainFactories)
        {
        }
        
        public string Generate(string chars, int length)
        {
            if (string.IsNullOrWhiteSpace(chars))
            {
                throw new ArgumentException(nameof(chars));
            }
            if (length <= 0)
            {
                throw new ArgumentException(nameof(length));
            }
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_domainFactories.Random.Get(s.Length)]).ToArray());
        }

        public string Generate()
        {
            var randomNumber = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + DateTime.Now.Ticks;
            return Regex.Replace(randomNumber, "[^0-9a-zA-Z]+", "");
        }
    }
}