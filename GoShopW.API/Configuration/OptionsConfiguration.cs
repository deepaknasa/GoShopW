using GoShopW.Contracts;
using GoShopW.Models.Configuration;
using GoShopW.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoShopW.Configuration
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration Configuration)
        {
            return services
                .Configure<UserInfoOptions>(Configuration.GetSection(UserInfoOptions.UserInfo));
        }
    }
}
