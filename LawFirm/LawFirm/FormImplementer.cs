﻿using System;
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
using Unity;

namespace LawFirm
{
    public partial class FormImplementer : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            set { id = value; }
        }
        private readonly ImplementerLogic logic;
        private int? id;
        public FormImplementer(ImplementerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new ImplementerBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.ImplementerFIO;
                        textBoxWork.Text = view.WorkingTime.ToString();
                        textBoxPause.Text = view.PauseTime.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
                logic.CreateOrUpdate(new ImplementerBindingModel { 
                    Id = id, 
                    ImplementerFIO = textBoxName.Text,
                    WorkingTime = Convert.ToInt32(textBoxWork.Text),
                    PauseTime = Convert.ToInt32(textBoxPause.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; Close();
        }
    }
}
