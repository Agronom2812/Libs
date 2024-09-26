using Xunit;
using EmailValidatorJson.EmailValidatorJsonCore;

namespace EmailValidatorJson.EmailValidatorJsonTests.TestsForPrintEmailList.DomainSort
{
    public class DomainSortTests
    {
        public PrintEmailList sorter = new PrintEmailList();

        [Fact]
        public void DomainSort_AllEmailsAreValidAndUnsortedByDomain_ShouldReturnSortedByDomainList()
        {
            List<string> unsortedEmails = new List<string>
            {
                "z@xample.com",
                "m@example.com",
                "a@zample.com"
            };

            List<string> result = sorter.DomainEmailSort(unsortedEmails);

            List<string> expected = new List<string>
            {
                "m@example.com",
                "z@xample.com",
                "a@zample.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DomainSort_OneEmailIsInvalidAndUnsortedByDomain_ShouldReturnValidEmailsSortedByDomainInvalidEmailInTheEnd()
        {
            List<string> unsortedEmails = new List<string>
            {
                "zxample.com",
                "m@zample.com",
                "a@example.com"
            };

            List<string> result = sorter.DomainEmailSort(unsortedEmails);

            List<string> expected = new List<string>
            {
                "a@example.com",
                "m@zample.com",
                "zxample.com - Invalid email"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DomainSort_TwoOrMoreEmailsAreInvalidAndUnsortedByDomain_ShouldReturnValidEmailsSortedByDomainAndReversedInvalidEmailsWithSuffixes()
        {
            List<string> unsortedEmails = new List<string>
            {
                "zxample.com",
                "@m@example.com",
                "a@zample.com",
                "d@example.com"
            };

            List<string> result = sorter.DomainEmailSort(unsortedEmails);

            List<string> expected = new List<string>
            {
                "d@example.com",
                "a@zample.com",
                "zxample.com - Invalid email",
                "@m@example.com - Invalid email"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DomainSort_EmptyList_ShouldReturnEmptyList()
        {
            List<string> unsortedEmails = new List<string>();

            List<string> result = sorter.DomainEmailSort(unsortedEmails);

            Assert.Empty(result);
        }

        [Fact]
        public void DomainSort_SameDomainsButOneUppercase_ShouldReturnLowercaseFirstThenUppercase()
        {
            List<string> unsortedEmails = new List<string>
            {
                "z@Example.com",
                "a@xample.com",
                "a@example.com"
            };

            List<string> result = sorter.DomainEmailSort(unsortedEmails);
            List<string> expected = new List<string>
            {
                "a@example.com",
                "z@Example.com",
                "a@xample.com"
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DomainSort_SameEmailsButOneHasMoreSymbols_ShouldReturnSortedListMoreSymbolsAfterLessSymbols()
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
    }
}
