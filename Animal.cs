using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boabab_ridge_wildlife_reserve
{
    public class Animal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; private set; }
        public string HousingUnit { get; private set; }

        public Animal(string id, string name, string species, int age, int recoveryScore)
        {
            Id = id.ToUpper().Trim();
            Name = name.Trim();
            Species = species.Trim();
            Age = age;
            RecoveryScore = recoveryScore;

            // Automatically calculate status and housing unit upon creation
            ClassifyAnimal(RecoveryScore);
        }
        //Method based on Recovery Score
        public void ClassifyAnimal(int score)
        {
            if (score >= 0 && score <= 19)
            {
                Status = "Critical";
                HousingUnit = "Intensive Care Unit";
            }
            else if (score >= 20 && score <= 39)
            {
                Status = "Serious";
                HousingUnit = "High-Dependency Ward";
            }
            else if (score >= 40 && score <= 59)
            {
                Status = "Stable";
                HousingUnit = "Recovery Ward";
            }
            else if (score >= 60 && score <= 79)
            {
                Status = "Recovering";
                HousingUnit = "Outdoor Enclosure";
            }
            else if (score >= 80 && score <= 100)
            {
                Status = "Release-Ready";
                HousingUnit = "Pre-Release Camp";
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(score),
                 "Recovery score must be between 0 and 100");
            }
        }
        public string ToFileString()
        {
            return $"{Id}|{Name}|{Species}|{Age}|{RecoveryScore}|{Status}|{HousingUnit}";
        }
 
    }
}
