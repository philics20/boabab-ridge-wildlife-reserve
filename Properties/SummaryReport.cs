using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace boabab_ridge_wildlife_reserve
{
    public static class SummaryReport
    {
        public static string Create(IEnumerable<Animal> animals)
        {
            if (animals == null)
                throw new ArgumentNullException(nameof(animals));
            List<Animal> records = animals
                .Where(a => a != null)
                .ToList();
            int total = records.Count;
            double averageAge = total == 0
                ? 0
                : records.Average(a => a.Age);
            double averageScore = total == 0
                ? 0
                : records.Average(a => a.RecoveryScore);
            string[] statuses =
            {
               "Critical",
               "Serious",
               "Stable",
               "Recovering",
               "Release-Ready"
           };
            List<string> lines = new List<string>
           {
               "BAOBAB RIDGE WILDLIFE RESERVE",
               "ANIMAL RECOVERY SUMMARY REPORT",
               "--------------------------------",
               "Total Animals: " + total,
               "Average Age: " +
               averageAge.ToString("F2", CultureInfo.InvariantCulture),
               "Average Recovery Score: " +
               averageScore.ToString("F2", CultureInfo.InvariantCulture),
               "",
               "ANIMALS BY STATUS"
           };
            foreach (string status in statuses)
            {
                int count = records.Count(a =>
                    string.Equals(
                        a.Status,
                        status,
                        StringComparison.OrdinalIgnoreCase));
                lines.Add(status + ": " + count);
            }
            return string.Join(Environment.NewLine, lines)
                   + Environment.NewLine;
        }
    }
}