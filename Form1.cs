using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boabab_ridge_wildlife_reserve
{
    public partial class Form1 : Form
    {
        private const string FileName = "animals.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeSummaryFeature();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string rawId = txtAnimalId.Text.Trim().ToUpper();
            string rawName = txtAnimalName.Text.Trim();
            string rawSpecies = txtSpecies.Text.Trim();
            string rawAge = txtAge.Text.Trim();
            string rawScore = txtRecoveryScore.Text.Trim();

            if (!System.Text.RegularExpressions.Regex.IsMatch(rawId, @"^WR-\d{4}$"))
            {
                MessageBox.Show("Animal ID must start with 'WR-' followed by exactly 4 digits (e.g., WR-0007).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalId.Focus();
                return;
            }

            if (IdExistsInFile(rawId))
            {
                MessageBox.Show($"Animal ID '{rawId}' already exists. IDs must be unique.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalId.Focus();
                return;
            }

            if (string.IsNullOrEmpty(rawName) || rawName.Length > 30 || rawName.Contains("|"))
            {
                MessageBox.Show("Name is required, must be between 1 and 30 characters, and cannot contain the pipe character '|'.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(rawSpecies) || rawSpecies.Length > 30 || rawSpecies.Contains("|"))
            {
                MessageBox.Show("Species is required, must be between 1 and 30 characters, and cannot contain the pipe character '|'.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecies.Focus();
                return;
            }

            if (!int.TryParse(rawAge, out int age) || age < 0 || age > 100)
            {
                MessageBox.Show("Age must be a whole number between 0 and 100.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return;
            }

            if (!int.TryParse(rawScore, out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Recovery Score must be a whole number between 0 and 100.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRecoveryScore.Focus();
                return;
            }

            try
            {
                Animal newAnimal = new Animal(rawId, rawName, rawSpecies, age, score);

                File.AppendAllText(FileName, newAnimal.ToFileString() + Environment.NewLine);

                MessageBox.Show($"Animal successfully added!\n\nStatus: {newAnimal.Status}\nHousing Unit: {newAnimal.HousingUnit}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputFields();
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"File error: {ioEx.Message}. Ensure the file is not open in another program.",
                    "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied: Cannot write to animals.txt. Check file permissions or read-only settings.",
                    "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IdExistsInFile(string targetId)
        {
            if (!File.Exists(FileName)) return false;

            try
            {
                foreach (var line in File.ReadLines(FileName))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split('|');
                    if (parts.Length > 0 && parts[0].Trim().Equals(targetId, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            catch { }

            return false;
        }

        private void ClearInputFields()
        {
            txtAnimalId.Clear();
            txtAnimalName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();
            txtAnimalId.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAnimals();
        }

        private void LoadAnimals()
        {
            try
            {
                if (!File.Exists(FileName))
                {
                    dgvAnimals.DataSource = null;
                    return;
                }

                List<Animal> animals = new List<Animal>();

                foreach (string line in File.ReadLines(FileName))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split('|');

                    if (parts.Length >= 5 &&
                        int.TryParse(parts[3], out int age) &&
                        int.TryParse(parts[4], out int score))
                    {
                        Animal animal = new Animal(
                            parts[0],
                            parts[1],
                            parts[2],
                            age,
                            score
                        );

                        animals.Add(animal);
                    }
                }

                dgvAnimals.DataSource = null;
                dgvAnimals.DataSource = animals;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not load animals: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvAnimals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvAnimals.Rows[e.RowIndex];

            txtAnimalId.Text = row.Cells["Id"].Value?.ToString();
            txtAnimalName.Text = row.Cells["Name"].Value?.ToString();
            txtSpecies.Text = row.Cells["Species"].Value?.ToString();
            txtAge.Text = row.Cells["Age"].Value?.ToString();
            txtRecoveryScore.Text = row.Cells["RecoveryScore"].Value?.ToString();

            // Do not allow the ID to be changed while editing.
            txtAnimalId.Enabled = false;

            btnSaveChanges.Enabled = true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string id = txtAnimalId.Text.Trim().ToUpper();
            string name = txtAnimalName.Text.Trim();
            string species = txtSpecies.Text.Trim();

            if (string.IsNullOrEmpty(name) ||
                name.Length > 30 ||
                name.Contains("|"))
            {
                MessageBox.Show(
                    "Name is required, must be between 1 and 30 characters, and cannot contain '|'.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(species) ||
                species.Length > 30 ||
                species.Contains("|"))
            {
                MessageBox.Show(
                    "Species is required, must be between 1 and 30 characters, and cannot contain '|'.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAge.Text.Trim(), out int age) ||
                age < 0 ||
                age > 100)
            {
                MessageBox.Show(
                    "Age must be a whole number between 0 and 100.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtRecoveryScore.Text.Trim(), out int score) ||
                score < 0 ||
                score > 100)
            {
                MessageBox.Show(
                    "Recovery Score must be a whole number between 0 and 100.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<string> lines = File.ReadAllLines(FileName).ToList();

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Split('|');

                    if (parts.Length > 0 &&
                        parts[0].Trim().Equals(
                            id,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        Animal updatedAnimal =
                            new Animal(id, name, species, age, score);

                        lines[i] = updatedAnimal.ToFileString();

                        File.WriteAllLines(FileName, lines);

                        MessageBox.Show(
                            "Animal successfully updated!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        ClearEditMode();
                        LoadAnimals();
                        return;
                    }
                }

                MessageBox.Show(
                    "Animal could not be found.",
                    "Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not update animal: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtAnimalId.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show(
                    "Select an animal to delete.",
                    "Delete Animal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show(
                $"Are you sure you want to delete animal {id}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
                return;

            try
            {
                List<string> lines = File.ReadAllLines(FileName).ToList();

                int removed = lines.RemoveAll(line =>
                {
                    if (string.IsNullOrWhiteSpace(line))
                        return false;

                    string[] parts = line.Split('|');

                    return parts.Length > 0 &&
                           parts[0].Trim().Equals(
                               id,
                               StringComparison.OrdinalIgnoreCase);
                });

                if (removed == 0)
                {
                    MessageBox.Show(
                        "Animal could not be found.",
                        "Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                File.WriteAllLines(FileName, lines);

                MessageBox.Show(
                    "Animal successfully deleted!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearEditMode();
                LoadAnimals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not delete animal: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchId = txtSearchId.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(searchId))
            {
                LoadAnimals();
                return;
            }

            foreach (DataGridViewRow row in dgvAnimals.Rows)
            {
                if (row.Cells["Id"].Value != null &&
                    row.Cells["Id"].Value.ToString()
                        .Equals(searchId, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;

                    dgvAnimals.CurrentCell = row.Cells["Id"];

                    return;
                }
            }

            MessageBox.Show(
                $"Animal '{searchId}' was not found.",
                "Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearEditMode();
        }

        private void ClearEditMode()
        {
            ClearInputFields();

            txtAnimalId.Enabled = true;
            btnSaveChanges.Enabled = false;

            dgvAnimals.ClearSelection();
        }
    }
}
