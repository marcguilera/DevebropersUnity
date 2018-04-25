using System;
using System.Collections.Generic;
using System.ComponentModel;
using Devebropers.Common;
using Firebase.Database;
using UnityEngine.Networking;

namespace Devebropers.Firebase.Database
{
    public class Query
    {
        public static Query Create(DatabaseReference reference) => new Query(reference);

        public Query And => this;
        
        public DatabaseReference FirebaseReference { get; private set; }
        public global::Firebase.Database.Query FirebaseQuery { get; private set; }

        private Query(DatabaseReference reference)
        {
            FirebaseReference = reference.AssignOrThrowIfNull(nameof(reference));
            FirebaseQuery = reference.OrderByValue();
        }

        public Query LimitToFirst(int num)
        {
            FirebaseQuery = FirebaseQuery.LimitToFirst(num);
            return this;
        }
        
        public Query LimitToLast(int num)
        {
            FirebaseQuery = FirebaseQuery.LimitToLast(num);
            return this;
        }
        
        public Query EqualTo(string key, long value)
        {
            FirebaseQuery = FirebaseQuery.EqualTo(value, key);
            return this;
        }
        
        public Query EqualTo(string key, double value)
        {
            FirebaseQuery = FirebaseQuery.EqualTo(value, key);
            return this;
        }
        
        public Query EqualTo(string key, string value)
        {
            FirebaseQuery = FirebaseQuery.EqualTo(value, key);
            return this;
        }
        
        
    }
}