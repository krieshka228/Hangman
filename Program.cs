using System;
using System.IO;

public class Porgram
{
    public static void Main()
    {
        string path = "text.txt";
        Game playGame = new Game();
        playGame.MainMenu(path);
    }
}