using System;
using Newtonsoft.Json;

namespace AppDynamics.IoT
{
    /// <summary>
    /// Version info.
    /// </summary>
    public class VersionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppDynamics.IoT.VersionInfo"/> class.
        /// </summary>
        public VersionInfo()
        {
            HardwareVersion = String.Empty;
            FirmwareVersion = String.Empty;
            SoftwareVersion = String.Empty;
            OperatingSystemVersion = String.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppDynamics.IoT.VersionInfo"/> class.
        /// </summary>
        /// <param name="hardwareVersion">Hardware version.</param>
        /// <param name="firmwareVersion">Firmware version.</param>
        /// <param name="softwareVersion">Software version.</param>
        /// <param name="operatingSystemVersion">Operating system version.</param>
        [JsonConstructor]
        public VersionInfo(string hardwareVersion, string firmwareVersion, string softwareVersion, string operatingSystemVersion)
        {
            HardwareVersion = hardwareVersion ?? throw new ArgumentNullException(nameof(hardwareVersion));
            FirmwareVersion = firmwareVersion ?? throw new ArgumentNullException(nameof(firmwareVersion));
            SoftwareVersion = softwareVersion ?? throw new ArgumentNullException(nameof(softwareVersion));
            OperatingSystemVersion = operatingSystemVersion ?? throw new ArgumentNullException(nameof(operatingSystemVersion));
        }

        /// <summary>
        /// Gets or sets the hardware version.
        /// </summary>
        /// <value>The hardware version.</value>
        [JsonProperty("hardwareVersion")]
        public string HardwareVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the firmware version.
        /// </summary>
        /// <value>The firmware version.</value>
        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the software version.
        /// </summary>
        /// <value>The software version.</value>
        [JsonProperty("softwareVersion")]
        public string SoftwareVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the operating system version.
        /// </summary>
        /// <value>The operating system version.</value>
        [JsonProperty("operatingSystemVersion")]
        public string OperatingSystemVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.VersionInfo"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.VersionInfo"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
