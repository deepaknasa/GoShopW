using GoShopW.Contracts;
using GoShopW.Models;
using GoShopW.Models.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoShopW.Services
{
    /// <inheritdoc cref="IUserService"/>
    public class UserService : IUserService
    {
        private readonly UserInfoOptions _options;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IOptions<UserInfoOptions> options,
            ILogger<UserService> logger)
        {
            if (options.Value == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _options = options.Value;
            _logger = logger;
        }

        /// <inheritdoc cref="IUserService.GetUser"/>
        public User GetUser()
        {
            _logger.LogInformation($"Processed {nameof(GetUser)} at {DateTime.UtcNow} UTC time.");

            return new User()
            {
                Name = _options.Name,
                Token = _options.Token
            };
        }
    }
}
