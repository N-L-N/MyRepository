namespace ProperDiet
{
    partial class HomeControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mealEntryPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mealEntryPanel
            // 
            this.mealEntryPanel.AutoScroll = true;
            this.mealEntryPanel.BackColor = System.Drawing.Color.Black;
            this.mealEntryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mealEntryPanel.ForeColor = System.Drawing.Color.Snow;
            this.mealEntryPanel.Location = new System.Drawing.Point(0, 0);
            this.mealEntryPanel.Name = "mealEntryPanel";
            this.mealEntryPanel.Size = new System.Drawing.Size(628, 355);
            this.mealEntryPanel.TabIndex = 9;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.mealEntryPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(628, 355);
            this.Load += new System.EventHandler(this.HomeControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel mealEntryPanel;
    }
}
