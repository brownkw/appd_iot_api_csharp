using Newtonsoft.Json;

namespace AppDynamics.IoT
{
    /// <summary>
    /// Stack frame.
    /// </summary>
    public class StackFrame
    {
        /// <summary>
        /// Gets or sets the name of the symbol.
        /// </summary>
        /// <value>The name of the symbol.</value>
        [JsonProperty("symbolName", NullValueHandling = NullValueHandling.Ignore)]
        public string SymbolName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the package.
        /// </summary>
        /// <value>The name of the package.</value>
        [JsonProperty("packageName", NullValueHandling = NullValueHandling.Ignore)]
        public string PackageName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        [JsonProperty("filePath", NullValueHandling = NullValueHandling.Ignore)]
        public string FilePath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the line number.
        /// </summary>
        /// <value>The line number.</value>
        [JsonProperty("lineNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? LineNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the absolute address.
        /// </summary>
        /// <value>The absolute address.</value>
        [JsonProperty("absoluteAddress", NullValueHandling = NullValueHandling.Ignore)]
        public long? AbsoluteAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image offset.
        /// </summary>
        /// <value>The image offset.</value>
        [JsonProperty("imageOffset", NullValueHandling = NullValueHandling.Ignore)]
        public long? ImageOffset
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the symbol offset.
        /// </summary>
        /// <value>The symbol offset.</value>
        [JsonProperty("symbolOffset", NullValueHandling = NullValueHandling.Ignore)]
        public long? SymbolOffset
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.StackFrame"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.StackFrame"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
