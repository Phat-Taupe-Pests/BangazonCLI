using System;


namespace BangazonCLI
{
    //Class with a method to check if user input is empty.
    //Written by: Eliza Meeks
    public class NoEmptyAnswers
    {
       // accepts an answer, and a thing to enter to determine if a user answer is an empty string.
        public static string notAOne(string answer, string thingToEnter){
            string input = answer;
            if (input.Length == 0){
                do {
                    Console.WriteLine($"{thingToEnter}.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write ("> ");
                    Console.ResetColor();
                    input = Console.ReadLine();
                } while (input.Length == 0);
            }
            return input;
        }
    }
}