using System;

namespace Names
{
    internal static class HeatmapTask
    {
        enum Months
        {
            Январь,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }

        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var sizeArray = 30;
            var countdown = 2;
            string[] xlabels = SetTimeString(sizeArray, countdown);

            sizeArray = 12;
            countdown = 1;
            string[] yLabels = SetTimeString(sizeArray, countdown);
            // yLabels[] = (Enum.GetNames(typeof(Months))).ToString();

            double[,] heat = SetIntensity(names);

            return new HeatmapData(
                "Пример карты интенсивностей",
                heat,
                xlabels,
                yLabels);
        }

        private static double[,] SetIntensity(NameData[] names)
        {
            double[,] heat = new double[30, 12];
            
            foreach (var person in names)
            {
                if (person.BirthDate.Day != 1) heat[person.BirthDate.Day - 2, person.BirthDate.Month - 1]++;
            }
            return heat;
        }

        private static string[] SetTimeString(int sizeArray, int countdown)
        {
            var xLabels = new string[sizeArray];

            for (int i = countdown; i < sizeArray + countdown; i++)
            {
                xLabels[i - countdown] = i.ToString();
            }

            return xLabels;
        }
    }
}

