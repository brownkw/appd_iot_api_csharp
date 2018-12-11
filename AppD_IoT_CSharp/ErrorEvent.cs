using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace AppDynamics.IoT
{

    /// <summary>
    /// Severity level.
    /// </summary>
    public enum SeverityLevel 
    {
        /// <summary>
        /// Alert severity levek
        /// </summary>
        alert,

        /// <summary>
        /// Critical severity level
        /// </summary>
        critical,

        /// <summary>
        /// Fatal severity level
        /// </summary>
        fatal
    }

    /// <summary>
    /// Error event.
    /// </summary>
    public class ErrorEvent : IoTEvent
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonRequired]
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index of the error stack trace.
        /// </summary>
        /// <value>The index of the error stack trace.</value>
        [JsonProperty("errorStackTraceIndex", NullValueHandling = NullValueHandling.Ignore)]
        public int? ErrorStackTraceIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the severity.
        /// </summary>
        /// <value>The severity.</value>
        [JsonProperty("severity", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SeverityLevel? Severity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the stack traces.
        /// </summary>
        /// <value>The stack traces.</value>
        [JsonProperty("stackTraces", NullValueHandling = NullValueHandling.Ignore)]
        public List<StackTrace> StackTraces
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.ErrorEvent"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.ErrorEvent"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
