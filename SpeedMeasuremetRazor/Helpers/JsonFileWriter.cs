using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Helpers
{
    public static class JsonFileWriter
    {
        /// <summary>
        /// Serializes a catalog to the given file.
        /// </summary>
        /// <typeparam name="T">The type the catalog consists of.</typeparam>
        /// <param name="catalog">The catalog as a list.</param>
        /// <param name="filePath">The full path af the file to write to.</param>
        public static void WriteJson<T>(List<T> catalog, string filePath)
        {
            JsonSerializerOptions opt = new JsonSerializerOptions();
            opt.WriteIndented = true;
            string jsonList = JsonSerializer.Serialize(catalog, opt);
            File.WriteAllText(filePath, jsonList);
        }
    }
}
