using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SkiAPIs.Data;

namespace SkiAPIs.Formats
{
    public abstract partial class Interpreter
    {
        public JsonDocument? currentDocument { get; private set; }

        public Interpreter Parse(string json)
        {
            currentDocument= JsonDocument.Parse(json);
            OnParse();
            return this;
        }

        public async Task<Mountain[]> GetMountainsAsync()
        {
            var result = await Task.FromResult(GetMountains());
            return result;
        }

        public async Task<Lift[]> GetLiftsAsync ()
        {
            var result = await Task.FromResult(GetLifts());
            return result;
        }

        public async Task<Trail[]> GetTrailsAsync()
        {
            var result = await Task.FromResult(GetTrails());
            return result;
        }

        /// <summary>
        /// Custom behavior during Parsing, can be overridden
        /// </summary>
        public virtual void OnParse() { }
        public abstract Mountain[] GetMountains();
        public abstract Lift[] GetLifts();
        public abstract Trail[] GetTrails();

        public abstract Dictionary<string, string> GetTypeIdentifiers(SkiObjectType type);
    }
}
