using Xunit;
using EmailValidatorJson.EmailValidatorJsonCore;
using System.Globalization;

namespace EmailValidatorJson.EmailValidatorJsonTests.TestsForPrintEmailList.AlphabetSort
{
    public class AlphabetSortTests
    {
        public PrintEmailList sorter = new PrintEmailList();

        [Fact]
        public void AlphabetSort_AllEmailsAreFullValid_ShouldReturnSortedList()
        {
            List<string> unsortedEmails = new List<string>
            {
                "z@example.com",
                "a@example.com",
                "m@example.com"
            };

            List<string> result = sorter.AlphabetEmailSort(unsortedEmails);
            List<string> expected = new List<string>
            {
                "a@example.com",
                "m@example.com",
                "z@example.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetSort_OneEmailIsInvalid_ShouldReturnSortedValidEmailsAndInvalidWithSuffix()
        {
            List<string> unsortedEmails = new List<string>
            {
                "zexample.com",
                "a@example.com",
                "m@example.com"
            };

            List<string> result = sorter.AlphabetEmailSort(unsortedEmails);
            List<string> expected = new List<string>
            {
                "a@example.com",
                "m@example.com",
                "zexample.com - Invalid email"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetSort_TwoOrMoreEmailsAreInvalid_ShouldReturnSortedValidEmailsAndReversedUnsortedInvalidEmailsWithSuffix()
        {
            List<string> unsortedEmails = new List<string>
            {
                "zexample.com",
                "a@example.com",
                "m@example.com",
                "@pr@example.com"
            };

            List<string> result = sorter.AlphabetEmailSort(unsortedEmails);
            List<string> expected = new List<string>
            {
                "a@example.com",
                "m@example.com",
                "@pr@example.com - Invalid email",
                "zexample.com - Invalid email"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetSort_EmptyList_ShouldReturnEmptyList()
        {
            List<string> unsortedEmails = new List<string>();

            List<string> result = sorter.AlphabetEmailSort(unsortedEmails);

            Assert.Empty(result);
        }

        [Fact]
        public void AlphabetSort_SameNameDifferentDomain_ShouldReturnSortedList()
        {
            List<string> unsortedEmails = new List<string>
            {
                "m@example.com",
                "a@xample.com",
                "a@example.com"
            };

            List<string> result = sorter.AlphabetEmailSort(unsortedEmails);
            List<string> expected = new List<string>
            {
                "a@example.com",
                "a@xample.com",
                "m@example.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetSort_SameNameAndDomainDifferentLastWord_ShouldReturnSortedList()
        {
            List<string> unsortedEmails = new List<string>
            {
                "z@example.com",
                "a@example.om",
                "a@example.com"
            };

            List<string> result = sorter.AlphabetEmailSort(unsortedEmails);
            List<string> expected = new List<string>
            {
                "a@example.com",
                "a@example.om",
                "z@example.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetSort_SameEmailsButOneHasMoreSymbols_ShouldReturnSortedListMoreSymbolsAfterLessSymbols()
        {
            List<string> unsortedEmails = new List<string>
            {
                "z@example.com",
                "a@example.coma",
                "a@example.com"
            };

            List<string> result = sorter.AlphabetEmailSort(unsortedEmails);
            List<string> expected = new List<string>
            {
                "a@example.com",
                "a@example.coma",
                "z@example.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AlphabetSort_SameEmailsButOneUppercase_ShouldReturnLowercaseFirstThenUppercase()
        {
            List<string> unsortedEmails = new List<string>
            {
                "z@example.com",
                "A@example.com",
                "a@example.com"
            };

            List<string> result = sorter.AlphabetEmailSort(unsortedEmails);
            List<string> expected = new List<string>
            {
                "a@example.com",
                "A@example.com",
                "z@example.com"
            };

            Assert.Equal(expected, result);
        }
    }
}
