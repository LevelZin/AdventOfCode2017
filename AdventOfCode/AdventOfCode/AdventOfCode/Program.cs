using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int solution = puzzle5b();
            Console.WriteLine(solution);
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        static int puzzle5b()
        {
            string[] inputString = File.ReadAllLines(@"../../input5.txt");
            List<int> inputList = new List<int>();
            int count = 0;
            int input = 0;
            foreach (string i in inputString)
            {
                inputList.Add(Convert.ToInt32(i));
            }
            while (input >= 0 && input < inputList.Count)
            {
                count++;
                int step = inputList[input];
                if (step >= 3)
                {
                    inputList[input]--;
                }
                else
                {
                    inputList[input]++;
                }
                input += step;
            }
            return count;
        }

        static int puzzle5a()
        {
            string[] inputString = File.ReadAllLines(@"../../input5.txt");
            List<int> inputList = new List<int>();
            int count = 0;
            int input = 0;
            foreach (string i in inputString)
            {
                inputList.Add(Convert.ToInt32(i));
            }
            while (input >= 0 && input < inputList.Count)
            {
                count++;
                int step = inputList[input]++;
                input += step;
            }
            return count;
        }

        static int puzzle4b()
        {
            string[] lines = File.ReadAllLines(@"../../input4.txt");
            bool duplicateFound = false;
            int validPassphrases = 0;
            foreach (string line in lines)
            {
                string[] passphrases = line.Split(' ');
                string[] sorted = passphrases.OrderBy(o => o).ToArray();

                for (int i = 0; i < passphrases.Length; i++)
                {
                    char[] a = passphrases[i].ToCharArray();
                    Array.Sort(a);
                    passphrases[i] = new string(a);
                    for (int j = 0; j < passphrases.Length; j++)
                    {
                        char[] b = passphrases[j].ToCharArray();
                        Array.Sort(b);
                        passphrases[j] = new string(b);
                        if (passphrases[i] == passphrases[j] && i != j)
                        {
                            passphrases[j] = new string(b);
                            duplicateFound = true;
                            break;
                        }
                    }
                }
                if (!duplicateFound)
                {
                    validPassphrases++;
                }
                duplicateFound = false;
            }
            return validPassphrases;
        }

        static int puzzle4a()
        {
            string[] lines = File.ReadAllLines(@"../../input4.txt");
            int validPassphrases = 0;
            foreach (string line in lines)
            {
                string[] passphrases = line.Split(' ');
                for (int i = 0; i < passphrases.Length; i++)
                {
                    for (int j = passphrases.Length - 1; j < i; j--)
                    {
                        if (passphrases[i] == passphrases[j])
                        {
                            validPassphrases++;
                        }
                    }
                }
            }
            return validPassphrases;
        }

        static int puzzle3a()
        {
            int input = 361527;
            int x = 0;
            int y = 0;
            int directionX = 1;
            int directionY = 0;
            int segmentLength = 1;
            int currentStep = 0;
            int timesRotated = 0;
            int stepsToMiddle;

            for (int i = 2; i < input + 1; i++)
            {
                x += directionX;
                y += directionY;
                ++currentStep;
                if (currentStep == segmentLength)
                {
                    // change direction
                    int temp = directionX;
                    directionX = -directionY;
                    directionY = temp;

                    timesRotated++;

                    if (timesRotated == 2)
                    {
                        segmentLength++;
                        timesRotated = 0;
                    }
                    currentStep = 0;
                }
                if (i == input)
                {
                    stepsToMiddle = x + y;
                    return stepsToMiddle;
                }
            }
            return 0;
        }

        static int puzzle2b()
        {
            string[] lines = File.ReadAllLines(@"../../input2.txt");
            List<int> numbers = new List<int>();
            int checksum = 0;
            foreach (string line in lines)
            {
                int numberOfTabs = 0;
                int indexOfLatestTab = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].ToString() == "\t")
                    {
                        numberOfTabs++;
                        if (numberOfTabs <= 1)
                        {
                            string numberString = line.Substring(0, i);
                            numbers.Add(Convert.ToInt32(numberString));
                        }
                        else if (numberOfTabs > 1 && indexOfLatestTab != 0)
                        {
                            string numberString = line.Substring(indexOfLatestTab + 1, line.IndexOf("\t", i) - (indexOfLatestTab + 1));
                            numbers.Add(Convert.ToInt32(numberString));
                        }
                        indexOfLatestTab = i;
                    }
                    if (i == line.Length - 1)
                    {
                        string numberString = line.Substring(indexOfLatestTab + 1, line.Length - (indexOfLatestTab + 1));
                        numbers.Add(Convert.ToInt32(numberString));
                        for (int j = 0; j < numbers.Count; j++)
                        {
                            for (int k = numbers.Count - 1; k > j; k--)
                            {
                                if (Convert.ToDouble(numbers[j]) / Convert.ToDouble(numbers[k]) % 1 == 0)
                                {
                                    checksum += numbers[j] / numbers[k];
                                }
                                else if (Convert.ToDouble(numbers[k]) / Convert.ToDouble(numbers[j]) % 1 == 0)
                                {
                                    checksum += numbers[k] / numbers[j];
                                }
                            }
                        }
                        numbers.Clear();
                    }
                }
            }
            return checksum;
        }

        static int puzzle2a()
        {
            string[] lines = File.ReadAllLines(@"../../input2.txt");
            List<int> numbers = new List<int>();
            int checksum = 0;
            foreach (string line in lines)
            {
                int numberOfTabs = 0;
                int indexOfLatestTab = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].ToString() == "\t")
                    {
                        numberOfTabs++;
                        if (numberOfTabs <= 1)
                        {
                            string numberString = line.Substring(0, i);
                            numbers.Add(Convert.ToInt32(numberString));
                        }
                        else if (numberOfTabs > 1 && indexOfLatestTab != 0)
                        {
                            string numberString = line.Substring(indexOfLatestTab + 1, line.IndexOf("\t", i) - (indexOfLatestTab + 1));
                            numbers.Add(Convert.ToInt32(numberString));
                        }
                        indexOfLatestTab = i;
                    }
                    if (i == line.Length - 1)
                    {
                        string numberString = line.Substring(indexOfLatestTab + 1, line.Length - (indexOfLatestTab + 1));
                        numbers.Add(Convert.ToInt32(numberString));
                        checksum += (numbers.Max() - numbers.Min());
                        numbers.Clear();
                    }
                }
            }
            return checksum;
        }

        static int puzzle1b()
        {
            int sum = 0;
            string input = File.ReadAllText(@"../../input1.txt");

            if (!string.IsNullOrEmpty(input) && input.Length > 1 && input.Length % 2 == 0)
            {
                int halfway = input.Length / 2;
                for (int i = 0; i < input.Length; i++)
                {
                    var nextIndex = (i + halfway) % input.Length;
                    sum += (input[i] != input[nextIndex]) ? 0 : (int)Char.GetNumericValue(input[i]);
                }
            }

            return sum;
        }

        static int puzzle1a()
        {
            string input = File.ReadAllText(@"../../input1.txt");
            int sum = 0;
            if (!string.IsNullOrEmpty(input) && input.Length > 1)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    var nextIndex = (i + 1) % input.Length;
                    sum += (input[i] != input[nextIndex]) ? 0 : (int)Char.GetNumericValue(input[i]);
                }
            }

            return sum;
        }
    }
}
