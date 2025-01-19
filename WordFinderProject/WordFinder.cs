namespace WordFinderProject
{
    public class WordFinder
{
    private readonly string[] _matrixColumns;
    private readonly string[] _matrixRows;
    private readonly int _rows;
    private readonly int _cols;

    public WordFinder(IEnumerable<string> matrix)
    {
        var matrixList = matrix.ToList();
        _rows = matrixList.Count;
        _cols = matrixList[0].Length;
        _matrixColumns = new string[_cols];
        _matrixRows = matrix.ToArray();
        for (int i = 0; i < _cols; i++)
        {
            _matrixColumns[i] = new string(Enumerable.Range(0, _rows)
                .Select(j => matrixList[j][i])
                .ToArray());
        }

    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        //Dictionary to store the number of times each word appears
        var wordCounts = new Dictionary<string, int>();

        //Get the unique words in the wordstream
        var uniqueWords = wordstream.Distinct();

        //For each unique word in the wordstream
        foreach (var word in uniqueWords)
        {
            int count = 0;
            // Search horizontally
            for (int i = 0; i < _rows; i++)
            {
                //Count the number of times the word appears in the row
                count += CountOccurrences(_matrixRows[i], word);
            }

            // Search vertically
            for (int j = 0; j < _cols; j++)
            {
                //Count the number of times the word appears in the column
                count += CountOccurrences(_matrixColumns[j], word);
            }

            //If the word appears more than 0 times, add it to the dictionary
            if (count > 0)
            {
                wordCounts[word] = count;
            }
        }

        // Return top 10 most repeated words
        return wordCounts
            .OrderByDescending(x => x.Value)
            .Take(10)
            .Select(x => x.Key);
    }

    private static int CountOccurrences(string source, string word)
    {
        int count = 0;
        int index = 0;
        //Count the number of times the word appears in the source string
        while ((index = source.IndexOf(word, index, StringComparison.Ordinal)) != -1)
        {
            count++;
            index++;
        }
        return count;
    }
}
}
