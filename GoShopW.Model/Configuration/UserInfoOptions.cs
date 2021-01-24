using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Models.Configuration
{
    public class UserInfoOptions
    {
        public const string UserInfo = "UserInfo";

        public string Name { get; set; }
        public string Token { get; set; }
    }
}
