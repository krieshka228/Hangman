public class Viselitsa
{
    public  string GetWord(string[] words)
    {
        string word = words[Random.Shared.Next(0,words.Length)];
        return word;
    }
    public  void MainMenu(string path)
    {
        string choice = "";
        while(choice != "2")
        {
            Console.WriteLine("=== ВИСЕЛИЦА ===");
            Console.WriteLine("1. Играть");
            Console.WriteLine("2. Выйти");
            choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    Game(path);
                    break;
                case "2":
                    break;
            }
        }

    }
    public  void Game(string path)
    {   string text = File.ReadAllText(path);
        string[] words = text.Split(',', StringSplitOptions.RemoveEmptyEntries);
        string word = GetWord(words);
        int errors = 0;
        char[] s = new string('_',word.Length).ToCharArray();
        bool win = false;
        string s1 = "";
        int count = 0;
        HashSet<char> chars1 = new HashSet<char>{};
        HashSet<char> chars = new HashSet<char>{};
        for(int i = 0; i < word.Length; i++)
        {
            chars.Add(word[i]);
        }
        while(errors < 6 && !win)
        {
            Console.Clear();
            Console.WriteLine("=== ИГРА НАЧАЛАСЬ ===");
            DrawHagman(errors);
            Console.WriteLine("\n\n");
            Console.WriteLine(new string(s));
            s1 = Console.ReadLine();
            char x = ' ';
            if(s1.Length == 1 && !char.IsDigit(s1[0])) x = s1[0];
            if(chars.Contains(x) && x != ' ')
            {
                for(int i = 0; i < word.Length; i++)
                {
                    if(x == word[i])
                    {
                        s[i] = x;
                    }
                }
            }
            else if(!chars1.Contains(x) && x != ' ')
            {
                chars1.Add(x);
                errors++;   
            }
            if(new string(s) == word) win = true;
            count++;
        }
        if(errors < 6)
        {
            int claim = 6 - errors;
            Console.WriteLine($"Поздравляю!Вы выйграли и получили {claim} очков");
        }
        else
        {
            Console.WriteLine("Вы проиграли");
        }
        return;


    }
    public void DrawHagman(int errors)
    {
        Console.WriteLine(" +--+");
        Console.WriteLine(" |  |");
        Console.WriteLine(errors > 0? " 0  |":"    |");
        if(errors == 2) Console.WriteLine(" |");
        else if(errors == 3)Console.WriteLine("/|");
        else if(errors >= 4)Console.WriteLine(@"/|\");
        if(errors == 5)Console.WriteLine(@"/");
        else if(errors == 6)Console.WriteLine(@"/\");
    }
}