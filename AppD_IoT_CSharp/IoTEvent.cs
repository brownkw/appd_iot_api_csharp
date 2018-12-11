using System.Collections.Generic;
using Newtonsoft.Json;
namespace AppDynamics.IoT
{
    /// <summary>
    /// IoT Event Data
    /// </summary>
    public class IoTEvent
    {
        /// <summary>
        /// Gets or sets the timestamp (in milliseconds).
        /// </summary>
        /// <value>The timestamp (in milliseconds).</value>
        [JsonProperty("timestamp")]
        [JsonRequired]
        public long Timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the duration (in milliseconds).
        /// </summary>
        /// <value>The duration (in milliseconds).</value>
        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public long Duration
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the string properties.
        /// </summary>
        /// <value>The string properties.</value>
        [JsonProperty("stringProperties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> StringProperties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the long properties.
        /// </summary>
        /// <value>The long properties.</value>
        [JsonProperty("longProperties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,long> LongProperties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the boolean properties.
        /// </summary>
        /// <value>The boolean properties.</value>
        [JsonProperty("booleanProperties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,bool> BooleanProperties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the double properties.
        /// </summary>
        /// <value>The double properties.</value>
        [JsonProperty("doubleProperties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,double> DoubleProperties
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the datetime properties.
        /// </summary>
        /// <value>The datetime properties.</value>
        [JsonProperty("datetimeProperties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,long> DateTimeProperties
        {
            get;
            set;
        }
    }
}
