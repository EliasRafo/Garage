using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageSaver
    {
        internal bool Save(Garage<Vehicle> garage)  // Save garage
        {
            string path = Path.Combine(Environment.CurrentDirectory, "garage.json");
            if (!File.Exists(path))
            {
                FileStream createStream = File.Create(path);  // Create file

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var serializedVehicle = JsonSerializer.Serialize(garage, options);  // Serialize Vehicle

                Byte[] title = new UTF8Encoding(true).GetBytes(serializedVehicle);
                createStream.Write(title, 0, title.Length);   // Write to file

                createStream.Close();

                return true;

            }
            else
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var serializedVehicle = JsonSerializer.Serialize<Garage<Vehicle>>(garage, options);

                File.WriteAllText(path, serializedVehicle);
                return true;
            }

            return false;

        }

        internal List<Vehicle>? Load()   // Load garage
        {
            string path = Path.Combine(Environment.CurrentDirectory, "garage.json");

            if (File.Exists(path))   // Checking if file exists
            {
                string text = File.ReadAllText(path);  // Read from file
                
                var x = JsonSerializer.Deserialize<List<Vehicle>>(text);   // Deserialize vehicle

                return x;

            }

            return null;
        }
    }
}
