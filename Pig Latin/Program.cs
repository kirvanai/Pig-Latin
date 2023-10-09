namespace Pig_Latin_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Pig Latin Translator");
            bool goOn = true;
            while (goOn == true)
            {
            Console.WriteLine("Enter a line to be translated:");
            string input = Console.ReadLine();
            string[] inputs = input.Split(" ");
            for (int i = 0; i < inputs.Length; i++)
                {
                    string output = PigLatin(inputs[i]);
                    Console.Write($"{output} ");
                }

            goOn = AskToContinue();
            }
        }

        public static string PigLatin(string input)
        {
            
            input = input.ToLower();
            
            if (input == "")
            {
                return "Please enter text.";
            }

            else if (CheckingForSpecialChar(input) == true)
            {
                return input;
            }
            
            else if (hasVowel(input) == false)
            {
                return $"{input} cannot be translated into Pig Latin.";
            }

            else if(findFirstVowelIndex(input) == 0)
            {
                string output = input + "way";
                return output;
            }
            else 
            {
            string partOne = input.Substring(findFirstVowelIndex(input));
            string partTwo = input.Substring(0, findFirstVowelIndex(input)) + "ay";
            string output = partOne + partTwo;
            return output;
            }

        }

        public static int findFirstVowelIndex(string s)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            if (hasVowel(s))
            {
                char[] letters = s.ToLower().ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    char c = letters[i];
                    if (vowels.Contains(c))
                    {
                        return i;
                    }
                }
                return -1;
            }
            else
            {
                return -1;
            }
        }

        public static bool hasVowel(string s)
        {
            s = s.ToLower();
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char vowel in vowels)
            {
                if (s.Contains(vowel))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool AskToContinue()
        {
            Console.WriteLine("Translate more? y/n");
            string input = Console.ReadLine();

            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Hey I didn't understand your response");
                return AskToContinue();
            }
        }

        public static bool CheckingForSpecialChar(string input)
        {
            char[] checkingForSpecialChar = input.ToCharArray();
            bool containsSpecialChar = false;
            for (int i = 0; i < checkingForSpecialChar.Length; i++)
            {
                bool check = char.IsLetter(checkingForSpecialChar[i]);
                if (check == true)
                {
                    continue;
                }
                else
                {
                    if (checkingForSpecialChar[i] == '\'')
                    {
                        containsSpecialChar = false;
                        break;
                    }

                    else
                    {
                    containsSpecialChar = true;
                    break;
                    }
                }
            }
                return containsSpecialChar;

        }
    }
}