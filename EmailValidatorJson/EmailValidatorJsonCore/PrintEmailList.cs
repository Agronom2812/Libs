namespace EmailValidatorJson.EmailValidatorJsonCore
{
    /// <summary>
    /// A class for outputting a list of emails
    /// </summary>
    public class PrintEmailList
    {
        /// <summary>
        /// An instance of the <see cref="EmailValidator"/> class used for validating email addresses.
        /// </summary>
        private EmailValidator validator = new EmailValidator();

        /// <summary>
        /// An instance of the <see cref="Random"/> class used for generating random numbers.
        /// </summary>
        private Random rng = new Random();

        /// <summary>
        /// Sorts a list of email addresses based on their validity and outputs the sorted list.
        /// </summary>
        /// <param name="emails">The list of emails to sort</param>
        /// <remarks>
        /// The method uses an instance of <see cref="EmailValidator"/> to determine if each email is valid.
        /// Valid emails are prioritized in the sorted output. Invalid emails are appended with a message
        /// indicating their invalidity.
        /// The sorting of valid emails is randomized using an instance of <see cref="Random"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if the provided list of email address is null.</exception>
        public void RandomEmailSort(List<string> emails)
        {
            var sortedEmails = emails
            .Select(email => new
            {
                Email = email,
                IsValid = validator.Validation(email)
            })
            .OrderBy(x => x.IsValid ? 0 : 1)
            .ThenBy(x => x.IsValid ? rng.Next() : 0)
            .Select(x => x.IsValid ? x.Email : x.Email + " - Invalid email")
            .ToList();

            foreach (var email in sortedEmails)
            {
                    Console.WriteLine(email);
            }
        }

        /// <summary>
        /// Sorts a list of email addresses based on their validity and outputs the sorted list.
        /// </summary>
        /// <param name="emails">The list of emails to sort</param>
        /// <remarks>
        /// The method uses an instance of <see cref="EmailValidator"/> to determine if each email is valid.
        /// Valid emails are prioritized in the sorted output. Invalid emails are appended with a message indicating their invalidity.
        /// Valid emails are sorted in lexicographic order.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if the provided list of email address is null.</exception>
        public void AlphabetEmailSort(List<string> emails)
        {
            var sortedEmails = emails
            .Select(email => new
             {
                 Email = email,
                 IsValid = validator.Validation(email)
             })
            .OrderBy(x => x.IsValid ? 0 : 1)
            .ThenBy(x => x.Email)
            .Select(x => x.IsValid ? x.Email : x.Email + " - Invalid email")
            .ToList();

            foreach (var email in sortedEmails)
            {
                Console.WriteLine(email);
            }
        }

        /// <summary>
        /// Sorts a list of email addresses based on their validity and outputs the sorted list.
        /// </summary>
        /// <param name="emails">The list of emails to sort</param>
        /// <remarks>
        /// The method uses an instance of <see cref="EmailValidator"/> to determine if each email is valid.
        /// Valid emails are prioritized in the sorted output. Invalid emails are appended with a message indicating their invalidity.
        /// Valid emails are sorted in lexicographic order of their domains.
        /// </remarks>
        /// /// <exception cref="ArgumentNullException">Thrown if the provided list of email address is null.</exception>
        public void DomainEmailSort(List<string> emails)
        {
            var sortedEmails = emails
            .Select(email => new
            {
                Email = email,
                IsValid = validator.Validation(email),
                Domain = validator.Validation(email) ? email.Substring(email.IndexOf('@') + 1) : null
            })
            .OrderBy(x => x.IsValid ? 0 : 1)
            .ThenBy(x => x.Domain ?? string.Empty)
            .Select(x => x.IsValid ? x.Email : x.Email + " - Invalid email")
            .ToList();

            foreach (var email in sortedEmails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
