using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaobabRidge
{
    // Holds everything that comes back from reading animals.txt.
    public class LoadResult
    {
        public List<Animal> Animals { get; } = new List<Animal>();
        public int SkippedLines { get; set; }
        public string ErrorMessage { get; set; } = "";
        public bool HasError => ErrorMessage != "";
    }

    // Reads animals.txt from the folder that holds the running .exe.
    public static class AnimalFileReader
    {
        private const int ExpectedFields = 7;
        private const char Separator = '|';

        // Full path to the data file, built from the .exe folder so it works on any computer.
        public static string DataFilePath
        {
            get { return Path.Combine(AppContext.BaseDirectory, "animals.txt"); }
        }

        // Reads the whole file and returns the valid animals, a skipped line count and any error text.
        public static LoadResult ReadAll()
        {
            var result = new LoadResult();
            var idsAlreadyUsed = new HashSet<string>();

            try
            {
                // No file yet: create an empty one so later features can append to it.
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
                        // Blank lines are not records, so they are ignored and not counted.
                        if (line.Trim().Length == 0)
                        {
                            continue;
                        }

                        // A line is kept only if it parses and its ID has not appeared before.
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

        // Tries to turn one line into an Animal. Returns false if any field is invalid.
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

            // Text fields must not be empty.
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

        // Checks that the ID is WR- followed by exactly four digits.
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

        // Reads a whole number from 0 to 100 made only of digits. Rejects decimals, signs and text.
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

/* ------------------------------------------------------------------
   Paste into your main form class (Form1.cs).
   Needed usings: System.ComponentModel, System.Collections.Generic.
   ------------------------------------------------------------------

// Header text and the Animal property each grid column shows, in the required order.
private static readonly (string Header, string Property)[] GridColumns =
{
    ("Animal ID", nameof(Animal.Id)),
    ("Name", nameof(Animal.Name)),
    ("Species", nameof(Animal.Species)),
    ("Age", nameof(Animal.Age)),
    ("Recovery Score", nameof(Animal.Score)),
    ("Status", nameof(Animal.Status)),
    ("Housing Unit", nameof(Animal.HousingUnit))
};

// Builds the grid columns and locks the grid down. Call once from the form constructor.
private void SetUpGrid()
{
    dgvAnimals.AutoGenerateColumns = false;
    dgvAnimals.Columns.Clear();

    foreach (var column in GridColumns)
    {
        var gridColumn = new DataGridViewTextBoxColumn();
        gridColumn.HeaderText = column.Header;
        gridColumn.DataPropertyName = column.Property;
        gridColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
        dgvAnimals.Columns.Add(gridColumn);
    }

    dgvAnimals.ReadOnly = true;
    dgvAnimals.AllowUserToAddRows = false;
    dgvAnimals.AllowUserToDeleteRows = false;
    dgvAnimals.MultiSelect = false;
    dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    dgvAnimals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
}

// Reloads the file and refreshes the grid. Other features call this after add, update and delete.
// Pass true only at startup so the skipped lines message appears once.
public void ReloadGrid(bool announceSkipped = false)
{
    LoadResult result = AnimalFileReader.ReadAll();

    // Clearing the old binding first stops rows from being duplicated.
    dgvAnimals.DataSource = null;
    dgvAnimals.DataSource = new BindingList<Animal>(result.Animals);
    dgvAnimals.ClearSelection();

    if (result.HasError)
    {
        MessageBox.Show(result.ErrorMessage, "File problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    else if (announceSkipped && result.SkippedLines > 0)
    {
        MessageBox.Show(result.SkippedLines + " invalid line(s) were skipped while loading animals.txt.",
            "Skipped lines", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

// In Form_Load:
// SetUpGrid();
// ReloadGrid(true);

*/
