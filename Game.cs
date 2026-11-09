public class Game
{
    private const string PATH = "Words.txt";
    private string GetWord()
    {
        string text = File.ReadAllText(PATH);
        string[] words = text.Split(',', StringSplitOptions.RemoveEmptyEntries);
        string word = words[Random.Shared.Next(0,words.Length)];

        return word;
    }
    public void MainMenu()
    {
        const string CHOICE_TEXT = "=== ВИСЕЛИЦА ===\n1. Играть\n2. Выйти";
        const string START_GAME = "1";
        const string QUIT_GAME = "2";

        string choice = "";

        while(choice != "2")
        {
            Console.WriteLine(CHOICE_TEXT);

            choice = Console.ReadLine();
            switch(choice)
            {
                case START_GAME:
                    PlayGame();
                    break;

                case QUIT_GAME:
                    break;
            }
        }

    }
    private void PlayGame()
    {   
        const string START_GAME = "=== ИГРА НАЧАЛАСЬ ===";
        const string CONGRATULATIONS = "Поздравляю! ";
        const string YOU_LOOSE = "Вы проиграли!";
        string word = GetWord();
        int errors = 0;
        char[] wordGuess = new string('_',word.Length).ToCharArray();
        bool win = false;
        string inputLetter = "";
        int count = 0;

        HashSet<char> incorrectLetters = new HashSet<char>{};
        HashSet<char> lettersFromWord = new HashSet<char>{};

        for(int i = 0; i < word.Length; i++)
        {
            lettersFromWord.Add(word[i]);
        }

        while(errors < 6 && !win)
        {
            Console.Clear();
            Console.WriteLine(START_GAME);

            DrawHagman(errors);

            Console.WriteLine("\n\n");
            Console.WriteLine(new string(wordGuess));
            
            inputLetter = Console.ReadLine();
            char letter = ' ';
            if(inputLetter.Length == 1 && !char.IsDigit(inputLetter[0])) letter = inputLetter[0];

            if(lettersFromWord.Contains(letter) && letter != ' ')
            {
                for(int i = 0; i < word.Length; i++)
                {
                    if(letter == word[i])
                    {
                        wordGuess[i] = letter;
                    }
                }
            }
            else if(!incorrectLetters.Contains(letter) && letter != ' ')
            {
                incorrectLetters.Add(letter);
                errors++;   
            }

            if(new string(wordGuess) == word) win = true;
            count++;
        }

        if(errors < 6)
        {
            Console.Clear();
            int claim = 6 - errors;
            Console.Write(CONGRATULATIONS);
            Console.WriteLine($"Вы отгадали слово \"{word}\" и получили {claim} очков");
        }
        else
        {
            Console.Clear();
            Console.Write(YOU_LOOSE);
            Console.WriteLine($" Слово \"{word}\".");
        }

        return;

    }

    private void DrawHagman(int errors)
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