﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace SZI
{
    /// <summary>
    /// Klasa obsługująca podstawowe ukazujące się okno.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// PrintPreviewDialog związany z generowanymi raportami.
        /// </summary>
        private PrintPreviewDialog printPreviewDialog;

        /// <summary>
        /// Konstruktor formy.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Okno pozwalajace na obsługę odczytów.
        /// </summary>
        /// <param name="sender">Obiekt eventu.</param>
        /// <param name="e">Argument eventu.</param>
        private void btCounters_Click(object sender, EventArgs e)
        {
            var countersForm = new CountersForm();
            countersForm.ShowDialog();
        }

        /// <summary>
        /// Okno obsługi ustawień aplikacji.
        /// </summary>
        /// <param name="sender">Obiekt eventu.</param>
        /// <param name="e">Argument eventu.</param>
        private void btConfig_Click(object sender, EventArgs e)
        {
            var configurationForm = new ConfigurationForm();
            configurationForm.ShowDialog();
        }

        /// <summary>
        /// Okno pomocy.
        /// </summary>
        /// <param name="sender">Obiekt eventu.</param>
        /// <param name="e">Argument eventu.</param>
        private void btHelp_Click(object sender, EventArgs e)
        {
            var helpForm = new HelpForm();
            helpForm.ShowDialog();
        }

        /// <summary>
        /// Okno zarządzania danymi ( Inkasenci, Tereny, Adresy, Klienci, Liczniki ).
        /// </summary>
        /// <param name="sender">Obiekt eventu.</param>
        /// <param name="e">Argument eventu.</param>
        private void btDataManagement_Click(object sender, EventArgs e)
        {
            var configManagementForm = new ConfigManagementForm();
            configManagementForm.ShowDialog();
        }

        /// <summary>
        /// Zamykanie aplikacji.
        /// </summary>
        /// <param name="sender">Obiekt eventu.</param>
        /// <param name="e">Argument eventu.</param>
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Edytor plików XML wygenerowanych przez aplikację.
        /// </summary>
        /// <param name="sender">Obiekt eventu.</param>
        /// <param name="e">Argument eventu.</param>
        private void btXMLTextEditor_Click(object sender, EventArgs e)
        {
            var XMLTextEditorForm = new XMLTextEditor();
            XMLTextEditorForm.ShowDialog();
        }

        /// <summary>
        /// Event handler dla itemu z ToolStripMenu wywołujący metodę tworząca raport inkasentów.
        /// </summary>
        /// <param name="sender">Item z ToolStripMenu wywołujący metodę.</param>
        /// <param name="e">Parametry zdarzenia.</param>
        private void inkasenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog = Reports.Collectors.CreateReport();
            try
            {
                printPreviewDialog.Show();
            }
            catch(InvalidPrinterException ex)
            {
                ExceptionHandling.ShowException(ex);
            }
        }

        /// <summary>
        /// Event handler dla itemu z ToolStripMenu wywołujący metodę tworząca raport klientów.
        /// </summary>
        /// <param name="sender">Item z ToolStripMenu wywołujący metodę.</param>
        /// <param name="e">Parametry zdarzenia.</param>
        private void klienciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog = Reports.Customers.CreateReport();
            try
            {
                printPreviewDialog.Show();
            }
            catch(InvalidPrinterException ex)
            {
                ExceptionHandling.ShowException(ex);
            }
        }
    }
}
