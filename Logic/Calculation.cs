using System;
using System.Collections.Generic;

namespace Logic
{
    public static class Calculation
    {
        #region Bit Insertion

        private const int MinIndexInInt32 = 0;
        private const int MaxIndexInInt32 = 31;
        private const string InvalidIndexesStr = "Invalid bit indexes";

        /// <summary>
        /// Returns the destination number with bits from start to end replaced 
        /// by the bits extracted from the source from start to end
        /// (bit numeration from right to left)
        /// </summary>
        /// <param name="source">Number to extract bits from</param>
        /// <param name="destination">Number to insert bits to</param>
        /// <param name="start">Index of the bit starting the sequence to be inserted</param>
        /// <param name="end">Index of the bit ending the sequence to be inserted</param>
        /// <returns></returns>
        public static int InsertBits(int source, int destination, int start, int end)
        {
            CheckIndexes(start, end);

            int numOfBitsToInsert = end - start + 1;

            int bitsToInsert = source >> start & GetMask(numOfBitsToInsert);
            int result = (destination >> end + 1) << numOfBitsToInsert;
            result |= bitsToInsert;
            result <<= start;
            result |= destination & GetMask(start);

            return result;
        }

        /// <summary>
        /// Returns a number in which the first numBits bits from the right equal to 1, 
        /// the others equal to 0
        /// </summary>
        /// <param name="numOfBits">Number of bits from the right to set to 1</param>
        /// <returns></returns>
        private static int GetMask(int numOfBits)
        {
            return ~(~0 << numOfBits);
        }

        private static void CheckIndexes(int start, int end)
        {
            CheckIndexValid(start);
            CheckIndexValid(end);

            if (end < start)
            {
                throw new ArgumentException(InvalidIndexesStr);
            }
        }

        private static void CheckIndexValid(int index)
        {
            if (index < MinIndexInInt32 || index > MaxIndexInInt32)
            {
                throw new ArgumentOutOfRangeException(InvalidIndexesStr);
            }
        }

        #endregion

        #region Even Index

        public const int MaxArraySize = 1000;

        /// <summary>
        /// Finds the array index for which the sum of preceeding elements
        /// equals to the sum of proceeding elements
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int FindEvenIndex(int[] array)
        {
        	CheckArray(array);
        	for(int i = 1; i < array.Length; i++)
        	{
        		if(GetSum(array, 0, i - 1) == GetSum(array, i + 1, array.Length - 1))
        		{
        			return i;
        		}
        	}
        	return -1;
        }

        private static int GetSum(int[] array, int start, int end)
        {
        	int sum = 0;

            for (int i = start; i <= end; i++)
        	{
        		sum += array[i];
        	}

        	return sum;
        }

        private static void CheckArray(int[] array)
        {
        	if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (array.Length == 0 || array.Length >= MaxArraySize)
            {
                throw new ArgumentException(nameof(array));
            }
        }

        #endregion

        #region Next Bigger Number

        /// <summary>
        /// Returns the closest bigger integer consisting of the number digits
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>The closest bigger integer</returns>
        public static int GetNextBiggerNumber(int number)
        {
            CheckNumber(number);

            int[] digits = GetArrayOfDigits(number);

            for (int i = digits.Length - 1; i >= 1; i--)
            {
                if (digits[i] > digits[i - 1])
                {
                    Swap(ref digits[i], ref digits[i - 1]);
                    Array.Sort(digits, i, digits.Length - i);
                    return FormNumberFromDigits(digits);
                }
            }
            return -1;
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        private static int FormNumberFromDigits(int[] digits)
        {
            int number = 0;
            for (int i = 0, power = digits.Length - 1; i < digits.Length; i++)
            {
                number += (int)(digits[i] * Math.Pow(10, power));
                power--;
            }
            return number;
        }

        private static int[] GetArrayOfDigits(int number)
        {
            int[] digits = new int[GetArrayOfDigitsLength(number)];

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = number % 10;
                number /= 10;
            }
            return digits;
        }

        private static int GetArrayOfDigitsLength(int number)
        {
            int length = 0;

            if (number == 0)
                return 1;

            while (number > 0)
            {
                length++;
                number /= 10;
            }
            return length;
        }

        private static void CheckNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException(nameof(number));
            }
        }

        #endregion
    }
}
