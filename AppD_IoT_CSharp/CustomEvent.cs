using System;
using Newtonsoft.Json;
namespace AppDynamics.IoT
{
    /// <summary>
    /// Custom event.
    /// </summary>
    public class CustomEvent : IoTEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        [JsonProperty("eventType")]
        public string EventType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the event summary.
        /// </summary>
        /// <value>The event summary.</value>
        [JsonProperty("eventSummary")]
        public string EventSummary
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppDynamics.IoT.CustomEvent"/> class.
        /// </summary>
        public CustomEvent() : base()
        {
            EventType = String.Empty;
            EventSummary = String.Empty;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.CustomEvent"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.CustomEvent"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
