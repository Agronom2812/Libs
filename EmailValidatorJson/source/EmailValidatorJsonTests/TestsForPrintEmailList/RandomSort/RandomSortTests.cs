using Xunit;
using EmailValidatorJson.EmailValidatorJsonCore;

namespace EmailValidatorJson.EmailValidatorJsonTests.TestsForPrintEmailList.RandomSort
{
    public class RandomSortTests
    {
        public PrintEmailList sorter = new PrintEmailList();

        [Fact]
        public void RandomSort_InputIsNotEmpty_ShouldReturnTheExactAmountOfElementsInInput()
        {
            List<string> input = new List<string>
            {
                "a@example.com",
                "b@example.com",
                "c@example.com"
            };
            List<string> result = sorter.RandomEmailSort(input);

            Assert.Equal(input.Count, result.Count);
        }

        [Fact]
        public void RandomSort_InvalidEmail_ShouldReturnInvalidEmailWithSuffix()
        {
            List<string> input = new List<string>
            {
                "aexample.com"
            };
            List<string> result = sorter.RandomEmailSort(input);

            List<string> expected = new List<string>
            {
                "aexample.com - Invalid email"
            };

            Assert.Equal(result, expected);
        }

        [Fact]
        public void RandomSort_EmptyInput_ShouldreturnEmptyList()
        {
            List<string> input = new List<string>();

            List<string> result = sorter.RandomEmailSort(input);

            Assert.Empty(result);
        }

        /// <summary>
        /// This test case checks are there any differences after using method for 5 times
        /// </summary>
        [Fact]
        public void RandomSort_RandomCheckFor5Times_ShouldReturnNotTheSameValues()
        {
            List<List<string>> input = new List<List<string>>();
            input.Add(new List<string> { "a@example.com", "b@example.com", "c@example.com" });
            input.Add(new List<string> { "a@example.com", "b@example.com", "c@example.com" });
            input.Add(new List<string> { "a@example.com", "b@example.com", "c@example.com" });
            input.Add(new List<string> { "a@example.com", "b@example.com", "c@example.com" });
            input.Add(new List<string> { "a@example.com", "b@example.com", "c@example.com" });

            List<List<string>> result = new List<List<string>>();

            foreach(List<string> inp in input)
            {
                List<string> newList = sorter.RandomEmailSort(inp);
                result.Add(newList);
            }

            Assert.False(input.SequenceEqual(result));
        }
    }
}
