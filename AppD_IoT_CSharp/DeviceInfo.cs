using System;
using Newtonsoft.Json;
namespace AppDynamics.IoT
{
    /// <summary>
    /// Device info.
    /// </summary>
    public class DeviceInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppDynamics.IoT.DeviceInfo"/> class.
        /// </summary>
        public DeviceInfo()
        {
            DeviceId = String.Empty;
            DeviceName = String.Empty;
            DeviceType = String.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppDynamics.IoT.DeviceInfo"/> class.
        /// </summary>
        /// <param name="deviceId">Device identifier.</param>
        /// <param name="deviceName">Device name.</param>
        /// <param name="deviceType">Device type.</param>
        [JsonConstructor]
        public DeviceInfo(string deviceId, string deviceName, string deviceType)
        {
            DeviceId = deviceId ?? throw new ArgumentNullException(nameof(deviceId));
            DeviceName = deviceName ?? throw new ArgumentNullException(nameof(deviceName));
            DeviceType = deviceType ?? throw new ArgumentNullException(nameof(deviceType));
        }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        [JsonProperty("deviceId")]
        public string DeviceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        /// <value>The name of the device.</value>
        [JsonProperty("deviceName")]
        public string DeviceName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the device.
        /// </summary>
        /// <value>The type of the device.</value>
        [JsonProperty("deviceType")]
        public string DeviceType
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.DeviceInfo"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.DeviceInfo"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
