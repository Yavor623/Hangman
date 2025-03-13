using CrypticWizard;
using CrypticWizard.RandomWordGenerator;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wordGenerator = new WordGenerator();
            int lives = 7;
            bool isItGuessed = false;
            bool noMoreOptions = false;
            //string[] words = { "water", "body", "head", "smile", "mouse","desk","computer","clock","ring","school","bag" };
            //Random random = new Random();
            //int randomNum = random.Next(0, words.Length - 1);
            string chosenWord = wordGenerator.GetWord(WordGenerator.PartOfSpeech.noun);
            int iterator = 0;
            bool isItMet = false;
            bool isThisLetterCorrect = false;
            List<char> dividedWord = chosenWord.ToList();
            int lettersToGuess = dividedWord.Count;
            string layout ="";
            List<char> layoutChangeable = new List<char>();
            foreach (var item in dividedWord)
            {
                layout+="_";
            }
            Console.WriteLine(layout.ToString());
            while (!isItGuessed||!noMoreOptions)
            {
                iterator = 0;
                isItMet = false;
                isThisLetterCorrect = false;
                if (lettersToGuess == 0)
                {
                    isItGuessed = true;
                    break;
                }
                else if (lettersToGuess > 0 && lives == 0)
                {
                    noMoreOptions = true;
                    break;
                }
                Console.WriteLine("Guess the word: ");
                char letter = char.Parse(Console.ReadLine());
                dividedWord.ForEach(a => {
                    
                    if (a == letter)
                    {
                            layoutChangeable = layout.ToList();
                            layoutChangeable.RemoveAt(iterator);
                            layoutChangeable.Insert(iterator, letter);
                            layout = new string(layoutChangeable.ToArray());
                            lettersToGuess--;
                            isThisLetterCorrect = true;
                    }
                    iterator++;
                });
                if (!isThisLetterCorrect)
                {
                    Console.WriteLine();
                    Console.WriteLine("Incorrect");
                    lives--;
                }
                else if(isThisLetterCorrect)
                {
                    Console.WriteLine();
                    Console.WriteLine("Correct");
                }
                Console.WriteLine($"You have {lives} lives");
                Console.WriteLine(layout);
                Console.WriteLine();
            }
            Console.WriteLine($"The word was: {chosenWord}\n");
            if (isItGuessed)
            {
                Console.WriteLine("You guessed the word!");
            }
            else if(noMoreOptions)
            {
                Console.WriteLine("No more lives :(");
            }
        }
    }
}
