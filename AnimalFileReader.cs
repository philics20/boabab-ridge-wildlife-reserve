using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaobabRidge
{
    // Stores what we get back after reading the file
    public class LoadResult
    {
        public List<Animal> Animals { get; } = new List<Animal>();
        public int SkippedLines { get; set; }
        public string ErrorMessage { get; set; } = "";
        public bool HasError => ErrorMessage != "";
    }

    public static class AnimalFileReader
    {
        private const int ExpectedFields = 7;
        private const char Separator = '|';

        // Path to animals.txt, it sits next to the exe so it works on any pc
        public static string DataFilePath
        {
            get { return Path.Combine(AppContext.BaseDirectory, "animals.txt"); }
        }

        // Reads animals.txt and gives back the valid animals, how many lines were skipped and any error
        public static LoadResult ReadAll()
        {
            var result = new LoadResult();
            var idsAlreadyUsed = new HashSet<string>();

            try
            {
                // if the file is missing we make an empty one
                if (!File.Exists(DataFilePath))
                {
                    File.WriteAllText(DataFilePath, "", new UTF8Encoding(false));
                    return result;
                }

                using (var reader = new StreamReader(DataFilePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // blank lines are ignored
                        if (line.Trim().Length == 0)
                        {
                            continue;
                        }

                        // Add returns false if the ID was already seen, so duplicates get skipped
                        if (TryParseRecord(line, out Animal animal) && idsAlreadyUsed.Add(animal.Id))
                        {
                            result.Animals.Add(animal);
                        }
                        else
                        {
                            result.SkippedLines++;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                result.ErrorMessage = "Access to animals.txt was denied. Check the file permissions.";
            }
            catch (IOException)
            {
                result.ErrorMessage = "animals.txt is open in another program. Close it and try again.";
            }

            return result;
        }

        // Turns one line into an Animal, returns false if anything in the line is wrong
        private static bool TryParseRecord(string line, out Animal animal)
        {
            animal = null;
            string[] fields = line.Split(Separator);

            if (fields.Length != ExpectedFields)
            {
                return false;
            }

            string id = fields[0].Trim().ToUpper();
            string name = fields[1].Trim();
            string species = fields[2].Trim();
            string status = fields[5].Trim();
            string housing = fields[6].Trim();

            if (!LooksLikeValidId(id))
            {
                return false;
            }

            if (!TryReadWholeNumber(fields[3], out int age) || !TryReadWholeNumber(fields[4], out int score))
            {
                return false;
            }

            if (name == "" || species == "" || status == "" || housing == "")
            {
                return false;
            }

            animal = new Animal
            {
                Id = id,
                Name = name,
                Species = species,
                Age = age,
                Score = score,
                Status = status,
                HousingUnit = housing
            };
            return true;
        }

        // Checks the ID is WR- and then exactly 4 digits
        private static bool LooksLikeValidId(string id)
        {
            if (id.Length != 7 || !id.StartsWith("WR-"))
            {
                return false;
            }

            for (int i = 3; i < 7; i++)
            {
                if (!char.IsAsciiDigit(id[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // Reads a whole number 0 to 100, only digits allowed so things like 4.5 or abc fail
        private static bool TryReadWholeNumber(string text, out int value)
        {
            value = 0;
            text = text.Trim();

            if (text.Length == 0 || text.Length > 3)
            {
                return false;
            }

            foreach (char c in text)
            {
                if (!char.IsAsciiDigit(c))
                {
                    return false;
                }
            }

            value = int.Parse(text);
            return value >= 0 && value <= 100;
        }
    }
}
