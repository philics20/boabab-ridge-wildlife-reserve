using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BaobabRidge;

namespace boabab_ridge_wildlife_reserve
{
    public partial class Form1
    {
        private void InitializeSummaryFeature()
        {
            Button exportButton = new Button();
            exportButton.Text = "Export Summary";
            exportButton.AutoSize = true;
            exportButton.Location = new System.Drawing.Point(10, 10);
            exportButton.Click += btnExportSummary_Click;
            Controls.Add(exportButton);
            exportButton.BringToFront();
        }

        private List<Animal> ReadCurrentAnimals()
        {
            return AnimalFileReader.ReadAll().Animals;
        }

        private void btnExportSummary_Click(object sender, EventArgs e)

        {

            FileErrorHandler.TryRun("export the summary report", () =>

            {

                string report =

                    SummaryReport.Create(ReadCurrentAnimals());

                string path = Path.Combine(

                    AppDomain.CurrentDomain.BaseDirectory,

                    "summary.txt");

                File.WriteAllText(

                    path,

                    report,

                    new UTF8Encoding(false));

                MessageBox.Show(

                    "Summary saved successfully to:\n" + path,

                    "Export Complete",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Information);

            });

        }
    }
}
