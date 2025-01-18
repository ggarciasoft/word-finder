using WordFinderProject;

namespace Tests
{
    public class WordFinderTests
    {
        [Fact]
        public void Find_HorizontalWords_ReturnsCorrectResults()
        {
            // Arrange
            var matrix = new[]
            {
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvdogbnmqwert",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = new[] { "dog", "cat", "bird" };

            // Act
            var result = wordFinder.Find(wordstream).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("dog", result[0]);
        }

        [Fact]
        public void Find_VerticalWords_ReturnsCorrectResults()
        {
            // Arrange
            var matrix = new[]
            {
                "zxcvbnmasdfghjk",
                "qwdrtyuiopasdfg",
                "zxovbnmasdfghjk",
                "qwgrtyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = new[] { "dog", "cat", "bird" };

            // Act
            var result = wordFinder.Find(wordstream).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("dog", result[0]);
        }

        [Fact]
        public void Find_MultipleOccurrences_ReturnsOrderedByFrequency()
        {
            // Arrange
            var matrix = new[]
            {
                "zxcvdogasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbirdnmqwera",
                "qwertyuiopasdfg",
                "zxcvdogasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbirdnmqwera",
                "qwertyuiopasdfg",
                "zxcvdogasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = new[] { "dog", "bird", "cat" };

            // Act
            var result = wordFinder.Find(wordstream).ToList();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("dog", result[0]); // appears 3 times
            Assert.Equal("bird", result[1]); // appears 2 times
        }

        [Fact]
        public void Find_DuplicateWordsInStream_CountsOnlyOnce()
        {
            // Arrange
            var matrix = new[]
            {
                "zxcvdogasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvdogasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = new[] { "dog", "dog", "dog" }; // Duplicate words in stream

            // Act
            var result = wordFinder.Find(wordstream).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("dog", result[0]);
        }

        [Fact]
        public void Find_MoreThanTenWords_ReturnsTopTen()
        {
            // Arrange
            var matrix = new[]
            {
                "dogbirdcatqwert",
                "fishbearwolfxcv",
                "frogducklionbnm",
                "tigerratowlasdf",
                "dogbirdcatqwert",
                "fishbearwolfxcv",
                "frogducklionbnm",
                "tigerratowlasdf",
                "dogbirdcatqwert",
                "fishbearwolfxcv",
                "frogducklionbnm",
                "tigerratowlasdf",
                "dogbirdcatqwert",
                "fishbearwolfxcv",
                "frogducklionbnm"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = new[] 
            { 
                "dog", "bird", "cat", "fish", "bear", 
                "wolf", "frog", "duck", "lion", "rat",
                "tiger", "owl" // 12 words total
            };

            // Act
            var result = wordFinder.Find(wordstream).ToList();

            // Assert
            Assert.Equal(10, result.Count);
        }

        [Fact]
        public void Find_EmptyWordStream_ReturnsEmptyResult()
        {
            // Arrange
            var matrix = new[]
            {
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk",
                "qwertyuiopasdfg",
                "zxcvbnmasdfghjk"
            };
            var wordFinder = new WordFinder(matrix);
            var wordstream = Array.Empty<string>();

            // Act
            var result = wordFinder.Find(wordstream).ToList();

            // Assert
            Assert.Empty(result);
        }
    }
}