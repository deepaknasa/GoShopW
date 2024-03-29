﻿using GoShopW.Contracts;
using GoShopW.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoShopW.Configuration
{
    /// <summary>
    /// Extension class to add services along with required scopes.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IUserService, UserService>()
                .AddScoped<ISortService, SortService>()
                .AddScoped<ITrolleyService, TrolleyService>()
                .AddSingleton<ITrolleyTotalCalculator, TrolleyTotalCalculator>();
        }
    }
}
