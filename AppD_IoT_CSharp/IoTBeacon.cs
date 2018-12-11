using System;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace AppDynamics.IoT
{
    /// <summary>
    /// IoT Beacon.
    /// </summary>

    public class IoTBeacon
    {
        /// <summary>
        /// Gets or sets the device.
        /// </summary>
        /// <value>The device.</value>
        [JsonProperty("deviceInfo")]
        [JsonRequired]
        public DeviceInfo Device
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        [JsonProperty("versionInfo", NullValueHandling = NullValueHandling.Ignore)]
        public VersionInfo Version
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the custom events.
        /// </summary>
        /// <value>The custom events.</value>
        [JsonProperty("customEvents", NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<CustomEvent> CustomEvents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the error events.
        /// </summary>
        /// <value>The error events.</value>
        [JsonProperty("errorEvents", NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<ErrorEvent> ErrorEvents
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the network request events.
        /// </summary>
        /// <value>The network request events.</value>
        [JsonProperty("networkRequestEvents", NullValueHandling = NullValueHandling.Ignore)]
        public ObservableCollection<NetworkRequestEvent> NetworkRequestEvents
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the device info.
        /// </summary>
        /// <param name="info">The <see cref="T:AppDynamics.IoT.DeviceInfo"/> object to add.</param>
        public void SetDeviceInfo(DeviceInfo info)
        {
            Device = info;
        }

        /// <summary>
        /// Sets the version info.
        /// </summary>
        /// <param name="info">The <see cref="T:AppDynamics.IoT.VersionInfo"/> object to add.</param>
        public void SetVersionInfo(VersionInfo info)
        {
            Version = info;
        }

        /// <summary>
        /// Adds a custom event.
        /// </summary>
        /// <param name="evt">The <see cref="T:AppDynamics.IoT.CustomEvent"/> object to add.</param>
        public void AddCustomEvent(CustomEvent evt)
        {
            if (CustomEvents == null) 
            {
                CustomEvents = new ObservableCollection<CustomEvent>();
            }
            CustomEvents.Add(evt);
        }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        /// <returns>The clone.</returns>
        public IoTBeacon Clone()
        {
            return JsonConvert.DeserializeObject<IoTBeacon>(this.ToString());
        }

        /// <summary>
        /// Adds an error event.
        /// </summary>
        /// <param name="evt">The <see cref="T:AppDynamics.IoT.ErrorEvent"/> object to add.</param>
        public void AddErrorEvent(ErrorEvent evt)
        {
            if (ErrorEvents == null)
            {
                ErrorEvents = new ObservableCollection<ErrorEvent>();
            }
            ErrorEvents.Add(evt);
        }

        /// <summary>
        /// Adds the network request event.
        /// </summary>
        /// <param name="evt">The <see cref="T:AppDynamics.IoT.NetworkRequestEvent"/> object to add.</param>
        public void AddNetworkRequestEvent(NetworkRequestEvent evt)
        {
            if (NetworkRequestEvents == null)
            {
                NetworkRequestEvents = new ObservableCollection<NetworkRequestEvent>();
            }
            NetworkRequestEvents.Add(evt);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.IoTBeacon"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:AppDynamics.IoT.IoTBeacon"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #region Static Variables and Methods

        private static string _appKey;
        private static string _endpointUrl;
        private static string _proxyUrl;

        /// <summary>
        /// Sets the app key.
        /// </summary>
        /// <param name="appKey">App key.</param>
        public static void SetAppKey(string appKey) 
        {
            IoTBeacon._appKey = appKey;
        }

        /// <summary>
        /// Sets the endpoint URL.
        /// </summary>
        /// <param name="endpointUrl">Endpoint URL.</param>
        public static void SetEndpointUrl(string endpointUrl) 
        {
            IoTBeacon._endpointUrl = endpointUrl;
        }

        /// <summary>
        /// Sets the proxy. (Used in the test harness for viewing transmitted payloads -- in a production scenario it should not be used)
        /// </summary>
        /// <param name="proxyUrl">Proxy URL.</param>
        public static void SetProxy(string proxyUrl) 
        {
            IoTBeacon._proxyUrl = proxyUrl;
        }

        /// <summary>
        /// Checks to see if the app key is valid and enabled
        /// </summary>
        /// <returns>The response message from the HTTP request.</returns>
        public static HttpResponseMessage IsAppKeyEnabled()
        {
            // Make sure we have an endpoint URL and app key set
            if (String.IsNullOrWhiteSpace(IoTBeacon._endpointUrl))
            {
                throw new Exception("Endpoint URL must be set using IoTBeacon.SetEndpointUrl().");
            }

            if (String.IsNullOrWhiteSpace(IoTBeacon._appKey))
            {
                throw new Exception("App key must be set using IoTBeacon.SetAppKey().");
            }

            HttpClient client = null;
            var content_type = "application/json";

            // VS bypasses system proxy settings in NUnit testing. This code snippet
            // is for debugging purposes only
            if (!String.IsNullOrWhiteSpace(IoTBeacon._proxyUrl))
            {
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(new Uri(IoTBeacon._proxyUrl)),
                    UseProxy = true
                };
                client = new HttpClient(handler);
            }
            else
            {
                client = new HttpClient();
            }

            client.BaseAddress = new Uri(IoTBeacon._endpointUrl);
            string uri = "/eumcollector/iot/v1/application/" + IoTBeacon._appKey + "/enabled";
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(content_type));

            var result = client.GetAsync(uri).Result;
            return result;
        }

        /// <summary>
        /// Validate the specified beacons.
        /// </summary>
        /// <returns>The response message from the HTTP request.</returns>
        /// <param name="beacons">Collection of <see cref="T:AppDynamics.IoT.IoTBeacon"/> objects.</param>
        public static HttpResponseMessage Validate(List<IoTBeacon> beacons)
        {
            // Make sure we have an endpoint URL and app key set
            if (String.IsNullOrWhiteSpace(IoTBeacon._endpointUrl))
            {
                throw new Exception("Endpoint URL must be set using IoTBeacon.SetEndpointUrl.");
            }

            if (String.IsNullOrWhiteSpace(IoTBeacon._appKey))
            {
                throw new Exception("App key must be set using IoTBeacon.SetAppKey().");
            }

            HttpClient client = null;

            // VS bypasses system proxy settings in NUnit testing. This code snippet
            // is for debugging purposes only
            if (!String.IsNullOrWhiteSpace(IoTBeacon._proxyUrl))
            {
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(new Uri(IoTBeacon._proxyUrl)),
                    UseProxy = true
                };
                client = new HttpClient(handler);
            }
            else
            {
                client = new HttpClient();
            }

            client.BaseAddress = new Uri(IoTBeacon._endpointUrl);
            var content_type = "application/json";
            var beacon_str = JsonConvert.SerializeObject(beacons);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/eumcollector/iot/v1/application/" + IoTBeacon._appKey + "/validate-beacons");
            request.Content = new StringContent(beacon_str, Encoding.UTF8, content_type);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(content_type));

            System.Diagnostics.Debug.WriteLine(request.ToString());

            var result = client.SendAsync(request).Result;
            return result;
        }

        /// <summary>
        /// Send the specified beacons.
        /// </summary>
        /// <returns>The response message from the HTTP request.</returns>
        /// <param name="beacons">Collection of <see cref="T:AppDynamics.IoT.IoTBeacon"/> objects.</param>
        public static HttpResponseMessage Send(List<IoTBeacon> beacons)
        {
            // Make sure we have an endpoint URL and app key set
            if (String.IsNullOrWhiteSpace(IoTBeacon._endpointUrl))
            {
                throw new Exception("Endpoint URL must be set using IoTBeacon.SetEndpointUrl.");
            }

            if (String.IsNullOrWhiteSpace(IoTBeacon._appKey))
            {
                throw new Exception("App key must be set using IoTBeacon.SetAppKey().");
            }

            HttpClient client = null;

            // VS bypasses system proxy settings in NUnit testing. This code snippet
            // is for debugging purposes only
            if (!String.IsNullOrWhiteSpace(IoTBeacon._proxyUrl))
            {
                var handler = new HttpClientHandler
                {
                    Proxy = new WebProxy(new Uri(IoTBeacon._proxyUrl)),
                    UseProxy = true
                };
                client = new HttpClient(handler);
            }
            else
            {
                client = new HttpClient();
            }

            client.BaseAddress = new Uri(IoTBeacon._endpointUrl);
            var content_type = "application/json";
            var beacon_str = JsonConvert.SerializeObject(beacons);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/eumcollector/iot/v1/application/" + IoTBeacon._appKey + "/beacons");
            request.Content = new StringContent(beacon_str, Encoding.UTF8, content_type);
            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(content_type));

            System.Diagnostics.Debug.WriteLine(request.ToString());

            var result = client.SendAsync(request).Result;
            return result;
        }


        #endregion

    }
}
