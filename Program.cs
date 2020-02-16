using System;

namespace bubbleSort
{
    class Program
    {
        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                                 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                                 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                                 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                                 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };

        
        static int[] sortedArray = new int[Program.intArray.Length];

        static int BubbleSort(int[] arr)
        {
            arr.CopyTo(sortedArray, 0);
            
            int swaps = 0;
            int greaterNum;
            int smallerNum;

            for (int lap = 0; lap < sortedArray.Length - 1; lap++)
            {
                for (int i = 0; i < sortedArray.Length - 1; i++)
                {
                    if (sortedArray[i] > sortedArray[i + 1])
                    {
                        greaterNum = sortedArray[i];
                        smallerNum = sortedArray[i + 1];
                        sortedArray[i] = smallerNum;
                        sortedArray[i + 1] = greaterNum;
                        swaps++;
                    }
                }                
            }
            return swaps;
        }

        static int LinearSearch(int[] arr, int findNum, ref int comparisons)
        {
            int index = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                ++comparisons;
                if (arr[i] == findNum)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        static int BinarySearch(int[] arr, int findNum, ref int comparisons)
        {
            int greaterNum = arr.Length - 1;
            int smallerNum = 0;
            bool foundIt = false;
            int index = -1;

            while (foundIt == false && smallerNum <= greaterNum)
            {
                int compareIndex = (smallerNum + greaterNum) / 2;
                ++comparisons;
                if (findNum == arr[compareIndex])
                {
                    index = compareIndex;
                    foundIt = true;
                }
                else if (findNum > arr[compareIndex])
                {
                    smallerNum = compareIndex + 1;
                }
                else if (findNum < arr[compareIndex])
                {
                    greaterNum = compareIndex - 1;
                }
            }

            return index;
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    Console.Write("{0}.\n\n", arr[i]);
                }
                else
                {
                    Console.Write("{0}, ", arr[i]);
                }
            }
        }

        static void Main()
        {
            int numOfComparisons = 0;

            int swaps = Program.BubbleSort(Program.intArray); // Sort the array in asc order

            Console.WriteLine("The initial unsorted integer array is:\n");
            Program.PrintArray(Program.intArray);

            Console.WriteLine("\nBubble sort made {0} swaps to sort the array. The sorted array is:\n", swaps);
            Program.PrintArray(Program.sortedArray);
            
            Console.Write("Enter the number you want to find > ");
            string choice = Console.ReadLine();
            int.TryParse(choice, out int findThisNum);

            int linearSearch = Program.LinearSearch(Program.intArray, findThisNum, ref numOfComparisons);
            if (linearSearch == -1)
            {
                Console.WriteLine("\nLinear search made {0} comparisons to find out {1} is not in the unsorted array.", numOfComparisons, findThisNum);
            }
            else
            {
                Console.WriteLine("\nLinear search made {0} comparisons to find out {1} is at index {2} in the unsorted array.", numOfComparisons, findThisNum, linearSearch);
            }
            
            numOfComparisons = 0; //refresh numOfComparisons

            int binarySearch = Program.BinarySearch(Program.sortedArray, findThisNum, ref numOfComparisons);
            if (binarySearch == -1)
            {
                Console.WriteLine("\nBinary search made {0} comparisons to find out {1} is not in the sorted array.", numOfComparisons, findThisNum);
            }
            else
            {
                Console.WriteLine("\nBinary search made {0} comparisons to find out {1} is at index {2} in the sorted array.", numOfComparisons, findThisNum, binarySearch);
            }

            Console.WriteLine("\n\nPlay again? (Y) > ");
            string playAgainChoice = Console.ReadLine();
            if (playAgainChoice == "y" || playAgainChoice == "Y")
            {
                Program.Main();
            }
            else
            {
                Console.WriteLine("\nBye!");
            }
        }
    }
}
