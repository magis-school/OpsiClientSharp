using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace MagisIT.OpsiClient
{
    public class RequestFilter
    {
        private readonly Dictionary<string, string> _filterDictionary = new Dictionary<string, string>();

        /// <summary>
        ///     Adds a key value pair to the filter
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public RequestFilter Add(string key, string value)
        {
            _filterDictionary.Add(key, value);
            return this;
        }

        /// <summary>
        ///     Does the filter contain any elements?
        /// </summary>
        /// <returns></returns>
        public bool HasElements() => _filterDictionary.Any();

        /// <summary>
        ///     Returns the json of the current filter
        /// </summary>
        /// <returns></returns>
        public JObject ToJson() => JObject.FromObject(_filterDictionary);
    }
}
