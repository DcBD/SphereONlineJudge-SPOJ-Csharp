using System;
using System.Collections.Generic;
using System.Linq;

namespace ZadaniaSpoj.WSEI
{
    class KM01LINQ
    {
        public static void Main()
        {
            int D = Convert.ToInt32(Console.ReadLine());
            List<string> texts = new List<string>();
            List<string> commands = new List<string>();
            for (int i = 1; i <= D; i++)
            {
                texts.Add(Console.ReadLine());
                commands.Add(Console.ReadLine());
            }
            for (int j = 0; j < D; j++)
            {
                Oblicz(texts[j], commands[j]);
            }
        }
        public static void Oblicz(string str, string command)
        {
            // Characters query
            var query = (from ch in str select ch)
                .Select(characte => Char.ToLower(characte))
                .Where(characte => Char.IsLetter(characte))
                .GroupBy(character => character)
                .Select(characters => new
                {
                    Letter = characters.Key,
                    Count = characters.Count()
                });
            // Commands
            string[] commands = command.Split(" ");

            var orderedQuery = query.OrderBy(q => 0);

            for (int i = 0; i < commands.Length; i += 2)
            {
                switch (commands[i])
                {
                    case "byfreq":
                        if (commands[i + 1] == "desc")
                        {
                            orderedQuery = orderedQuery.ThenByDescending(characters => characters.Count);
                        }
                        else if (commands[i + 1] == "asc")
                        {
                            orderedQuery = orderedQuery.ThenBy(characters => characters.Count);

                        }
                        break;

                    case "byletter":
                        if (commands[i + 1] == "desc")
                        {
                            orderedQuery = orderedQuery.ThenByDescending(characters => characters.Letter);
                        }
                        else if (commands[i + 1] == "asc")
                        {
                            orderedQuery = orderedQuery.ThenBy(characters => characters.Letter);
                        }
                        break;
                }
            }

            query = orderedQuery;

            for (int i = 0; i < commands.Length; i += 2)
            {
                switch (commands[i])
                {
                    case "first":
                        query = query.Take(int.Parse(commands[i + 1]));
                        break;
                    case "last":
                        query = query.TakeLast(int.Parse(commands[i + 1]));
                        break;
                }
            }

            foreach (var result in query)
            {
                Console.WriteLine($"{result.Letter} {result.Count}");
            }

            Console.WriteLine();

        }

    }


}

