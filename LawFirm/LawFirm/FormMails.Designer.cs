namespace LawFirm
{
    partial class FormMails
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
            this.dataGridViewMails = new System.Windows.Forms.DataGridView();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.textBoxNumberShow = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMails
            // 
            this.dataGridViewMails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewMails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMails.Location = new System.Drawing.Point(2, 4);
            this.dataGridViewMails.Name = "dataGridViewMails";
            this.dataGridViewMails.Size = new System.Drawing.Size(1044, 394);
            this.dataGridViewMails.TabIndex = 0;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(564, 416);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(130, 23);
            this.buttonPrev.TabIndex = 1;
            this.buttonPrev.Text = "Предыдущая";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click_1);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(753, 416);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(124, 23);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Следующая";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click_1);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(148, 421);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(58, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Страница:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(221, 418);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(50, 20);
            this.textBoxNumber.TabIndex = 4;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(321, 416);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(92, 23);
            this.buttonEnter.TabIndex = 5;
            this.buttonEnter.Text = "Перейти";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // textBoxNumberShow
            // 
            this.textBoxNumberShow.Location = new System.Drawing.Point(27, 419);
            this.textBoxNumberShow.Name = "textBoxNumberShow";
            this.textBoxNumberShow.ReadOnly = true;
            this.textBoxNumberShow.Size = new System.Drawing.Size(50, 20);
            this.textBoxNumberShow.TabIndex = 6;
            // 
            // FormMails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 450);
            this.Controls.Add(this.textBoxNumberShow);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.dataGridViewMails);
            this.Name = "FormMails";
            this.Text = "Сообщения";
            this.Load += new System.EventHandler(this.FormMails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMails;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.TextBox textBoxNumberShow;
    }
}