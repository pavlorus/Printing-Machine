using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utilities
{
    static class SerializeManager
    {
        public static object GetObjectFromTextStream(string textStream)
        {
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(textStream))
            {
                Position = 0
            };
            BinaryFormatter binaryObject = new BinaryFormatter();
            object result = binaryObject.Deserialize(memoryStream);
            memoryStream.Close();
            return result; // the return object need to Cast like this===>  // (List<SomeClass>)GetObjectFromTextStream(textStream);
        }

        public static string GetTextStreamFromObject(object objToStream)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, objToStream);
            memoryStream.Position = 0;
            long memoryStreamLength = memoryStream.Length;
            int streamLength = (int)memoryStreamLength;
            byte[] buffer = new byte[streamLength];
            memoryStream.Read(buffer, 0, streamLength);
            memoryStream.Close();
            return Convert.ToBase64String(buffer);
        }
    }
}