using System;
namespace AppDynamics.IoT
{
    public class WebProxy : System.Net.IWebProxy
    {
        /// <summary>
        /// Gets or sets the credentials.
        /// </summary>
        /// <value>The credentials.</value>
        public System.Net.ICredentials Credentials
        {
            get;
            set;
        }

        private readonly Uri _proxyUri;        

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppDynamics.IoT.WebProxy"/> class.
        /// </summary>
        /// <param name="proxyUri">Proxy URI.</param>
        public WebProxy(Uri proxyUri)
        {
            _proxyUri = proxyUri;
        }

        /// <summary>
        /// Gets the proxy.
        /// </summary>
        /// <returns>The proxy.</returns>
        /// <param name="destination">Destination.</param>
        public Uri GetProxy(Uri destination)
        {
            return _proxyUri;
        }

        /// <summary>
        /// Is the proxy bypassed.
        /// </summary>
        /// <returns><c>true</c>, if proxy is bypassed, <c>false</c> otherwise.</returns>
        /// <param name="host">Host.</param>
        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
