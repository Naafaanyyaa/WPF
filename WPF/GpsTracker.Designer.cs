namespace WPF
{
    partial class GpsTracker
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.UpdatePoint = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpdatePoint
            // 
            this.UpdatePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.UpdatePoint.Location = new System.Drawing.Point(12, 281);
            this.UpdatePoint.Name = "UpdatePoint";
            this.UpdatePoint.Size = new System.Drawing.Size(284, 81);
            this.UpdatePoint.TabIndex = 0;
            this.UpdatePoint.Text = "Send info";
            this.UpdatePoint.UseVisualStyleBackColor = true;
            this.UpdatePoint.Click += new System.EventHandler(this.UpdatePoint_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(12, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(619, 263);
            this.propertyGrid1.TabIndex = 1;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.info.Location = new System.Drawing.Point(347, 281);
            this.info.MinimumSize = new System.Drawing.Size(284, 81);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(284, 81);
            this.info.TabIndex = 2;
            this.info.Text = "Sended";
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.info.Visible = false;
            // 
            // GpsTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 371);
            this.Controls.Add(this.info);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.UpdatePoint);
            this.Name = "GpsTracker";
            this.Text = "GpsTracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdatePoint;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label info;
    }
}

