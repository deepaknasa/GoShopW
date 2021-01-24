using GoShopW.Models.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace GoShopW.Services.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task UserService_ReturnToken_WhenValidTokenArranged()
        {
            // Arrange
            var logger = Mock.Of<ILogger<UserService>>();

            var userInfoOptionsMock = new Mock<IOptions<UserInfoOptions>>();
            userInfoOptionsMock
                .Setup(u => u.Value)
                .Returns(new UserInfoOptions { Name = "Fake-Name", Token = "Fake-Token" });

            var userService = new UserService(userInfoOptionsMock.Object, logger);

            // Act
            var user = userService.GetUser();

            // Assert
            user.Should().NotBeNull();

            user.Name.Should().BeEquivalentTo("Fake-Name");
            user.Token.Should().BeEquivalentTo("Fake-Token");
        }

        [Fact]
        public async Task UserService_ThrowException_WhenNullTokenOption()
        {
            // Arrange
            var logger = Mock.Of<ILogger<UserService>>();
            var userInfoOptionsMock = new Mock<IOptions<UserInfoOptions>>();
            userInfoOptionsMock.Setup(o => o.Value)
                .Returns((UserInfoOptions)null);

            // Act
            Action act = () => new UserService(userInfoOptionsMock.Object, logger);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
