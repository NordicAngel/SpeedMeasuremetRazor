using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Helpers
{
    public static class JsonFileReader
    {
        /// <summary>
        /// Deserializes a catalog from a file.
        /// </summary>
        /// <typeparam name="T">The type the catalog consists of.</typeparam>
        /// <param name="filePath">The path of the file to deserialize</param>
        /// <returns>The Deserialized list of type <c>T</c></returns>
        public static List<T> ReadJson<T>(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonContent);
        }
    }
}
