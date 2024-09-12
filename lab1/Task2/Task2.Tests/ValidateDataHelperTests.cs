using Microsoft.VisualStudio.TestPlatform.TestHost;
using Task2.Helpers;
using Task2.Models;

namespace Task2.Tests
{
    public class ValidateDataHelperTests
    {
        [Theory]
        [InlineData("John", "john@e.com", "John", "12345")]
        [InlineData("Jane", "jane@e.com", "Jane", "a8o7dfygt")]
        public void ValidateRegisterData_ValidInput_ReturnsTrue(string name, string email, string login, string password)
        {
            // Act
            bool result = ValidateDataHelper.ValidateRegisterData(name, email, login, password, out _);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("", "", "", "")]
        [InlineData(" ", " ", " ", " ")]
        [InlineData(null, null, null, null)]
        public void ValidateRegisterData_EmptyInput_ReturnsFalse(string name, string email, string login, string password)
        {
            // Act
            bool result = ValidateDataHelper.ValidateRegisterData(name, email, login, password, out _);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("8ods7fytgsdo87")]
        public void IsValidPasswordLength_ValidPasswords_ReturnsTrue(string password)
        {
            // Act
            bool result = ValidateDataHelper.IsValidPasswordLength(password);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("1")]
        [InlineData("")]
        public void IsValidPasswordLength_ShortPasswords_ReturnsFalse(string password)
        {
            // Act
            bool result = ValidateDataHelper.IsValidPasswordLength(password);

            // Assert
            Assert.False(result);
        }
    }
}