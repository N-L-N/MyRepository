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
            this.infoPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.detailedInformationButton = new System.Windows.Forms.Button();
            this.calories = new System.Windows.Forms.Label();
            this.infoFood = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.button2);
            this.infoPanel.Controls.Add(this.button1);
            this.infoPanel.Controls.Add(this.detailedInformationButton);
            this.infoPanel.Controls.Add(this.calories);
            this.infoPanel.Controls.Add(this.infoFood);
            this.infoPanel.Controls.Add(this.Date);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.MaximumSize = new System.Drawing.Size(0, 300);
            this.infoPanel.MinimumSize = new System.Drawing.Size(0, 90);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(813, 90);
            this.infoPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::ProperDiet.Properties.Resources.icons8_add_96;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(774, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 26);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // detailedInformationButton
            // 
            this.detailedInformationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.detailedInformationButton.BackgroundImage = global::ProperDiet.Properties.Resources.icons8_collapse_arrow_100;
            this.detailedInformationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.detailedInformationButton.FlatAppearance.BorderSize = 0;
            this.detailedInformationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailedInformationButton.Location = new System.Drawing.Point(1570, 12);
            this.detailedInformationButton.Name = "detailedInformationButton";
            this.detailedInformationButton.Size = new System.Drawing.Size(25, 24);
            this.detailedInformationButton.TabIndex = 3;
            this.detailedInformationButton.UseVisualStyleBackColor = true;
            // 
            // calories
            // 
            this.calories.AutoSize = true;
            this.calories.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calories.ForeColor = System.Drawing.Color.LightGray;
            this.calories.Location = new System.Drawing.Point(416, 12);
            this.calories.Name = "calories";
            this.calories.Size = new System.Drawing.Size(68, 18);
            this.calories.TabIndex = 2;
            this.calories.Text = "Калории";
            // 
            // infoFood
            // 
            this.infoFood.AutoSize = true;
            this.infoFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoFood.ForeColor = System.Drawing.Color.LightGray;
            this.infoFood.Location = new System.Drawing.Point(13, 49);
            this.infoFood.Name = "infoFood";
            this.infoFood.Size = new System.Drawing.Size(155, 20);
            this.infoFood.TabIndex = 1;
            this.infoFood.Text = "Информация о еде";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Date.ForeColor = System.Drawing.Color.LightGray;
            this.Date.Location = new System.Drawing.Point(13, 12);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(87, 24);
            this.Date.TabIndex = 0;
            this.Date.Text = "Сегодня";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = global::ProperDiet.Properties.Resources.icons8_collapse_arrow_100;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(776, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 24);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.infoPanel);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(813, 517);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label calories;
        private System.Windows.Forms.Label infoFood;
        private System.Windows.Forms.Button detailedInformationButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
