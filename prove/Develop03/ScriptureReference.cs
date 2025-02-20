class ScriptureReference
{
    private string _book { get; }
    private int _startChapter { get; }
    private int _startVerse { get; }
    private int? _endVerse { get; }

    public ScriptureReference(string reference)
    {
        string[] parts = reference.Split(' ');

        int index = Array.FindLastIndex(parts, p => p.Contains(":"));

        if (index == -1 || index == 0)
            throw new ArgumentException("Invalid scripture format.");

        _book = string.Join(" ", parts.Take(index));

        string[] verseParts = parts[index].Split('-');

        string[] startParts = verseParts[0].Split(':');
        _startChapter = int.Parse(startParts[0]);
        _startVerse = int.Parse(startParts[1]);

        if (verseParts.Length > 1)
            _endVerse = int.Parse(verseParts[1]);
    }

    public override string ToString()
    {
        return _endVerse.HasValue
            ? $"{_book} {_startChapter}:{_startVerse}-{_endVerse}"
            : $"{_book} {_startChapter}:{_startVerse}";
    }
}

