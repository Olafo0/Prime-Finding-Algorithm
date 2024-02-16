using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

namespace PrimeNumberFinder
{
    internal class Program
    {


        private static void Cal(int limit)
        {
            List<int[]> numberPool = new List<int[]>();
            int[] firstarray = new int[] { 2, 4 };
            numberPool.Add(firstarray);

            List<int> primeNumbers = new List<int>
                    {
                        firstarray[0]
                    };

            long startTimer = Stopwatch.GetTimestamp();
            for (int i = 3; i < limit; i++)
            {
                numberPool = numberPool.OrderBy(array => array[1]).ToList();
                if (i < numberPool[0][1])
                {
                    primeNumbers.Add(i);
                    int newSquaredNumber = (int)Math.Pow(i, 2);
                    int[] newLocalPrimeArray = new int[] { i, newSquaredNumber };
                    numberPool.Add(newLocalPrimeArray);
                }
                else if (i >= numberPool[0][1])
                {
                    var eee = numberPool.Where(x => x[1] == numberPool[0][1]).ToList();
                    foreach (var items in eee)
                    {
                        items[1] += items[0];
                    }
                }
            }
            TimeSpan time = Stopwatch.GetElapsedTime(startTimer);
            string primeNumberStringArray = string.Join(" ", primeNumbers);
            Console.WriteLine(primeNumberStringArray);
            Console.WriteLine($"Time took: {time}");
            Console.Write("PRESS ANY KEY TO GO BACK");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Boolean flag = true;
                    int limit = 0;

                    Console.WriteLine("Dijkstra's Hidden Prime Finding Algorithm");
                    Console.WriteLine("inspired by b001 on yt");
                    Console.WriteLine("The range of prime numbers you want to see 2 - X");
                    Console.Write("ENTER :");
                    Console.SetCursorPosition(7, 3);

                    while (flag)
                    {
                        string stringLimit = Console.ReadLine();
                        try
                        {
                            limit = int.Parse(stringLimit);
                            flag = false;
                        }
                        catch
                        {
                            Console.Clear();
                            Console.WriteLine("NUMBERS ONLY");
                            Console.WriteLine("The range of prime numbers you want to see 2 - X");
                            Console.Write("ENTER :");
                        }

                        Cal(limit);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    }