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
    public partial class FormWarehouseRefill : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int WarehouseId
        {
            get
            {
                return Convert.ToInt32(comboBoxWarehouse.SelectedValue);
            }
            set
            {
                comboBoxWarehouse.SelectedValue = value;
            }
        }

        public int ComponentId
        {
            get
            {
                return Convert.ToInt32(comboBoxComponent.SelectedValue);
            }
            set
            {
                comboBoxComponent.SelectedValue = value;
            }
        }

        public int Count
        {
            get
            {
                return Convert.ToInt32(maskedTextBoxCount.Text);
            }
            set
            {
                maskedTextBoxCount.Text = value.ToString();
            }
        }

        private readonly WarehouseLogic warehouseLogic;

        public FormWarehouseRefill(ComponentLogic componentLogic, WarehouseLogic warehouseLogic)
        {
            InitializeComponent();

            this.warehouseLogic = warehouseLogic;

            List<ComponentViewModel> componentViews = componentLogic.Read(null);
            if (componentViews != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = componentViews;
                comboBoxComponent.SelectedItem = null;
            }

            List<WarehouseViewModel> warehouseViews = warehouseLogic.Read(null);
            if (warehouseViews != null)
            {
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                comboBoxWarehouse.DataSource = warehouseViews;
                comboBoxWarehouse.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            warehouseLogic.AddComponents(new ComponentForWarehouseBindingModel
            {
                ComponentId = Convert.ToInt32(comboBoxComponent.SelectedValue),
                WarehouseId = Convert.ToInt32(comboBoxWarehouse.SelectedValue),
                Count = Convert.ToInt32(maskedTextBoxCount.Text)
            });

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
