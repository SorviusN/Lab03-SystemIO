using System;
using System.Collections.Generic;
using System.IO;

namespace Lab03_SystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            Challenge1();
            Challenge2();
            Challenge3();
            Challenge4(arr);
            Challenge5(arr);
            Challenge6();
            Challenge7();
            string word = "badword";
            Challenge8(word);
        }

        public static int Challenge1()
        {
            Console.WriteLine("Please enter in 3 numbers on one line, separated by spaces.");
            string res = Console.ReadLine();
            int productRes = Product(res);
            Console.WriteLine($"The product of these 3 nums is {productRes}");
            return productRes;
        }

        public static int Product(string numbers)
        {
            int product = 1;
            string[] productArr = numbers.Split(' ');
            if (productArr.Length < 3) return 0;
                for (int i = 0; i < 3; i++)
            {
                try
                {
                    int intNum = Convert.ToInt32(productArr[i]);
                    product = product * intNum;

                }
                catch (Exception e)
                {
                    product = product * 1;
                }
            }
            return product;
        }

        public static int Challenge2()
        {
            try
            {
                Console.WriteLine("Please enter in a number between 2 - 10");
                int arrLength = Convert.ToInt32(Console.ReadLine());

                if (arrLength < 2 || arrLength > 10) throw new Exception("Out of range. Please try again.");

                int[] arr = new int[arrLength - 1];
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine($"{i + 1} of {arr.Length} - Enter a number:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num < 0)
                    {
                        throw new Exception("Num cannot be lesser than 0");
                    }
                    arr[i] = num;
                    sum += num;
                }
            int avg = sum / arr.Length;
            Console.WriteLine($"The average of these numbers is {avg}");
            return avg;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter in an integer for your value.");
                return -1;
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
        public static void PrintDesign()
        {
            //The brute force way
            Console.WriteLine("    *");
            Console.WriteLine("   ***");
            Console.WriteLine("  *****");
            Console.WriteLine(" *******");
            Console.WriteLine("*********");
            Console.WriteLine(" *******"); //line 6 1 space 7*
            Console.WriteLine("  *****");   //line 7 2 space 5*
            Console.WriteLine("   ***");    //line 8 3 space 3*
            Console.WriteLine("    *");
            //Algorithm Way
            for (int i = 0; i < 9; i++)
            {
                string output = "";
                //Ascending edge
                if (i < 5)
                {
                    //add 4-i spaces
                    for (int j = 0; j < 4 - i; j++)
                    {
                        output = output + " ";
                    }
                    //add 2i+1 *
                    for (int j = 0; j < (2 * i) + 1; j++)
                    {
                        output = output + "*";
                    }
                }
                //Descending edge
                else
                {
                    //spaces equal to i-5
                    for (int j = 0; j < i-4; j++)
                    {
                        output = output + " ";
                    }
                    //* equal to 9-(i-5) * 2
                    for (int j = 0; j < 9 - (i-4) *2; j++)
                    {
                        output = output + "*";
                    }
                }
                Console.WriteLine(output);
            }
        }
        public static void Challenge3()
        {
            Console.Write("    * \n\n   *** \n\n  *****\n\n *******\n\n*********\n\n *******\n\n  *****\n\n   ***\n\n    * ");
        }
        public static int Challenge4(int[] arr)
        {
            int[] ansArr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int ans = ansArr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                ansArr[arr[i]]++;
            }
            for (int i = 1; i < ansArr.Length; i++)
            {
                if (ansArr[i] > ansArr[i - 1])
                {
                    ans = Array.IndexOf(ansArr, ansArr[i]);
                }
            }
            return ans;
        }

        public static int Challenge5(int[] arr)
        {
            int maxVal = 0;

            bool isSame = true;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[0] != arr[i]) isSame = false;
            }

            if (isSame == true) throw new Exception("Invalid array. All values are same.");

            foreach(int num in arr)
            {
                if (num < 0) throw new Exception("Number in array cannot be lesser than 0.");
                if (num > maxVal) maxVal = num;
            }
            return maxVal;
        }

        public static void Challenge6()
        {
            string filePath = "../../../../string.txt";

            Console.WriteLine(
                "Please enter a word\n" +
                "The word you enter will be saved to a local file\n" +
                "Then i will display that word from within."
                );

            string userString = Console.ReadLine();
            File.AppendAllText(filePath, "\n");
            File.AppendAllText(filePath, userString);
        }

        public static void Challenge7()
        {
            string filePath = "../../../../string.txt";
            string fileText = File.ReadAllText(filePath);
            Console.WriteLine(fileText);
        }

        public static void Challenge8(string badWord)
        {
            string filePath = "../../../../string.txt";

            string fileText = File.ReadAllText(filePath);
            string[] words = fileText.Split(' ');
            for (int i = 0; i < words.GetLength(0); i++)
            {
                if (words[i] == badWord)
                {
                    words[i] = "";
                }
                Console.WriteLine(words[i]);
            }
            string newText = String.Join(' ', words);
            try
            {
            Console.WriteLine(newText);
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    try
                    {
                        sw.Write(newText);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                    finally
                    {
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void ChallengeNine()
        {
            Console.WriteLine("Please write a sentence with no punctuation");
            string userInput = Console.ReadLine();
            string[] inputArray = userInput.Split(" ");
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = inputArray[i] + ":" + inputArray[i].Length.ToString();
                Console.WriteLine(inputArray);
            }
        }
    }
}
