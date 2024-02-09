using System.Reflection.Metadata;
using System.Text;


var path = Path.Combine(Directory.GetCurrentDirectory(), "test_text.txt");
var text = File.ReadAllText(path, Encoding.UTF8);

var words = text.Split(" ");

Dictionary<string, int> wordsCount = new();
foreach (var word in words)
{
    var cleanWord = new string(word.Select(x => char.ToUpper(x)).
        Where(x => char.IsLetterOrDigit(x)).ToArray());

    if (!string.IsNullOrEmpty(cleanWord))
    {
        if (wordsCount.ContainsKey(cleanWord))
        {
            wordsCount[cleanWord]++;
        }
        else
        {
            wordsCount.Add(cleanWord, 1);
        }
    }
}

wordsCount = wordsCount.OrderByDescending(x => x.Value).ToDictionary<string,int>();

string output = Path.Combine(Directory.GetCurrentDirectory(), "result.txt");
using (StreamWriter writer = new StreamWriter(output, false))
{
    foreach (var pair in wordsCount)
    {
        string resultString = pair.Key + ": " + pair.Value;
        await writer.WriteLineAsync(resultString);
    }
}
