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

