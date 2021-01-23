using System;
using System.Collections.Generic;
using System.Linq;

namespace ZadaniaSpoj
{
    class Program
    {
        public static void Main()
        {

            switch (Console.ReadLine()) {

                case "test1": Test1(Console.ReadLine());
                    break;

                case "test2":
                    Test2(Console.ReadLine());
                    break;

                case "test3":
                    Test3(Console.ReadLine());
                    break;

                case "test4":
                    Test4(Console.ReadLine());
                    break;

                case "test5":
                    Test5(Console.ReadLine());
                    break;

            }


       
        }



        public static void Test5(string timesString)
        {
            var average = GetLoopsActualTimes(timesString).Average();

            short averageMinutes = (short)Math.Floor(average / 60);
            short averageSeconds = (short)Math.Ceiling(average % 60);

            Console.WriteLine($"{averageMinutes:D2}:{averageSeconds:D2}");

        }


        public static void Test4(string timesString)
        {
            var times = GetTimeListWithIndex(timesString);
            var maxNumber = times.Max(t => (t.Item1, t.Item2));
            var maxPosition = times.Where(t => t.Item1 == maxNumber.Item1).Select(t => (t.Item2));



            Console.WriteLine($"{((maxNumber.Item1 / 60) % 60):D2}:{(maxNumber.Item1 % 60):D2} {String.Join(" ", maxPosition)}");
        }


        public static void Test3(string timesString)
        {

            var times = GetTimeListWithIndex(timesString);
            var minNumber = times.Min(t => (t.Item1, t.Item2));
            var minPosition = times.Where(t => t.Item1 == minNumber.Item1).Select(t => (t.Item2));

            Console.WriteLine($"{((minNumber.Item1 / 60) % 60):D2}:{(minNumber.Item1 % 60):D2} {String.Join(" ", minPosition)}");
        }

        private static List<int> GetLoopsActualTimes(string timesString)
        {
            int[] timesInSeconds = GetTimestamps(timesString);

            List<int> loopTimes = timesInSeconds.Skip(1).Zip(timesInSeconds, (curr, prev) => curr - prev).Prepend(timesInSeconds.First()).ToList();

            return loopTimes;
        }

        private static int[] GetTimestamps(string timesString)
        {
            string[] timesList = timesString.Split(",");

            int[] timesInSeconds = timesList.Select(t => t.Split(":")).Select(t => int.Parse(t[1]) + (int.Parse(t[0]) * 60)).ToArray();

            return timesInSeconds;


        }




        public static IEnumerable<Tuple<int,int>> GetTimeListWithIndex(string timesString) 
        {
            List<int> loopTimes = GetLoopsActualTimes(timesString);

            return loopTimes.Select((t, index) => new Tuple<int, int>(item1: t, item2: index + 1));

        }

        public static void Test2(string timesString)
        {
            List<int> loopTimes = GetLoopsActualTimes(timesString);

            var times = loopTimes.Select(t => $"{((t / 60) % 60):D2}:{(t % 60):D2}");

            Console.WriteLine(String.Join(" ", times.ToArray()));
        }


        public static void Test1(string timesString)
        {
            Console.WriteLine(timesString.Split(",").Count());
        }


    }

   
}

