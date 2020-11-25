using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        static int minYear;
        static int maxYear;
        static int periods;
        static int firstPeriod;
        static int lastPeriod;

        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            SetMinMaxYear(names);
            string[] xLabels = SetPeriodsOfYearsInString();

            double[] yValues = SetNumFertilityOfName(names, name);

            return new HistogramData(
                string.Format("Рождаемость людей "),
                xLabels,
                yValues);
        }

        public static void SetMinMaxYear(NameData[] names)
        {
            minYear = int.MaxValue;
            maxYear = int.MinValue;
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].BirthDate.Year < minYear) minYear = names[i].BirthDate.Year;
                if (names[i].BirthDate.Year > maxYear) maxYear = names[i].BirthDate.Year;
            }
        }

        private static double[] SetNumFertilityOfName(NameData[] names, string name)
        {
            var yValues = new double[31];
            foreach (var person in names)
            {
                var index = (person.BirthDate.Year - firstPeriod) / 10;
                yValues[index]++;
            }
            return yValues;
        }

        public static string[] SetPeriodsOfYearsInString()
        {
            periods = ((maxYear - minYear) / 10) + 1;

            var xLabels = new string[periods+1];

            firstPeriod = minYear / 10 * 10;
            lastPeriod = maxYear / 10 * 10;

            var period = firstPeriod;
            int i = 0;

            while(period <= lastPeriod)
            {
                xLabels[i] = (period).ToString() + " - " + (period + 9).ToString();
                i++;
                period += 10;
            }

            return xLabels;
        }
    }
}
