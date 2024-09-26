using Xunit;
using EmailValidatorJson.EmailValidatorJsonCore;
using Newtonsoft.Json;

namespace EmailValidatorJson.EmailValidatorJsonTests.TestsForJsonParser
{
    public class JsonParserTests
    {
        public JsonParser jsonparser = new JsonParser();

        [Fact]
        public void JsonParser_WithSameEmailsInDifferentSubteams_ShouldReturnListOfMembers()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/SameEmails/JsonWithSameEmailsInDiffSubteams.json");

            List<string> result = jsonparser.ExtractEmails(filePath);

            List<string> expected = new List<string>
            {
                "a@mail.com",
                "b@yahoo.com",
                "a@gmail.com",
                "b@gmail.com",
                "c@gmail.com",
                "d@mail.com",
                "f@yahoo.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void JsonParser_WithSameEmailsInDifferentTeams_ShouldReturnListOfMembers()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/SameEmails/JsonWithSameEmailsInDiffTeams.json");

            List<string> result = jsonparser.ExtractEmails(filePath);

            List<string> expected = new List<string>
            {
                "a@mail.com",
                "b@yahoo.com",
                "a@gmail.com",
                "b@gmail.com",
                "d@mail.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void JsonParser_WithSameEmailsInOneSubteam_ShouldReturnListOfMembers()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/SameEmails/JsonWithSameEmailsInOneSubteam.json");

            List<string> result = jsonparser.ExtractEmails(filePath);

            List<string> expected = new List<string>
            {
                "a@mail.com",
                "b@yahoo.com",
                "a@gmail.com",
                "c@gmail.com",
                "d@mail.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void JsonParser_WithSameEmailsInOneTeam_ShouldReturnListOfMembers()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/SameEmails/JsonWithSameEmailsInOneTeam.json");

            List<string> result = jsonparser.ExtractEmails(filePath);

            List<string> expected = new List<string>
            {
                "a@mail.com",
                "a@gmail.com",
                "b@gmail.com",
                "c@gmail.com",
                "d@mail.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void JsonParser_WithSameEmailsInTeamAndSubteam_ShouldReturnListOfMembers()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/SameEmails/JsonWithSameEmailsInTeamAndSubteam.json");

            List<string> result = jsonparser.ExtractEmails(filePath);

            List<string> expected = new List<string>
            {
                "a@mail.com",
                "b@yahoo.com",
                "b@gmail.com",
                "c@gmail.com",
                "d@mail.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void JsonParser_EmptyJson_ShouldThrowJsonReaderException()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/JsonWrongStructure/JsonWithSyntaxError.json");

            Assert.Throws<JsonReaderException>(() =>
            {
                jsonparser.ExtractEmails(filePath);
            });
        }

        [Fact]
        public void JsonParser_WithEmptySubteam_ShouldThrowJsonReaderException()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/JsonWrongStructure/JsonWithSyntaxError.json");

            Assert.Throws<JsonReaderException>(() =>
            {
                jsonparser.ExtractEmails(filePath);
            });
        }

        [Fact]
        public void JsonParser_WithEmptyTeam_ShouldThrowJsonReaderException()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/JsonWrongStructure/JsonWithSyntaxError.json");

            Assert.Throws<JsonReaderException>(() =>
            {
                jsonparser.ExtractEmails(filePath);
            });
        }

        [Fact]
        public void JsonParser_WithSyntaxError_ShouldThrowJsonReaderException()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "EmailValidatorJsonTests/TestsForJsonParser/JsonTestFiles/JsonWrongStructure/JsonWithSyntaxError.json");

            Assert.Throws<JsonReaderException>(() =>
            {
                jsonparser.ExtractEmails(filePath);
            });
        }
    }
}
