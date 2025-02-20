class Scripture
{
    private ScriptureReference _reference { get; }
    private List<Word> _words { get; }

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideWords(int count)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden).ToList();
        
        if (visibleWords.Count == 0) return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            Word wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
            visibleWords.Remove(wordToHide);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    public string Display()
    {
        return $"{_reference}\n{string.Join(" ", _words)}";
    }
}
