using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using System.ComponentModel;

namespace ConverteDBFtoXLS
{
    public partial class Form1 : Form
    {
        private BackgroundWorker backgroundWorker;
        private List<bool> fileStatus;

        public Form1()
        {
            InitializeComponent();
            labelGerando.Visible = false;
            progressBar.Visible = false;

            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            listBoxFiles.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxFiles.DrawItem += ListBoxFiles_DrawItem;

            fileStatus = new List<bool>();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    txtFolderPath.Text = selectedPath;
                    listBoxFiles.Items.Clear();

                    var dbfFiles = Directory.GetFiles(selectedPath, "*.dbf");
                    listBoxFiles.Items.AddRange(dbfFiles);

                    fileStatus.Clear();
                    fileStatus.AddRange(Enumerable.Repeat(false, dbfFiles.Length));
                }
            }
        }

        private void btnGenerateExcel_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            labelGerando.Visible = true;
            btnGenerateExcel.Enabled = false;

            if (!backgroundWorker.IsBusy)
            {
                string folderPath = txtFolderPath.Text;

                if (string.IsNullOrEmpty(folderPath) || listBoxFiles.Items.Count == 0)
                {
                    MessageBox.Show("Selecione uma pasta que contenha arquivos DBF.");
                    return;
                }

                progressBar.Minimum = 0;
                progressBar.Maximum = listBoxFiles.Items.Count;
                progressBar.Value = 0;

                backgroundWorker.RunWorkerAsync(folderPath);
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string folderPath = (string)e.Argument;
            string excelFolderPath = Path.Combine(folderPath, "Excel");

            if (!Directory.Exists(excelFolderPath))
            {
                Directory.CreateDirectory(excelFolderPath);
            }

            string errorFilePath = Path.Combine(excelFolderPath, "Erros.txt");
            if (File.Exists(errorFilePath))
            {
                File.Delete(errorFilePath);
            }

            for (int i = 0; i < listBoxFiles.Items.Count; i++)
            {
                string dbfFilePath = listBoxFiles.Items[i].ToString();
                bool success = false;

                DataTable dataTable = ReadDBF(dbfFilePath, errorFilePath);
                if (dataTable != null)
                {
                    string excelFileName = Path.GetFileNameWithoutExtension(dbfFilePath) + ".xlsx";
                    string excelFilePath = Path.Combine(excelFolderPath, excelFileName);
                    try
                    {
                        GenerateExcel(dataTable, excelFilePath);
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        LogError(errorFilePath, $"Erro ao gerar Excel para {dbfFilePath}: {ex.Message}");
                        success = false;
                    }
                }

                fileStatus[i] = success;
                backgroundWorker.ReportProgress((i + 1) * 100 / listBoxFiles.Items.Count, i);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            int index = (int)e.UserState;
            listBoxFiles.Invalidate(listBoxFiles.GetItemRectangle(index));
            listBoxFiles.TopIndex = index;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelGerando.Text = "Arquivos Excel gerados com sucesso!";
            labelGerando.ForeColor = Color.SeaGreen;
            MessageBox.Show("Arquivos Excel gerados com sucesso na pasta 'Excel'!");
            btnGenerateExcel.Enabled = true;
        }

        private void ListBoxFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            bool success = fileStatus[e.Index];

            Color backgroundColor = success ? Color.LightGreen : Color.LightCoral;
            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            e.Graphics.DrawString(listBoxFiles.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }

        private DataTable ReadDBF(string filePath, string errorFilePath)
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.GetDirectoryName(filePath)};Extended Properties=dBase IV;";
            string query = $"SELECT * FROM {Path.GetFileName(filePath)}";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    LogError(errorFilePath, $"Erro ao ler DBF {filePath}: {ex.Message}");
                    return null;
                }
            }
        }

        private void GenerateExcel(DataTable dataTable, string filePath)
        {
            if (dataTable != null)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                FileInfo fileInfo = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                    }

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                        }
                    }

                    package.Save();
                }
            }
        }

        private void LogError(string filePath, string message)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
