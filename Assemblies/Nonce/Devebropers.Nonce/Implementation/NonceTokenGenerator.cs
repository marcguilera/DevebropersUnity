using Devebropers.Domains;
using Firebase.Database;

namespace Devebropers.Nonce
{
    internal class NonceTokenGenerator : INonceTokenGenerator
    {
        private DatabaseReference _databaseReference => NonceDatabaseReferences.Root();
        
        public string NewToken()
        {
            return _databaseReference.Push().Key;
        }
    }
}