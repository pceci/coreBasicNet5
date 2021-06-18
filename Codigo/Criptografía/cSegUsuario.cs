using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace coreBasicNet5.Codigo.Criptografía
{
    public class cSegUsuario : ISerializable
    {
        public cSegUsuario() { }
        private string _keyPublic { get; set; }
        private string _keyPrivate { get; set; }

 

        public string keyPublic
        {
            get { return _keyPublic; }
            set { _keyPublic = value; }
        }
        public string keyPrivate
        {
            get { return _keyPrivate; }
            set { _keyPrivate = value; }
        }
        // Implement this method to serialize data. The method is called 
        // on serialization.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("keyPublic", _keyPublic, typeof(string));
            info.AddValue("keyPrivate", _keyPrivate, typeof(string));
        }

        // The special constructor is used to deserialize values.
        public cSegUsuario(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            _keyPublic = (string)info.GetValue("keyPublic", typeof(string));
            _keyPrivate = (string)info.GetValue("keyPrivate", typeof(string));
        }

    }
}