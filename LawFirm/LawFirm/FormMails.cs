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
using LawFirmBusinessLogic.ViewModels;
using LawFirmView;

namespace LawFirm
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;
        private PageViewModel pageViewModel;
        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData(int page = 1)
        {
            int pageSize = 5;
            var list = logic.GetMessagesForPage(new MessageInfoBindingModel
            {
                Page = page,
                PageSize = pageSize
            });
            textBoxNumberShow.Text = page.ToString();
            if (list != null)
            {
                pageViewModel = new PageViewModel(logic.Count(), page, pageSize, list);

                dataGridViewMails.DataSource = list;
                dataGridViewMails.Columns[0].Visible = false;
                dataGridViewMails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewMails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewMails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewMails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Program.ConfigGrid(logic.Read(null), dataGridViewMails);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void buttonPrev_Click_1(object sender, EventArgs e)
        {
            if (pageViewModel.HasPreviousPage)
            {
                LoadData(pageViewModel.PageNumber - 1);
            }
            else
            {

            }
        }

        private void buttonNext_Click_1(object sender, EventArgs e)
        {
            if (pageViewModel.HasNextPage)
            {
                LoadData(pageViewModel.PageNumber + 1);
            }
            else
            {

            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            LoadData(pageViewModel.PageNumber = Convert.ToInt32(textBoxNumber.Text));
        }
    }
}
