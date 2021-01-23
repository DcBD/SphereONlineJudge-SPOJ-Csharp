using System;
using System.Linq;


namespace ZadaniaSpoj.WSEI
{
    class KM03LINQ
    {
        public static void Main()
        {

            Oblicz(Console.ReadLine());
        }


        public static void Oblicz(string tracks)
        {
            if (tracks.Length == 0)
            {
                Console.WriteLine();
                return;
            }

            string[] tracksList = tracks.Split(",");
            var query = tracksList.Select(t => t.Split(":")).Select(t => int.Parse(t[1]) + (int.Parse(t[0]) * 60));


            double averageTime = query.Average();
            double sumTime = query.Sum();
            int count = tracksList.Count();

            short averageMinutes = (short)Math.Floor(averageTime / 60);
            short averageSeconds = (short)Math.Ceiling(averageTime % 60);


            short sHours = (short)Math.Floor((sumTime / 3600) % 24);
            short sMinutes = (short)Math.Floor((sumTime / 60) % 60);
            short sSeconds = (short)Math.Ceiling(sumTime % 60);


            if (sHours > 0)
            {
                Console.WriteLine($"{count} {averageMinutes:D0}:{averageSeconds:D2} {sHours:D0}:{sMinutes:D2}:{sSeconds:D2}");
            }
            else
            {
                Console.WriteLine($"{count} {averageMinutes:D0}:{averageSeconds:D2} {sMinutes:D0}:{sSeconds:D2}");
            }
        }
    }
}


