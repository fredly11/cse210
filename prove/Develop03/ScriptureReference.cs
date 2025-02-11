class ScriptureReference
{
    public string Book { get; }
    public int StartChapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public ScriptureReference(string reference)
    {
        string[] parts = reference.Split(' ');

        int index = Array.FindLastIndex(parts, p => p.Contains(":"));

        if (index == -1 || index == 0)
            throw new ArgumentException("Invalid scripture format.");

        Book = string.Join(" ", parts.Take(index));

        string[] verseParts = parts[index].Split('-');

        string[] startParts = verseParts[0].Split(':');
        StartChapter = int.Parse(startParts[0]);
        StartVerse = int.Parse(startParts[1]);

        if (verseParts.Length > 1)
            EndVerse = int.Parse(verseParts[1]);
    }

    public override string ToString()
    {
        return EndVerse.HasValue
            ? $"{Book} {StartChapter}:{StartVerse}-{EndVerse}"
            : $"{Book} {StartChapter}:{StartVerse}";
    }
}

