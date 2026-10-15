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
    }
}