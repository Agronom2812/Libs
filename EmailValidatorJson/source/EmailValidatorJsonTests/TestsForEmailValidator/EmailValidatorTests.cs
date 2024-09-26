using EmailValidatorJson.EmailValidatorJsonCore;
using Xunit;

namespace EmailValidatorJson.EmailValidatorJsonTests.TestsForEmailValidator
{
    public class EmailValidatorTests
    {
        public EmailValidator emailvalidator = new EmailValidator();

        [Fact]
        public void EmailValidator_EmailWithoutAtSymbol_ShouldReturnFalse()
        {
            string invalidEmail = "testexample.com";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWithoutDotSymbol_ShouldReturnFalse()
        {
            string invalidEmail = "test@examplecom";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWithoutTextBeforeAtSymbol_ShouldReturnFalse()
        {
            string invalidEmail = "@example.com";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWithoutTextAfterAtSymbol_ShouldReturnFalse()
        {
            string invalidEmail = "test@.com";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWithoutTextAfterDotSymbol_ShouldReturnFalse()
        {
            string invalidEmail = "test@example.";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWithoutDotSymbolAndTextAfterIt_ShouldReturnFalse()
        {
            string invalidEmail = "test@example";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWhichStartsWithDotSymbol_ShouldReturnTrue()
        {
            string invalidEmail = ".test@example.com";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.True(result);
        }

        [Fact]
        public void EmailValidator_EmailWhichStartsWithAtSymbol_ShouldReturnFalse()
        {
            string invalidEmail = "@test@example.com";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailOnlyWithDotAndAtSymbols_ShouldReturnFalse()
        {
            string invalidEmail = "@.";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWhereAtAndDotAreSwitched_ShouldReturnFalse()
        {
            string invalidEmail = "test.example@com";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_UppercaseEmail_ShouldReturnTrue()
        {
            string validEmail = "TEST@EXAMPLE.COM";
            bool result = emailvalidator.Validation(validEmail);

            Assert.True(result);
        }

        [Fact]
        public void EmailValidator_EmailWhichStartsWithNumber_ShouldReturnTrue()
        {
            string validEmail = "0test@example.com";
            bool result = emailvalidator.Validation(validEmail);

            Assert.True(result);
        }

        [Fact]
        public void EmailValidator_EmailWhichDomainStartsWithNumber_ShouldReturnTrue()
        {
            string validEmail = "test@0example.com";
            bool result = emailvalidator.Validation(validEmail);

            Assert.True(result);
        }

        [Fact]
        public void EmailValidator_EmailWhichLastWordStartsWithNumber_ShouldReturnTrue()
        {
            string validEmail = "test@example.0com";
            bool result = emailvalidator.Validation(validEmail);

            Assert.True(result);
        }

        [Fact]
        public void EmailValidator_ValidEmail_ShouldReturnTrue()
        {
            string validEmail = "test@example.com";
            bool result = emailvalidator.Validation(validEmail);

            Assert.True(result);
        }

        [Fact]
        public void EmailValidator_EmptyEmail_ShouldReturnFalse()
        {
            string invalidEmail = "";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWithSpaceInName_ShouldReturnFalse()
        {
            string invalidEmail = "te st@example.com";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWithSpaceInDomainName_ShouldReturnFalse()
        {
            string invalidEmail = "test@exa mple.com";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }

        [Fact]
        public void EmailValidator_EmailWithSpaceInLastWord_ShouldReturnFalse()
        {
            string invalidEmail = "test@example.co m";
            bool result = emailvalidator.Validation(invalidEmail);

            Assert.False(result);
        }
    } 
}
