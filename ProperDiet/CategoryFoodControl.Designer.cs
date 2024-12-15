namespace ProperDiet
{
    partial class CategoryFoodControl
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
            this.BlocksAdder = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // BlocksAdder
            // 
            this.BlocksAdder.AutoScroll = true;
            this.BlocksAdder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlocksAdder.Location = new System.Drawing.Point(0, 0);
            this.BlocksAdder.Name = "BlocksAdder";
            this.BlocksAdder.Size = new System.Drawing.Size(813, 517);
            this.BlocksAdder.TabIndex = 0;
            // 
            // CategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.BlocksAdder);
            this.Name = "CategoryControl";
            this.Size = new System.Drawing.Size(813, 517);
            this.Load += new System.EventHandler(this.CategoryControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel BlocksAdder;
    }
}
