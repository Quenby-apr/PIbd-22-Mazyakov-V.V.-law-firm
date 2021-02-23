namespace LawFirm
{
    partial class FormWarehouseRefill
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
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.labelComponent = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxCount = new System.Windows.Forms.MaskedTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWarehouse
            // 
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Location = new System.Drawing.Point(13, 13);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(41, 13);
            this.labelWarehouse.TabIndex = 0;
            this.labelWarehouse.Text = "Склад:";
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(13, 56);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(66, 13);
            this.labelComponent.TabIndex = 1;
            this.labelComponent.Text = "Компонент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(13, 105);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество:";
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(101, 13);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(148, 21);
            this.comboBoxWarehouse.TabIndex = 3;
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(101, 56);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(148, 21);
            this.comboBoxComponent.TabIndex = 4;
            // 
            // maskedTextBoxCount
            // 
            this.maskedTextBoxCount.Location = new System.Drawing.Point(101, 102);
            this.maskedTextBoxCount.Mask = "00000000000";
            this.maskedTextBoxCount.Name = "maskedTextBoxCount";
            this.maskedTextBoxCount.Size = new System.Drawing.Size(73, 20);
            this.maskedTextBoxCount.TabIndex = 5;
            this.maskedTextBoxCount.ValidatingType = typeof(int);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(65, 155);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(159, 155);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormWarehouseRefill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 196);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.maskedTextBoxCount);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelComponent);
            this.Controls.Add(this.labelWarehouse);
            this.Name = "FormWarehouseRefill";
            this.Text = "Пополнение склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWarehouse;
        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCount;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}