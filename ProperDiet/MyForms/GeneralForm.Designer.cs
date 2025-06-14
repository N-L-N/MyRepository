﻿namespace ProperDiet
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralForm));
            this.sidebarContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.maxCalories = new System.Windows.Forms.Label();
            this.NameUser = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.PictureBox();
            this.homeButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.foodCategoryButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.PagePanel = new System.Windows.Forms.Panel();
            this.calorieNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.sidebarContainer.SuspendLayout();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarContainer
            // 
            this.sidebarContainer.BackColor = System.Drawing.Color.Black;
            this.sidebarContainer.Controls.Add(this.menuPanel);
            this.sidebarContainer.Controls.Add(this.homeButton);
            this.sidebarContainer.Controls.Add(this.settingsButton);
            this.sidebarContainer.Controls.Add(this.foodCategoryButton);
            this.sidebarContainer.Controls.Add(this.helpButton);
            this.sidebarContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarContainer.Location = new System.Drawing.Point(0, 0);
            this.sidebarContainer.Margin = new System.Windows.Forms.Padding(4);
            this.sidebarContainer.MaximumSize = new System.Drawing.Size(299, 0);
            this.sidebarContainer.MinimumSize = new System.Drawing.Size(45, 0);
            this.sidebarContainer.Name = "sidebarContainer";
            this.sidebarContainer.Size = new System.Drawing.Size(299, 623);
            this.sidebarContainer.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.maxCalories);
            this.menuPanel.Controls.Add(this.NameUser);
            this.menuPanel.Controls.Add(this.menuButton);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuPanel.Location = new System.Drawing.Point(4, 4);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(4);
            this.menuPanel.MaximumSize = new System.Drawing.Size(317, 111);
            this.menuPanel.MinimumSize = new System.Drawing.Size(317, 46);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(317, 111);
            this.menuPanel.TabIndex = 0;
            // 
            // maxCalories
            // 
            this.maxCalories.AutoSize = true;
            this.maxCalories.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxCalories.ForeColor = System.Drawing.Color.Snow;
            this.maxCalories.Location = new System.Drawing.Point(3, 30);
            this.maxCalories.Name = "maxCalories";
            this.maxCalories.Size = new System.Drawing.Size(181, 25);
            this.maxCalories.TabIndex = 5;
            this.maxCalories.Text = "Максимум калорий";
            this.maxCalories.Click += new System.EventHandler(this.maxCalories_Click);
            // 
            // NameUser
            // 
            this.NameUser.AutoSize = true;
            this.NameUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameUser.ForeColor = System.Drawing.Color.Snow;
            this.NameUser.Location = new System.Drawing.Point(3, 5);
            this.NameUser.Name = "NameUser";
            this.NameUser.Size = new System.Drawing.Size(126, 25);
            this.NameUser.TabIndex = 3;
            this.NameUser.Text = "Неизвестный";
            // 
            // menuButton
            // 
            this.menuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.menuButton.BackgroundImage = global::ProperDiet.Properties.Resources.burger_white;
            this.menuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButton.Location = new System.Drawing.Point(4, 79);
            this.menuButton.Margin = new System.Windows.Forms.Padding(4);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(29, 28);
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
            this.homeButton.ForeColor = System.Drawing.Color.Snow;
            this.homeButton.Image = global::ProperDiet.Properties.Resources.home_white;
            this.homeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homeButton.Location = new System.Drawing.Point(4, 123);
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
            this.settingsButton.ForeColor = System.Drawing.Color.Snow;
            this.settingsButton.Image = global::ProperDiet.Properties.Resources.settings_white;
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(4, 196);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(4);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(299, 65);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "          Настройки";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // foodCategoryButton
            // 
            this.foodCategoryButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.foodCategoryButton.FlatAppearance.BorderSize = 0;
            this.foodCategoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodCategoryButton.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodCategoryButton.ForeColor = System.Drawing.Color.Snow;
            this.foodCategoryButton.Image = global::ProperDiet.Properties.Resources.food_white;
            this.foodCategoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.foodCategoryButton.Location = new System.Drawing.Point(4, 269);
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
            this.helpButton.ForeColor = System.Drawing.Color.Snow;
            this.helpButton.Image = global::ProperDiet.Properties.Resources.help_white;
            this.helpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpButton.Location = new System.Drawing.Point(4, 342);
            this.helpButton.Margin = new System.Windows.Forms.Padding(4);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(299, 65);
            this.helpButton.TabIndex = 9;
            this.helpButton.Text = "          Помощь";
            this.helpButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // PagePanel
            // 
            this.PagePanel.BackColor = System.Drawing.Color.Black;
            this.PagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagePanel.ForeColor = System.Drawing.Color.Snow;
            this.PagePanel.Location = new System.Drawing.Point(299, 0);
            this.PagePanel.Name = "PagePanel";
            this.PagePanel.Size = new System.Drawing.Size(852, 623);
            this.PagePanel.TabIndex = 1;
            this.PagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PagePanel_Paint);
            // 
            // calorieNotifyIcon
            // 
            this.calorieNotifyIcon.Text = "notifyIcon1";
            this.calorieNotifyIcon.Visible = true;
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
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
        private System.Windows.Forms.PictureBox menuButton;
        private System.Windows.Forms.Button foodCategoryButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label NameUser;
        public System.Windows.Forms.Label maxCalories;
        private System.Windows.Forms.Panel PagePanel;
        private System.Windows.Forms.NotifyIcon calorieNotifyIcon;
    }
}

