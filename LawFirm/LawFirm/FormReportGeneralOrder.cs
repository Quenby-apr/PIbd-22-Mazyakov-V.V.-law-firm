using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.BusinessLogic;
using Microsoft.Reporting.WinForms;
using Unity;

namespace LawFirm
{
    public partial class FormReportGeneralOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportGeneralOrder(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonSaveToPDF_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveOrdersInfoByDateToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
        }

        private void buttonForm_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetOrdersInfoByDate();

                ReportDataSource source = new ReportDataSource("DataSetOrdersByDate", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
