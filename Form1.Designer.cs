namespace ConverteDBFtoXLS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFolderPath = new TextBox();
            btnSelectFolder = new Button();
            btnGenerateExcel = new Button();
            listBoxFiles = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnFechar = new Button();
            progressBar = new ProgressBar();
            labelGerando = new Label();
            SuspendLayout();
            // 
            // txtFolderPath
            // 
            txtFolderPath.Location = new Point(82, 66);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.Size = new Size(296, 23);
            txtFolderPath.TabIndex = 0;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new Point(384, 66);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(106, 23);
            btnSelectFolder.TabIndex = 1;
            btnSelectFolder.Text = "Selecionar Pasta";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // btnGenerateExcel
            // 
            btnGenerateExcel.Location = new Point(197, 437);
            btnGenerateExcel.Name = "btnGenerateExcel";
            btnGenerateExcel.Size = new Size(123, 45);
            btnGenerateExcel.TabIndex = 2;
            btnGenerateExcel.Text = "Gerar Excel";
            btnGenerateExcel.UseVisualStyleBackColor = true;
            btnGenerateExcel.Click += btnGenerateExcel_Click;
            // 
            // listBoxFiles
            // 
            listBoxFiles.BackColor = SystemColors.Info;
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new Point(20, 136);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(470, 229);
            listBoxFiles.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 69);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 4;
            label1.Text = "Caminho";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(197, 116);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 5;
            label2.Text = "Arquivos Encontrados";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(123, 9);
            label3.Name = "label3";
            label3.Size = new Size(276, 32);
            label3.TabIndex = 6;
            label3.Text = "Converte DBF para XLS";
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(475, 9);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(28, 23);
            btnFechar.TabIndex = 7;
            btnFechar.Text = "X";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(20, 403);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(470, 23);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 8;
            // 
            // labelGerando
            // 
            labelGerando.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelGerando.ForeColor = Color.Red;
            labelGerando.Location = new Point(20, 376);
            labelGerando.Name = "labelGerando";
            labelGerando.Size = new Size(470, 20);
            labelGerando.TabIndex = 9;
            labelGerando.Text = "Gerando, aguarde...";
            labelGerando.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(515, 492);
            Controls.Add(labelGerando);
            Controls.Add(progressBar);
            Controls.Add(btnFechar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxFiles);
            Controls.Add(btnGenerateExcel);
            Controls.Add(btnSelectFolder);
            Controls.Add(txtFolderPath);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFolderPath;
        private Button btnSelectFolder;
        private Button btnGenerateExcel;
        private ListBox listBoxFiles;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnFechar;
        private ProgressBar progressBar;
        private Label labelGerando;
    }
}
