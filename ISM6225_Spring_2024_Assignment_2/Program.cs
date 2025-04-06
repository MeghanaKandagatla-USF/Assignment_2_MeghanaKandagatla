using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
// This function finds all the missing numbers in the range [1, n] from the given array.
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                                HashSet<int> flag = new HashSet<int>(nums); // Store all numbers in a HashSet for quick lookup.
                List<int> missing = new List<int>(); // List to store missing numbers.
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!flag.Contains(i)) // If the number is not in the HashSet, add it to the missing list.
                        missing.Add(i);
                }
                return missing;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
// This function sorts an array such that all even numbers come before odd numbers.
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                                    while (left < right && nums[left] % 2 == 0) left++; // Move left pointer if the number is even.
                    while (left < right && nums[right] % 2 != 0) right--; // Move right pointer if the number is odd.

                    if (left < right)
                    {
// Swap even and odd numbers.
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;

                        left++;
                        right--;
                    }
                }
                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
// This function finds two indices in the array such that their values add up to the target.
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> map = new Dictionary<int, int>(); // Dictionary to store numbers and their indices.
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i]; // Calculate the complement.
                    if (map.ContainsKey(complement)) // Check if the complement exists in the dictionary.
                    {
                        return new int[] { map[complement], i }; // Return the indices.
                    }
                    if (!map.ContainsKey(nums[i]))
                    {
                        map[nums[i]] = i; // Add the number and its index to the dictionary.
                    }
                }
                return new int[0]; // Return an empty array if no solution is found.
                }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
// This function finds the maximum product of any three numbers in the array.
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array.
                int n = nums.Length;
// Calculate the product of the three largest numbers and the product of two smallest and the largest number.
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];
                int product2 = nums[0] * nums[1] * nums[n - 1];
                return Math.Max(product1, product2); // Return the maximum of the two products.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
// This function converts a decimal number to its binary representation.
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
               if (decimalNumber == 0) return "0"; // Handle the case for 0.

                string binary = "";
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary; // Append the remainder (0 or 1) to the binary string.
                    decimalNumber /= 2; // Divide the number by 2.
                }
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
// This function finds the minimum element in a rotated sorted array.
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2; // Calculate the middle index.

                    if (nums[mid] > nums[right]) // If the middle element is greater than the rightmost element, search the right half.
                    {
                        left = mid + 1;
                    }
                    else // Otherwise, search the left half.
                    {
                        right = mid;
                    }
                }
                return nums[left]; // The left pointer will point to the minimum element.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
// This function checks if a given number is a palindrome.
        public static bool IsPalindrome(int x)
        {
            try
            {
                                if (x < 0 || (x % 10 == 0 && x != 0)) // Negative numbers and numbers ending with 0 (except 0 itself) are not palindromes.
                    return false;

                int rev = 0;
                while (x > rev)
                {
                    rev = rev * 10 + x % 10; // Reverse the number partially.
                    x /= 10; // Reduce the original number.
                }
                return x == rev || x == rev / 10; // Check if the number is a palindrome.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
// This function calculates the nth Fibonacci number iteratively.
        public static int Fibonacci(int n)
        {
            try
            {
                if (n == 0) return 0; // Base case for 0.
                if (n == 1) return 1; // Base case for 1.

                int a = 0, b = 1;
                for (int i = 2; i <= n; i++) // Calculate Fibonacci numbers iteratively.
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }
                return b; // Return the nth Fibonacci number.
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

        