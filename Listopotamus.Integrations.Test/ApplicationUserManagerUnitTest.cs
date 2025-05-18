using Listopotamus.Infrastructure.Data.Repositories.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Listopotamus.Integrations.Test
{
    [TestClass]
    public sealed class ApplicationUserManagerIntegrationTest : BaseUnitTest
    {
        private ApplicationUserManager UserManager { get; set; }

        [TestInitialize]
        public new async Task InitializeAsync()
        {
            await base.InitializeAsync();
            this.UserManager = this.ServiceProvider.GetRequiredService<ApplicationUserManager>();

        }

        private static Core.Entities.Identity.User CreateTestUser()
        {
            return new Core.Entities.Identity.User
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                LastName = "User",
                NotificationsEnabled = true,
                UpdatedBy = "system",
                UpdatedDate = DateTime.UtcNow,
                UserObjectId = Guid.NewGuid().ToString(),
                ExternalId = Guid.NewGuid(),
            };
        }

        [TestMethod]
        public async Task CreateUser_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            var roles = new[] { "Admin", "User" };

            // Act
            var result = await this.UserManager.CreateAsync(user, password, roles);

            // Assert
            Assert.IsTrue(result.Succeeded, "Failed to create user.");

            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                var createdUser = await this.UserManager.FindAsync(user.UserName);
                Assert.IsNotNull(createdUser, "User was not found after creation.");
                Assert.AreEqual(user.Email, createdUser.Email, "User email does not match.");
            }
        }

        [TestMethod]
        public async Task UpdateUser_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            var roles = new[] { "Admin" };
            await this.UserManager.CreateAsync(user, password, roles);

            // Act
            user.FirstName = "Updated";
            user.LastName = "User";
            var updatedRoles = new[] { "User" };
            var result = await this.UserManager.UpdateAsync(user, updatedRoles);

            // Assert
            Assert.IsTrue(result.Succeeded, "Failed to update user.");

            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                var updatedUser = await this.UserManager.FindAsync(user.UserName);
                Assert.IsNotNull(updatedUser, "User was not found after update.");
                Assert.AreEqual(user.FirstName, updatedUser.FirstName, "User first name does not match.");
                Assert.AreEqual(user.LastName, updatedUser.LastName, "User last name does not match.");
            }
        }

        [TestMethod]
        public async Task FindUserById_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            var result = await this.UserManager.CreateAsync(user, password, new[] { "User" });

            // Act
            var foundUser = await this.UserManager.FindAsync(user.Id);

            // Assert
            Assert.IsNotNull(foundUser, "User was not found by ID.");
            Assert.AreEqual(user.UserName, foundUser.UserName, "Usernames do not match.");
        }

        [TestMethod]
        public async Task FindUserByExternalId_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            await this.UserManager.CreateAsync(user, password, new[] { "User" });

            // Act
            var foundUser = await this.UserManager.FindAsync(user.ExternalId.Value);

            // Assert
            Assert.IsNotNull(foundUser, "User was not found by external ID.");
            Assert.AreEqual(user.UserName, foundUser.UserName, "Usernames do not match.");
        }

        [TestMethod]
        public async Task ClearUserCache_Succeeds()
        {
            // Arrange
            var user = CreateTestUser();
            var password = "Test@123";
            await this.UserManager.CreateAsync(user, password, new[] { "User" });

            // Act
            await this.UserManager.ClearUserCacheAsync(user.ExternalId.ToString());

            // Assert
            var cachedUser = await this.UserManager.FindUserByObjectIdAsync(user.ExternalId.ToString());
            Assert.IsNull(cachedUser, "User cache was not cleared.");
        }
    }
}
