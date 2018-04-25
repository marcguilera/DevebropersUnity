using Firebase.Database;

namespace Devebropers.Data.Persistance
{
    public static class DatabaseReferences
    {
        public static DatabaseReference Root() => FirebaseDatabase.DefaultInstance.RootReference;
    }
}