using Devebropers.Data.Persistance;
using Firebase.Database;

namespace Devebropers.Nonce
{
    internal static class NonceDatabaseReferences
    {
        public static DatabaseReference Root() => DatabaseReferences.Root().Child("Nonces");
    }
}