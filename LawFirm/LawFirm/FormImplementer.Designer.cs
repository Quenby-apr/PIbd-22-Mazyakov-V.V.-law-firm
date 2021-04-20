namespace LawFirm
{
    partial class FormImplementer
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.textBoxPause = new System.Windows.Forms.TextBox();
            this.labelpause = new System.Windows.Forms.Label();
            this.textBoxOrder = new System.Windows.Forms.TextBox();
            this.labelorder = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(215, 202);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 17;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(124, 202);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 16;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // textBoxPause
            // 
            this.textBoxPause.Location = new System.Drawing.Point(124, 141);
            this.textBoxPause.Name = "textBoxPause";
            this.textBoxPause.Size = new System.Drawing.Size(205, 20);
            this.textBoxPause.TabIndex = 15;
            // 
            // labelpause
            // 
            this.labelpause.AutoSize = true;
            this.labelpause.Location = new System.Drawing.Point(16, 144);
            this.labelpause.Name = "labelpause";
            this.labelpause.Size = new System.Drawing.Size(108, 13);
            this.labelpause.TabIndex = 14;
            this.labelpause.Text = "Время на перерыв :";
            // 
            // textBoxOrder
            // 
            this.textBoxOrder.Location = new System.Drawing.Point(124, 72);
            this.textBoxOrder.Name = "textBoxOrder";
            this.textBoxOrder.Size = new System.Drawing.Size(205, 20);
            this.textBoxOrder.TabIndex = 13;
            // 
            // labelorder
            // 
            this.labelorder.AutoSize = true;
            this.labelorder.Location = new System.Drawing.Point(16, 75);
            this.labelorder.Name = "labelorder";
            this.labelorder.Size = new System.Drawing.Size(94, 13);
            this.labelorder.TabIndex = 12;
            this.labelorder.Text = "Время на заказ :";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(124, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(205, 20);
            this.textBoxName.TabIndex = 11;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(108, 13);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "ФИО исполнителя :";
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 257);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.textBoxPause);
            this.Controls.Add(this.labelpause);
            this.Controls.Add(this.textBoxOrder);
            this.Controls.Add(this.labelorder);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "FormImplementer";
            this.Text = "FormImplementer";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.TextBox textBoxPause;
        private System.Windows.Forms.Label labelpause;
        private System.Windows.Forms.TextBox textBoxOrder;
        private System.Windows.Forms.Label labelorder;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
    }
}