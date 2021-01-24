using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models.Configuration
{
    /// <summary>
    /// Options class which is 1-0-1 mapping with app-settings section.
    /// </summary>
    public class ExternalEndpointOptions
    {
        /// <summary>
        /// JSON section name which contains base url for external endpoints.
        /// </summary>
        public const string ExternalEndpoint = "ExternalEndpoint";

        /// <summary>
        /// Base url of external endpoints.
        /// </summary>
        public string BaseUrl { get; set; }
    }
}
