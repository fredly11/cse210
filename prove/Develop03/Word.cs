class Word
{
    private string _text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        _text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? "_____" : _text;
    }
}