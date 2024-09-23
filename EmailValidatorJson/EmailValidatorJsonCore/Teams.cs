namespace EmailValidatorJson.EmailValidatorJsonCore
{
    /// <summary>
    /// Represents a team that contains members and subteams.
    /// </summary>
    class Teams
    {
        /// <summary>
        /// Gets or sets the name of the team
        /// </summary>
        private string? Team { get; set; }

        /// <summary>
        /// Gets or sets the list of members in the team
        /// </summary>
        public List<string?>? Members { get; set; }

        /// <summary>
        /// Gets or sets the list of subteams associated with this team
        /// </summary>
        public List<SubTeams?>? Subteams { get; set; }
    }
}
