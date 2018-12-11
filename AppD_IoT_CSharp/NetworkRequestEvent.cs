using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AppDynamics.IoT
{
    /// <summary>
    /// Network event.
    /// </summary>
    public class NetworkRequestEvent : IoTEvent
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("url")]
        [JsonRequired]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>The status code.</value>
        [JsonProperty("statusCode", NullValueHandling = NullValueHandling.Ignore)]
        public int? StatusCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the network error.
        /// </summary>
        /// <value>The network error.</value>
        [JsonProperty("networkError", NullValueHandling = NullValueHandling.Ignore)]
        public string NetworkError
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the length of the request content.
        /// </summary>
        /// <value>The length of the request content.</value>
        [JsonProperty("requestContentLength", NullValueHandling = NullValueHandling.Ignore)]
        public int? RequestContentLength
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the length of the response content.
        /// </summary>
        /// <value>The length of the response content.</value>
        [JsonProperty("responseContentLength", NullValueHandling = NullValueHandling.Ignore)]
        public int? ResponseContentLength
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the response headers.
        /// </summary>
        /// <value>The response headers.</value>
        [JsonProperty("responseHeaders", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,List<string>> ResponseHeaders
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds the response header.
        /// </summary>
        /// <param name="key">Header key.</param>
        /// <param name="vals">List of header values.</param>
        public void AddResponseHeader(string key, List<string> vals)
        {
            if (ResponseHeaders == null)
            {
                ResponseHeaders = new Dictionary<string, List<string>>();
            }

            ResponseHeaders.Add(key, vals);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.NetworkEvent"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.NetworkEvent"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
