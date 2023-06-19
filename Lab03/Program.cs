using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace Lab03
{
    public class Program
    {
        static void Main(string[] args)
        {
            ////Challenge 1
            Console.Write("Challenge 1\nPlease enter 3 numbers:");
            string inputNumbers = Console.ReadLine();
            int product = Multiple3Numbers(inputNumbers);
            Console.WriteLine($"The product of these 3 numbers is: {product}");

            ////Challenge 2
            
            Console.Write("\nChallenge 2\nPlease enter a number between 2-10: ");
            int render;
            while (true)
            {
                string inputRender = Console.ReadLine();
                if (int.TryParse(inputRender, out render) && render >= 2 && render <= 10)
                    break;
                Console.WriteLine("Invalid input. Please enter a number between 2-10: ");
            }

            int[] numbers = SetInputs(render);
            float average = CalculateAvg(numbers);
            Console.WriteLine($"The average of these {render} numbers is: {average}");
            
            ////////Challenge 3
            Console.WriteLine("\nChallenge 3");
            StarDraw();

            //////Challenge 4
            int[] arr = { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };
            int maxFrq = FindMaxFeq(arr);
            Console.WriteLine("\nChallenge 4\nExample: Input: [" + string.Join(",", arr) + "]");
            Console.WriteLine("the number that appears the most times " + maxFrq);

            /////Challenge 5
            int[] arr2 = { -6, 7, 8, 2, 1, 1 };
            int max = Max(arr);
            Console.WriteLine("\nChallenge 5\nExample: Input: [" + string.Join(",", arr2) + "]");
            Console.WriteLine("the maximum number is " + max);

            //////Challenge 6
            string path = "../../../words.txt";
            AddToWords(path);

            //////// Challenge 7
            ReadWords(path);

            /////// Challenge 8
            RemoveAddWord(path);

            ////// Challenge 9
            Console.WriteLine("\nChallenge 9\nEnter a sentence:");
            string sentence = Console.ReadLine();

            string[] wordAndLength = GetWordAndLength(sentence);

            Console.WriteLine("Output: [" + string.Join(",", wordAndLength) + "]");

            

        }
        public static int Multiple3Numbers(string inputNumbers) {
            string[] stringOfNumbers= inputNumbers.Split(' ');
            int[] numbers= new int[stringOfNumbers.Length];
            if (numbers.Length < 3)
                return 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    numbers[i] = Int32.Parse(stringOfNumbers[i]);
                }
                catch(FormatException ) {
                    numbers[i] = 1;
                }
                
            }
            return numbers[0] * numbers[1] * numbers[2];


        }
      
        public static int[] SetInputs(int render)
        {
            int[] numbers = new int[render];
            for (int i = 0; i < render; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1} of {render} - Enter a number: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        if (number >= 0)
                        {
                            numbers[i] = number;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Negative numbers are not allowed.please enter a positive number");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input format. Setting the number as 0.");
                        numbers[i] = 0;
                    }
                }
            }
            return numbers;
        }

        public static float CalculateAvg(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return (float)sum / numbers.Length;
        }
        private static void StarDraw()
        {
            int size = 5;
            //fisrt half
            for(int i = 1; i <= size; i++)
            {
                for(int  j = size-i; j>=1;j--)
                    Console.Write(" ");
                
                for(int k=1;k<= 2 * i - 1; k++)
                    Console.Write("*");

                Console.WriteLine();
            }
            //lower half
            for (int i = size-1;i>=1; i--)
            {
                for (int j = size - i; j >= 1; j--)
                    Console.Write(" ");

                for (int k = 1; k <= 2 * i - 1; k++)
                    Console.Write("*");

                Console.WriteLine();
            }
        }
        public static int FindMaxFeq(int [] arr)
        {
            Dictionary<int, int> numberOfFreq =new Dictionary<int, int>();
            for(int i=0;i<arr.Length;i++)
            {
                if (numberOfFreq.ContainsKey(arr[i]))
                    numberOfFreq[arr[i]]++;
                else
                    numberOfFreq.Add(arr[i], 1);
            }
            int maxValue= numberOfFreq.Values.Max();
            int keyOfMaxValue = numberOfFreq.FirstOrDefault(x => x.Value == maxValue).Key;
            return keyOfMaxValue;

        }
        public static int Max(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            { max = Math.Max(max, arr[i]); }
            return max;
        }
        public static void AddToWords(string path) {
            Console.WriteLine("\nChallenge 6\n write a word to add it in words.txt file");
            string word = Console.ReadLine();
            File.AppendAllText(path, word+" ");
        }
        public static void ReadWords(string path)
        {
            Console.WriteLine("\nChallenge 7\n the words from words.txt file:");
            Console.WriteLine(File.ReadAllText(path));
        }
        public static void RemoveAddWord(string path)
        {
            string[] words = File.ReadAllText(path).Split(' ');
            Console.WriteLine("\nChallenge 8\n");
            Console.WriteLine("Write the word that you want to remove");
            string wordToRemove = Console.ReadLine();
            Console.WriteLine("Write the word that you want to add");
            string wordToAdd = Console.ReadLine();

            bool wordRemoved = false;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == wordToRemove)
                {
                    words[i] = string.Empty;
                    wordRemoved = true;
                    break;
                }
            }

            if (wordRemoved)
            {
                string updatedText = string.Join(" ", words);
                updatedText += " " + wordToAdd;
                File.WriteAllText(path, updatedText);
                Console.WriteLine("updated text: "+File.ReadAllText(path));
            }
            else
            {
                Console.WriteLine("The word you wrote to remove was not found");
            }
        }


        public static string[] GetWordAndLength(string sentence)
        {
            string[] words = sentence.Split(' ');
            string[] wordAndLength = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int length = word.Length;
                wordAndLength[i] = $"\"{word}: {length}\"";
            }

            return wordAndLength;
        }
    }
}

/*
    *
   ***
  *****
 *******
*********
 *******
  *****
   ***
    *
*/
