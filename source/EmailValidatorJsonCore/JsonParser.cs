using EmailValidatorJson.EmailValidatorJsonCore.Models;
using Newtonsoft.Json;

namespace EmailValidatorJson.EmailValidatorJsonCore
{
    /// <summary>
    /// A class for extracting unique email addresses from a JSON file
    /// </summary>
    public class JsonParser
    {
        /// <summary>
        /// Extracts unique email addresses from a JSON file containing team information.
        /// </summary>
        /// <param name="filePath">The path to the JSON file from which to extract email addresses.</param>
        /// <returns>
        /// A list of unique email addresses extracted from the JSON data. If an error occurs, 
        /// an empty list is returned.
        /// </returns>
        /// <remarks>
        /// This method reads the contents of the specified JSON file and deserializes it into a list
        /// of <see cref="Teams"/> objects. It collects email addresses from both team members and 
        /// subteam members. If the JSON structure is invalid or an error occurs during file reading,
        /// the method handles the exception and outputs an error message.
        /// </remarks>
        /// <exception cref="FileNotFoundException">Thrown if the specified file does not exist.</exception>
        /// <exception cref="JsonException">Thrown if the JSON is invalid or cannot be deserialized.</exception>
        public List<string> ExtractEmails(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);

                var teams = JsonConvert.DeserializeObject<List<Teams>>(json);

                var emails = new List<string>();

                if (teams != null)
                {
                    foreach (var team in teams)
                    {
                        emails.AddRange(team.Members);

                        if (team.Subteams != null)
                        {
                            foreach (var subteam in team.Subteams)
                            {
                                emails.AddRange(subteam.Members);
                            }
                        }
                    }
                }
                List<string> uniqueEmails = emails.Distinct().ToList();
                return uniqueEmails;
            }
            catch
            {
                throw new JsonReaderException();
            }
        }
    }
}
