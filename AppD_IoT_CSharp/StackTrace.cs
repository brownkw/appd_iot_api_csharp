using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AppDynamics.IoT
{
    /// <summary>
    /// Runtime environment
    /// </summary>
    public enum RuntimeEnv 
    {
        /// <summary>
        /// Native runtime environment
        /// </summary>
        native,

        /// <summary>
        /// Java runtime environment
        /// </summary>
        java
    }

    /// <summary>
    /// Stack trace.
    /// </summary>
    public class StackTrace
    {
        /// <summary>
        /// Gets or sets the thread.
        /// </summary>
        /// <value>The thread.</value>
        [JsonProperty("thread", NullValueHandling = NullValueHandling.Ignore)]
        public string Thread
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the runtime.
        /// </summary>
        /// <value>The runtime.</value>
        [JsonProperty("runtime", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public RuntimeEnv? Runtime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the stack frames.
        /// </summary>
        /// <value>The stack frames.</value>
        [JsonProperty("stackFrames", NullValueHandling = NullValueHandling.Ignore)]
        public List<StackFrame> StackFrames
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.StackTrace"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.StackTrace"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
