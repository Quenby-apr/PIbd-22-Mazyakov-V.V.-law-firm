using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LawFirmBusinessLogic.BusinessLogic;

namespace LawFirm
{
    public partial class FormMails : Form
    {
        private readonly MailLogic logic;
        public FormMails(MailLogic mailLogic)
        {
            logic = mailLogic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            var list = logic.Read(null);
            if (list != null)
            {
                dataGridViewMails.DataSource = list;
                dataGridViewMails.Columns[0].Visible = false;
                dataGridViewMails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewMails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewMails.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewMails.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
