using System;
using System.IO;

public class Porgram
{
    public static void Main()
    {
        string path = "text.txt";
        Viselitsa playGame = new Viselitsa();
        playGame.MainMenu(path);
    }
}