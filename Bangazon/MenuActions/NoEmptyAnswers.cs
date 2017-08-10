using System;


namespace BangazonCLI
{
    public class NoEmptyAnswers
    {
       
        public static string notAOne(string answer, string thingToEnter){
            string input = answer;
            do {
                Console.WriteLine($"Please enter {thingToEnter}.");
                Console.Write ("> ");
                input = Console.ReadLine();
            } while (input.Length == 0);
            return input;
        }
    }
}