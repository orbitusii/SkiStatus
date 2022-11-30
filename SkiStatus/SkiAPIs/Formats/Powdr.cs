using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SkiAPIs.Data;

namespace SkiAPIs.Formats
{
    public class Powdr : Interpreter
    {
        private JsonElement[] deserialized = Array.Empty<JsonElement>();
        private Mountain[] mountains = Array.Empty<Mountain>();

        public override void OnParse()
        {
            deserialized = currentDocument?.Deserialize<JsonElement[]>() ?? Array.Empty<JsonElement>();

            List<string> sectors = new List<string>();

            foreach(JsonElement element in deserialized)
            {
                if(element.TryGetProperty("sector", out JsonElement value))
                {
                    string valString = value.GetString() ?? string.Empty;

                    if (sectors.Contains(valString) || valString == string.Empty) continue;

                    sectors.Add(valString);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public override Mountain[] GetMountains()
        {
            return mountains;
        }

        public override Lift[] GetLifts()
        {
            return Array.Empty<Lift>();
        }

        public override Trail[] GetTrails()
        {
            return Array.Empty<Trail>();
        }

        public override Dictionary<string, string> GetTypeIdentifiers(SkiObjectType type)
        {
            return type switch
            {
                SkiObjectType.Trail => new Dictionary<string, string> { { "type", "trail" } },
                SkiObjectType.Lift => new Dictionary<string, string> { { "type", "lift" } },
                _ => throw new NotSupportedException($"Powdr interpreter has no identifiers for type {type}")
            };
        }
    }
}
