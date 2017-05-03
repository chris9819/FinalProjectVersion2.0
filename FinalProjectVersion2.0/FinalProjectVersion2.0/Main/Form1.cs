using FinalProjectVersion2._0.Building_Classes;
using FinalProjectVersion2._0.Dictionary_Classes;
using OfficeOpenXml;
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

namespace FinalProjectVersion2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Define the border style of the form to a dialog box.
            FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void goButton_Click(object sender, EventArgs e)
        {
            terminatedLeasesPanel.BackColor = Color.LightGray;
            newLeasesPanel.BackColor = Color.LightGray;
            goButton.Enabled = false;
            goButton.Visible = false;
            // Create a dictionary object which relates to the first report.
            var terminatedLeaseExcelDictionary = new TerminatedLeaseReportDictionary().InitializeDictionary(new FileInfo(terminatedLeasesLabel.Text), 8);
            // Create a dictionary object which relates to the second report.
            var newLeaseExcelDictionary = new NewLeaseReportDictionary().InitializeDictionary(new FileInfo(newLeasesLabel.Text), 8);
            // Combine both of the reports.
            var finalReportDictionary = new FinalReportDictionary().CombineDictionaries(terminatedLeaseExcelDictionary, newLeaseExcelDictionary);
            createFinalReportFile(finalReportDictionary);
        }
        
        /// <summary>
        /// This method accepts a FileInfo object and dictionary then creates an excel report based on the information 
        /// </summary>
        public void createFinalReportFile(Dictionary<int, FinalReportBuilding> combinedExcelReport)
        {
            // Set the file name and get the output directory.
            var fileName = "FinalReport" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Create the file using the FileInfo object.
            var file = new FileInfo(path + "\\" + fileName).Create();
            using (var package = new ExcelPackage(file))
            {
                // Add headers.
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells[1, 1].Value = "Building Abbreviation";
                worksheet.Cells[1, 2].Value = "Old Rent Amount";
                worksheet.Cells[1, 3].Value = "New Rent Amount";
                worksheet.Cells[1, 4].Value = "% Change in Rent";
                int rowCount = 1;
                // Add data from dictionary
                foreach (var entry in combinedExcelReport)
                {
                    rowCount++;
                    worksheet.Cells[rowCount, 1].Value = entry.Value.BuildingAbbreviation;
                    worksheet.Cells[rowCount, 2].Value = entry.Value.OldRentAmount;
                    worksheet.Cells[rowCount, 3].Value = entry.Value.NewRentAmount;
                    worksheet.Cells[rowCount, 4].Value = entry.Value.DifferenceAmount;
                }
                worksheet.Cells[rowCount + 2, 4].Formula = "= AVERAGE(D2, D" + rowCount + ")";
                worksheet.Cells[rowCount + 2, 3].Value = "Avg change in rent";
                worksheet.Cells.AutoFitColumns();
                package.Save();
            }
        }

        /// <summary>
        /// This method handles the drag effects into the winform by giving it a "Copy" effect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// This method changes the panel color to green and changes the panel label to the file path of the dropped file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                if (filePaths.Length == 1)
                {
                    foreach (string fileLoc in filePaths)
                    {
                        if (sender == terminatedLeasesPanel)
                        {
                            terminatedLeasesLabel.Text = fileLoc;
                            terminatedLeasesPanel.BackColor = Color.Green;
                        }
                        if (sender == newLeasesPanel)
                        {
                            newLeasesLabel.Text = fileLoc;
                            newLeasesPanel.BackColor = Color.Green;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please drag and drop only one file at a time.");
                }
                if (terminatedLeasesPanel.BackColor == Color.Green && newLeasesPanel.BackColor == Color.Green)
                {
                    goButton.Visible = true;
                    goButton.Enabled = true;
                }
            }
        }

        private void instructionsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instructions: Drag and Drop the \"Terminated Leases Report\"and the \"New Leases Report\" in the corresponding" +
                " gray boxes. Click the Go button that appears, and look for the auto-generated report on your desktop.");
        }
    }
}
