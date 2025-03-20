namespace ProperDiet
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Registration = new System.Windows.Forms.Button();
            this.visiblePasswordCheck = new System.Windows.Forms.CheckBox();
            this.logButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(327, 254);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTextBox.MaxLength = 20;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(278, 29);
            this.nameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(327, 292);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.passwordTextBox.MaxLength = 20;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(278, 29);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 258);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 295);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пароль";
            // 
            // Registration
            // 
            this.Registration.BackColor = System.Drawing.Color.Black;
            this.Registration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Registration.Location = new System.Drawing.Point(260, 346);
            this.Registration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(184, 38);
            this.Registration.TabIndex = 6;
            this.Registration.Text = "Регистрация";
            this.Registration.UseVisualStyleBackColor = false;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // visiblePasswordCheck
            // 
            this.visiblePasswordCheck.AutoSize = true;
            this.visiblePasswordCheck.Checked = true;
            this.visiblePasswordCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visiblePasswordCheck.Location = new System.Drawing.Point(631, 294);
            this.visiblePasswordCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.visiblePasswordCheck.Name = "visiblePasswordCheck";
            this.visiblePasswordCheck.Size = new System.Drawing.Size(206, 25);
            this.visiblePasswordCheck.TabIndex = 7;
            this.visiblePasswordCheck.Text = "Показать\\скрыть пароль";
            this.visiblePasswordCheck.UseVisualStyleBackColor = true;
            this.visiblePasswordCheck.CheckedChanged += new System.EventHandler(this.VisiblePasswordCheck_CheckedChanged);
            // 
            // logButton
            // 
            this.logButton.BackColor = System.Drawing.Color.Black;
            this.logButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logButton.Location = new System.Drawing.Point(474, 346);
            this.logButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(184, 38);
            this.logButton.TabIndex = 8;
            this.logButton.Text = "Вход?";
            this.logButton.UseVisualStyleBackColor = false;
            this.logButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(910, 531);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.visiblePasswordCheck);
            this.Controls.Add(this.Registration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Snow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximumSize = new System.Drawing.Size(946, 597);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistrationForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Registration;
        private System.Windows.Forms.CheckBox visiblePasswordCheck;
        private System.Windows.Forms.Button logButton;
    }
}