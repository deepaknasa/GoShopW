using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models.Configuration
{
    /// <summary>
    /// Options class which is 1-0-1 mapping with app-settings section.
    /// </summary>
    public class UserInfoOptions
    {
        /// <summary>
        /// JSON section name which contains user info like name and token.
        /// </summary>
        public const string UserInfo = "UserInfo";

        /// <summary>
        /// Name of the user appearing for this test.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Token given to the user to communicate with external endpoints.
        /// </summary>
        public string Token { get; set; }
    }
}
