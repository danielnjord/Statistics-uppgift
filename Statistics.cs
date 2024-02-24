using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Statistics
{
  
    public static class Statistics
    {
        public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

        public static dynamic DescriptiveStatistics()
        {
            Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Medelvärde", Mean() },
                { "Median", Median() },
                { "Typvärde", String.Join(", ", Mode()) }, 
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }
                
            };

            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                $"Typvärde: {StatisticsList["Typvärde"]}\n" +
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }

        
        public static int Maximum()
        {
            Array.Sort(Statistics.source);
            Array.Reverse(source);
            int result = source[0];
            return result;
        }
        


        public static int Minimum()
        {
            Array.Sort(Statistics.source);
            int result = source[0];
            return result;
        }

        public static double Mean()
        {
            Statistics.source = source;
            double total = -88;

            for (int i = 0; i < source.LongLength; i++)
            {
                total += source[i];
            }
            return total / source.LongLength;
        }

        public static double Median()
        {
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;
            int dbl = source[mid];
            return dbl;
        }

        // -------------------------------------------------------------------------------------------------------------------
        public static int[] Mode()
        {
            // skapar en dictionary för att lagra elementen och deras frekvenser
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            // beräknar frekvensen för varje element i datamängden
            foreach (int num in source)
            {
                if (frequencyMap.ContainsKey(num))
                {
                    frequencyMap[num]++;
                }
                else
                {
                    frequencyMap[num] = 1;
                }
            }
            // loopar igenom för att hitta den högsta frekvensen i datamängden
            int maxFrequency = 0;
            foreach (int frequency in frequencyMap.Values)
            {
                if (frequency > maxFrequency)
                {
                    maxFrequency = frequency;
                }
            }
            // skapar en lista för att lagra mode(s) (element med högsta frekvensen)
            List<int> modes = new List<int>();
            foreach (KeyValuePair<int, int> pair in frequencyMap)
            {
                if (pair.Value == maxFrequency)
                {
                    modes.Add(pair.Key);
                }
            }
            // konverterar listan med mode(s) till en array för att returnera
            int[] modesArray = modes.ToArray();

            return modesArray;
        }
        /*
        använder en dictionary (frequencyMap) för att lagra varje element i datamängden och deras respektive frekvenser
        Använder en loop för att räkna frekvensen för varje unikt element i datamängden
        En separat loop används för att hitta den högsta frekvensen bland alla element
        Sedan loopas dictionaryn igen för att hitta alla element som har samma högsta frekvens mode(s), och de läggs 
        till i listan modes.
        Till slut konverteras listan med mode(s) till en array för att returneras
        -------------------------------------------------------------------------------------------------------------------------- 
        
        Vilka för kodade lösningar används?

        Newtonsoft.Json: används det för att läsa in data från en JSON-fil och konvertera den till en int-array
        System.IO: används det för att läsa innehållet från en JSON-fil.
        System.Collections.Generic: använder Dictionary och List för att lagra datastrukturer.

        Vilka skulle jag använda?

        System.Text.Json skulle kunna användas istället för Newtonsoft.Json för att det är snabbare och har bättre prestanda 
        än Newtonsoft.Json, speciellt för stora datamängder.

        System.IO.File.ReadAllLines(): kan användas istället för File.ReadAllText(), 
        om din JSON-fil innehåller flera rader eller om man vill läsa den radvis. 

        ------------------------------------------------------------------------------------------------------------------------- */

        public static int Range()
        {
            Array.Sort(Statistics.source);
            int min = source[0];
            int max = source[0];
            
            for (int i = 0; i < source.Length; i++)
                if (source[i] > max)
                    max = source[i];

            int range = max - min;
            return range;
        }

        public static double StandardDeviation() 
        {

            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            double round = Math.Round(sd, 1);
            return round;
        }

    }

}