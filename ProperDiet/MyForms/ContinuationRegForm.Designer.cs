namespace ProperDiet
{
    partial class ContinuationRegForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContinuationRegForm));
            this.ageNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.heightNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.weightNumeric = new System.Windows.Forms.NumericUpDown();
            this.categoryDietCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.regButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.GenderCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.activityList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.ageNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // ageNumeric
            // 
            this.ageNumeric.Location = new System.Drawing.Point(41, 49);
            this.ageNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ageNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ageNumeric.Minimum = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.ageNumeric.Name = "ageNumeric";
            this.ageNumeric.Size = new System.Drawing.Size(159, 29);
            this.ageNumeric.TabIndex = 0;
            this.ageNumeric.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сколько тебе лет";
            // 
            // heightNumeric
            // 
            this.heightNumeric.Location = new System.Drawing.Point(41, 129);
            this.heightNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.heightNumeric.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.heightNumeric.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.heightNumeric.Name = "heightNumeric";
            this.heightNumeric.Size = new System.Drawing.Size(159, 29);
            this.heightNumeric.TabIndex = 2;
            this.heightNumeric.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(37, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Рост";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(37, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вес";
            // 
            // weightNumeric
            // 
            this.weightNumeric.Location = new System.Drawing.Point(41, 212);
            this.weightNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.weightNumeric.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.weightNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.weightNumeric.Name = "weightNumeric";
            this.weightNumeric.Size = new System.Drawing.Size(159, 29);
            this.weightNumeric.TabIndex = 5;
            this.weightNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // categoryDietCombo
            // 
            this.categoryDietCombo.FormattingEnabled = true;
            this.categoryDietCombo.Items.AddRange(new object[] {
            "Понижение веса",
            "Повышение веса",
            "Умеренное питание"});
            this.categoryDietCombo.Location = new System.Drawing.Point(235, 49);
            this.categoryDietCombo.Name = "categoryDietCombo";
            this.categoryDietCombo.Size = new System.Drawing.Size(159, 29);
            this.categoryDietCombo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(231, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Категория диеты";
            // 
            // regButton
            // 
            this.regButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regButton.Location = new System.Drawing.Point(335, 232);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(159, 38);
            this.regButton.TabIndex = 8;
            this.regButton.Text = "Регистрация";
            this.regButton.UseVisualStyleBackColor = true;
            this.regButton.Click += new System.EventHandler(this.RegButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(231, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Пол";
            // 
            // GenderCombo
            // 
            this.GenderCombo.FormattingEnabled = true;
            this.GenderCombo.Items.AddRange(new object[] {
            "Мужской",
            "Женский"});
            this.GenderCombo.Location = new System.Drawing.Point(235, 129);
            this.GenderCombo.Name = "GenderCombo";
            this.GenderCombo.Size = new System.Drawing.Size(159, 29);
            this.GenderCombo.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(407, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Активность";
            // 
            // activityList
            // 
            this.activityList.BackColor = System.Drawing.Color.Black;
            this.activityList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activityList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.activityList.ForeColor = System.Drawing.Color.Snow;
            this.activityList.FormattingEnabled = true;
            this.activityList.ItemHeight = 17;
            this.activityList.Items.AddRange(new object[] {
            "Минимальная активность (сидячий образ жизни)",
            "Низкая активность (легкие упражнения 1-3 раза в неделю)",
            "Средняя активность (умеренные упражнения 3-5 раз в неделю)",
            "Высокая активность (интенсивные тренировки 6-7 раз в неделю)",
            "Очень высокая активность (интенсивные тренировки дважды в день)"});
            this.activityList.Location = new System.Drawing.Point(411, 49);
            this.activityList.Name = "activityList";
            this.activityList.Size = new System.Drawing.Size(458, 87);
            this.activityList.TabIndex = 13;
            // 
            // ContinuationRegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(880, 320);
            this.Controls.Add(this.activityList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GenderCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.regButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categoryDietCombo);
            this.Controls.Add(this.weightNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.heightNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ageNumeric);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Snow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(896, 359);
            this.Name = "ContinuationRegForm";
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.ageNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ageNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown heightNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown weightNumeric;
        private System.Windows.Forms.ComboBox categoryDietCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox GenderCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox activityList;
    }
}