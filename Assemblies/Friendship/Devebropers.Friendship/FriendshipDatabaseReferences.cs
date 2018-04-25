using Devebropers.Data.Persistance;
using Firebase.Database;

namespace Devebropers.Friendship
{
    internal static class FriendshipDatabaseReferences
    {
        public static DatabaseReference Root() => DatabaseReferences.Root().Child("Friendship");
        public static DatabaseReference Friends() => Root().Child("Friends");
        public static DatabaseReference Requests() => Root().Child("Requests");
    }
}