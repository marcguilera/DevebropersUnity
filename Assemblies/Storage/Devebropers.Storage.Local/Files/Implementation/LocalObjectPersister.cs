using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Devebropers.Domains;

namespace Devebropers.Storage.Local.Files
{
    internal class LocalObjectPersister : DomainObjectBase<LocalStorageDomainFactories>, IObjectPersister
    {
        private readonly BinaryFormatter _binaryFormatter;
        public LocalObjectPersister(LocalStorageDomainFactories domainFactories) 
            : base(domainFactories)
        {
            _binaryFormatter = new BinaryFormatter();
        }


        public T Load<T>(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(nameof(path));
            }

            if (!Exists(path))
            {
                throw new FileException("File doesn't exist");
            }
            
            using (var file = File.Open(path, FileMode.Open))
            {
                var obj = (T) _binaryFormatter.Deserialize(file);
                file.Flush();
                file.Close();
                return obj;
            }
            
        }

        public void Write<T>(string path, T obj)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(nameof(path));
            }
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            
            using (var file = File.Create(path))
            {
                _binaryFormatter.Serialize(file, obj);
                file.Flush();
                file.Close();
            }
        }

        public bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(nameof(path));
            }
            
            return File.Exists(path);
        }
    }
}