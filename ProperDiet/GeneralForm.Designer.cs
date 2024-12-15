namespace ProperDiet
{
    partial class GeneralForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralForm));
            this.sidebarContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.maxCalories = new System.Windows.Forms.Label();
            this.NameUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PagePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.menuButton = new System.Windows.Forms.PictureBox();
            this.homeButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.addFoodButton = new System.Windows.Forms.Button();
            this.addFoodCategoryButton = new System.Windows.Forms.Button();
            this.foodCategoryButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.sidebarContainer.SuspendLayout();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarContainer
            // 
            this.sidebarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(27)))), ((int)(((byte)(50)))));
            this.sidebarContainer.Controls.Add(this.menuPanel);
            this.sidebarContainer.Controls.Add(this.homeButton);
            this.sidebarContainer.Controls.Add(this.settingsButton);
            this.sidebarContainer.Controls.Add(this.panel2);
            this.sidebarContainer.Controls.Add(this.addFoodButton);
            this.sidebarContainer.Controls.Add(this.addFoodCategoryButton);
            this.sidebarContainer.Controls.Add(this.foodCategoryButton);
            this.sidebarContainer.Controls.Add(this.panel3);
            this.sidebarContainer.Controls.Add(this.helpButton);
            this.sidebarContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarContainer.Location = new System.Drawing.Point(0, 0);
            this.sidebarContainer.Margin = new System.Windows.Forms.Padding(4);
            this.sidebarContainer.MaximumSize = new System.Drawing.Size(299, 0);
            this.sidebarContainer.MinimumSize = new System.Drawing.Size(50, 0);
            this.sidebarContainer.Name = "sidebarContainer";
            this.sidebarContainer.Size = new System.Drawing.Size(299, 623);
            this.sidebarContainer.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.maxCalories);
            this.menuPanel.Controls.Add(this.NameUser);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Controls.Add(this.menuButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(4, 4);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(4);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(317, 125);
            this.menuPanel.TabIndex = 0;
            // 
            // maxCalories
            // 
            this.maxCalories.AutoSize = true;
            this.maxCalories.Location = new System.Drawing.Point(8, 40);
            this.maxCalories.Name = "maxCalories";
            this.maxCalories.Size = new System.Drawing.Size(132, 16);
            this.maxCalories.TabIndex = 5;
            this.maxCalories.Text = "Максимум калорий";
            // 
            // NameUser
            // 
            this.NameUser.AutoSize = true;
            this.NameUser.Location = new System.Drawing.Point(8, 5);
            this.NameUser.Name = "NameUser";
            this.NameUser.Size = new System.Drawing.Size(96, 16);
            this.NameUser.TabIndex = 3;
            this.NameUser.Text = "Неизвестный";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(56, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Меню";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.panel2.Location = new System.Drawing.Point(4, 283);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 12);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.panel3.Location = new System.Drawing.Point(4, 522);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(312, 12);
            this.panel3.TabIndex = 8;
            // 
            // PagePanel
            // 
            this.PagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagePanel.Location = new System.Drawing.Point(299, 0);
            this.PagePanel.Margin = new System.Windows.Forms.Padding(4);
            this.PagePanel.MinimumSize = new System.Drawing.Size(852, 628);
            this.PagePanel.Name = "PagePanel";
            this.PagePanel.Size = new System.Drawing.Size(852, 628);
            this.PagePanel.TabIndex = 1;
            // 
            // menuButton
            // 
            this.menuButton.BackgroundImage = global::ProperDiet.Properties.Resources.icons8_menu_25;
            this.menuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButton.Location = new System.Drawing.Point(4, 71);
            this.menuButton.Margin = new System.Windows.Forms.Padding(4);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(44, 37);
            this.menuButton.TabIndex = 0;
            this.menuButton.TabStop = false;
            this.menuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeButton.ForeColor = System.Drawing.Color.LightGray;
            this.homeButton.Image = global::ProperDiet.Properties.Resources.icons8_home_25;
            this.homeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeButton.Location = new System.Drawing.Point(4, 137);
            this.homeButton.Margin = new System.Windows.Forms.Padding(4);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(299, 65);
            this.homeButton.TabIndex = 0;
            this.homeButton.Text = "          Дом";
            this.homeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.LightGray;
            this.settingsButton.Image = global::ProperDiet.Properties.Resources.icons8_settings_25;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(4, 210);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(299, 65);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "          Настройки";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // addFoodButton
            // 
            this.addFoodButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addFoodButton.FlatAppearance.BorderSize = 0;
            this.addFoodButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFoodButton.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFoodButton.ForeColor = System.Drawing.Color.LightGray;
            this.addFoodButton.Image = global::ProperDiet.Properties.Resources.icons8_eat_25;
            this.addFoodButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addFoodButton.Location = new System.Drawing.Point(4, 303);
            this.addFoodButton.Margin = new System.Windows.Forms.Padding(4);
            this.addFoodButton.Name = "addFoodButton";
            this.addFoodButton.Size = new System.Drawing.Size(299, 65);
            this.addFoodButton.TabIndex = 3;
            this.addFoodButton.Text = "          Добавить еду";
            this.addFoodButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addFoodButton.UseVisualStyleBackColor = true;
            this.addFoodButton.Click += new System.EventHandler(this.AddFoodButton_Click);
            // 
            // addFoodCategoryButton
            // 
            this.addFoodCategoryButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addFoodCategoryButton.FlatAppearance.BorderSize = 0;
            this.addFoodCategoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFoodCategoryButton.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFoodCategoryButton.ForeColor = System.Drawing.Color.LightGray;
            this.addFoodCategoryButton.Image = global::ProperDiet.Properties.Resources.icons8_add_25;
            this.addFoodCategoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addFoodCategoryButton.Location = new System.Drawing.Point(4, 376);
            this.addFoodCategoryButton.Margin = new System.Windows.Forms.Padding(4);
            this.addFoodCategoryButton.Name = "addFoodCategoryButton";
            this.addFoodCategoryButton.Size = new System.Drawing.Size(299, 65);
            this.addFoodCategoryButton.TabIndex = 4;
            this.addFoodCategoryButton.Text = "          Добавить категорию";
            this.addFoodCategoryButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addFoodCategoryButton.UseVisualStyleBackColor = true;
            this.addFoodCategoryButton.Click += new System.EventHandler(this.AddFoodCategoryButton_Click);
            // 
            // foodCategoryButton
            // 
            this.foodCategoryButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.foodCategoryButton.FlatAppearance.BorderSize = 0;
            this.foodCategoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodCategoryButton.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodCategoryButton.ForeColor = System.Drawing.Color.LightGray;
            this.foodCategoryButton.Image = global::ProperDiet.Properties.Resources.icons8_category_25;
            this.foodCategoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.foodCategoryButton.Location = new System.Drawing.Point(4, 449);
            this.foodCategoryButton.Margin = new System.Windows.Forms.Padding(4);
            this.foodCategoryButton.Name = "foodCategoryButton";
            this.foodCategoryButton.Size = new System.Drawing.Size(299, 65);
            this.foodCategoryButton.TabIndex = 7;
            this.foodCategoryButton.Text = "          Категории";
            this.foodCategoryButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.foodCategoryButton.UseVisualStyleBackColor = true;
            this.foodCategoryButton.Click += new System.EventHandler(this.FoodCategoryButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.helpButton.FlatAppearance.BorderSize = 0;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.ForeColor = System.Drawing.Color.LightGray;
            this.helpButton.Image = global::ProperDiet.Properties.Resources.icons8_help_25;
            this.helpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpButton.Location = new System.Drawing.Point(4, 542);
            this.helpButton.Margin = new System.Windows.Forms.Padding(4);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(299, 65);
            this.helpButton.TabIndex = 9;
            this.helpButton.Text = "          Помощь";
            this.helpButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1151, 623);
            this.Controls.Add(this.PagePanel);
            this.Controls.Add(this.sidebarContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GeneralForm";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сборник";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneralForm_FormClosed);
            this.Load += new System.EventHandler(this.GeneralForm_Load);
            this.sidebarContainer.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel sidebarContainer;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox menuButton;
        private System.Windows.Forms.Button foodCategoryButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel PagePanel;
        private System.Windows.Forms.Button addFoodButton;
        private System.Windows.Forms.Button addFoodCategoryButton;
        private System.Windows.Forms.Label NameUser;
        public System.Windows.Forms.Label maxCalories;
    }
}

