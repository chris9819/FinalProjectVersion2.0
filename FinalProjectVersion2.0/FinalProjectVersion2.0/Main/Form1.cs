using FinalProjectVersion2._0.Building_Classes;
using FinalProjectVersion2._0.Dictionary_Classes;
using FinalProjectVersion2._0.Main;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FinalProjectVersion2._0
{
    /// <summary>
    /// This class represents the winform.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// This method initializes the components of the form and sets the starting properties.
        /// </summary>
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

        /// <summary>
        /// This method activates when the user presses the go button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            new CreateFile().createFinalReportFile(finalReportDictionary);
            MessageBox.Show("You will find the report on your desktop");
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
