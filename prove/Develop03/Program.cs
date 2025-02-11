using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
        
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.Display());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.Display());
        Console.WriteLine("\nAll words are hidden! Program ending.");
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Scripture file not found.");
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 2)
            {
                scriptures.Add(new Scripture(new ScriptureReference(parts[0]), parts[1]));
            }
        }

        return scriptures;
    }
}




