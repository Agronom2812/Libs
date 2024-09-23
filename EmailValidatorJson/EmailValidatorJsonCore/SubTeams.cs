namespace EmailValidatorJson.EmailValidatorJsonCore
{
    /// <summary>
    /// Represents a subteam within a larger team structure.
    /// </summary>
    class SubTeams
    {
        /// <summary>
        /// Gets or sets the name of the subteam
        /// </summary>
        private string? Team { get; set; }

        /// <summary>
        /// Gets or sets the list of members in the subteam
        /// </summary>
        public List<string?>? Members { get; set; }

    }
}
