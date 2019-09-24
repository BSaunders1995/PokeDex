using System;

namespace VulpixManager.View
{
    public class ConsoleIO
    {
        public string GetStringInput(string writeOut)
        {
            string input = "";
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine(writeOut);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("We'll need a populated input please");
                }
                else
                {
                    validInput = ValidateInput(input);
                }
            }
            return input;
        }

        public int GetIntegerInput(string writeOut)
        {
            int input = 0;
            bool validInput = false;
            bool validFormat = false;
            while (!validInput)
            {
                Console.WriteLine(writeOut);
                while (!validFormat)
                    try
                    {
                        string readIn = Console.ReadLine();
                        input = Int32.Parse(readIn);
                        validFormat = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("I don't think that was a nmber. Try another one.");
                        validFormat = false;
                    }

                validInput = ValidateInput(input.ToString());
            }
            return input;
        }

        public bool ValidateInput(string input)
        {
            Console.WriteLine("You have chosen " + input + ". Is that correct? (Type y/n)");
            string correct = Console.ReadLine().ToLower();
            if (correct == "y")
            {
                Console.WriteLine("Good choice. Let's move on.");
                return true;
            }
            else
            {
                Console.WriteLine("You're right, we can do better.");
                return false;
            }
        }

    }
}
