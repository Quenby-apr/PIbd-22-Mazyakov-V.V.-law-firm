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
using LawFirmBusinessLogic.BusinessLogics;
using LawFirmBusinessLogic.ViewModels;
using Unity;

namespace LawFirmView
{
    public partial class FormDocument : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly DocumentLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> documentComponents;
        public FormDocument(DocumentLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormDocument_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DocumentViewModel view = logic.Read(new DocumentBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.DocumentName;
                        textBoxPrice.Text = view.Price.ToString();
                        documentComponents = view.DocumentComponents;
                        LoadData();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                documentComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (documentComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var dc in documentComponents)
                    {
                        dataGridView.Rows.Add(new object[]
                        {
                            dc.Key, dc.Value.Item1, dc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDocumentComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (documentComponents.ContainsKey(form.Id))
                {
                    documentComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    documentComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormDocumentComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = documentComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    documentComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        documentComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (documentComponents == null || documentComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new DocumentBindingModel
                {
                    Id = id,
                    DocumentName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    DocumentComponents = documentComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

