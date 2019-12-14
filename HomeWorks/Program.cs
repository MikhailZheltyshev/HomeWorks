using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorks
{
    class TaskRunner
    {
        static void Main(string[] args)
        {
            var processor = new ArrayProcessor();
            Console.WriteLine("B: [{0}]", string.Join(", ", processor.Arr));
            processor.Var6_PrintElementsOccuredMoreThanOnce();
        }
    }

    class ArrayProcessor
    {
        public readonly int[] Arr = new int[20];
        private const int Min = -10;
        private const int Max = 10;

        public ArrayProcessor()
        {
            var rand = new Random();
            for (var i = 0; i < Arr.Length; i++)
            {
                Arr[i] = rand.Next(Min, Max);
            }

            Console.WriteLine($"Generated {Arr} array");
        }

        public void Var1_SwapMaxNegWithMinNeg()
        {
            var maxNegElement = Min;
            var maxNegIndex = 0;
            var minPosElement = Max;
            var minPosIndex = 0;

            for (var i = 0; i < Arr.Length; i++)
            {
                var current = Arr[i];
                if (current < 0 && current > maxNegElement)
                {
                    maxNegElement = current;
                    maxNegIndex = i;
                }
                else if (current >= 0 && current < minPosElement)
                {
                    minPosElement = current;
                    minPosIndex = i;
                }
            }

            SwapElements(Arr, maxNegIndex, minPosIndex);
        }

        public int Var2_CalcSumOfElementsWithEvenIndexes()
        {
            var sum = 0;
            for (int i = 0; i < Arr.Length; i += 2)
            {
                sum += Arr[i];
            }

            return sum;
        }

        public void Var3_ReplaceNegativeElementsWithZeroes()
        {
            for (var i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] < 0)
                {
                    Arr[i] = 0;
                }
            }
        }

        public void Var4_TripleAllPosElementsBeforeNeg()
        {
            for (var i = 0; i < Arr.Length - 1; i++)
            {
                var current = Arr[i];
                if (current > 0 && Arr[i + 1] < 0)
                {
                    Arr[i] = current * 3;
                }
            }
        }

        public int Var5_CalcDiffBetweenAvgAndMinElement()
        {
            var min = Arr[0];
            var sum = Arr[0];
            for (var i = 1; i < Arr.Length; i++)
            {
                var current = Arr[i];
                if (current < min)
                {
                    min = current;
                }

                sum += current;
            }

            return (sum / Arr.Length) - min;
        }

        public void Var6_PrintElementsOccuredMoreThanOnce()
        {
            var dict = new Dictionary<int, int>();
            foreach (var currentKey in Arr)
            {
                var currentValue = dict.GetValueOrDefault(currentKey, 0);
                dict[currentKey] = ++currentValue;
            }

            var elements = dict.Where(kv => kv.Value > 1)
                .Select(kv => kv.Key)
                .ToList();
            elements.ForEach(Console.WriteLine);
        }

        private static void SwapElements(int[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }
    }
}