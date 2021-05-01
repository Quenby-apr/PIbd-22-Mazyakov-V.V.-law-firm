namespace LawFirm
{
    partial class FormReportGeneralOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonPDF = new System.Windows.Forms.Button();
            this.buttonForm = new System.Windows.Forms.Button();
            this.ReportOrdersByDateViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersByDateViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            reportDataSource1.Name = "DataSetGeneralOrders";
            reportDataSource1.Value = this.ReportOrdersByDateViewModelBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "LawFirm.ReportGeneralOders.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 50);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(939, 409);
            this.reportViewer.TabIndex = 13;
            // 
            // buttonPDF
            // 
            this.buttonPDF.Location = new System.Drawing.Point(466, 20);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(75, 23);
            this.buttonPDF.TabIndex = 12;
            this.buttonPDF.Text = "в PDF";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.buttonSaveToPDF_Click);
            // 
            // buttonForm
            // 
            this.buttonForm.Location = new System.Drawing.Point(262, 21);
            this.buttonForm.Name = "buttonForm";
            this.buttonForm.Size = new System.Drawing.Size(131, 23);
            this.buttonForm.TabIndex = 11;
            this.buttonForm.Text = "Сформировать";
            this.buttonForm.UseVisualStyleBackColor = true;
            this.buttonForm.Click += new System.EventHandler(this.buttonForm_Click);
            // 
            // FormReportGeneralOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 463);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonPDF);
            this.Controls.Add(this.buttonForm);
            this.Name = "FormReportGeneralOrder";
            this.Text = "Отчёт по заказам";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.Button buttonForm;
        private System.Windows.Forms.BindingSource ReportOrdersByDateViewModelBindingSource;
    }
}