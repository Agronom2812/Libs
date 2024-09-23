using System.Text.RegularExpressions;

namespace EmailValidatorJson.EmailValidatorJsonCore
{
    /// <summary>
    /// A class for validating emails
    /// </summary>
    public class EmailValidator
    {
        /// <summary>
        /// A regular expression pattern used for validating email addresses.
        /// </summary>
        /// <remarks>
        /// This pattern checks for a basic structure of an email address, ensuring that:
        /// 1. There is at least one character before the '@' symbol.
        /// 2. There is a domain name after the '@' symbol.
        /// 3. The domain name includes a dot ('.') followed by at least one character.
        /// </remarks>
        private string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        /// <summary>
        /// Validates the format of the provided email address.
        /// </summary>
        /// <param name="email">The email adress to validate</param>
        /// <returns>
        /// <c>true</c> if the email address matches the defined pattern; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided email address is null.</exception>
        public bool Validation(string email)
        {
            return Regex.IsMatch(email, pattern);
        }
    }
}
