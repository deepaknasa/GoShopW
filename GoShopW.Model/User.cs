using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models
{
    /// <summary>
    /// Class representing User data used to communicate with external endpoints.
    /// </summary>
    public class User
    {
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
