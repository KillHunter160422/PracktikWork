namespace Practic19
{
    partial class Autorisation
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
            login = new TextBox();
            password = new TextBox();
            sign = new Button();
            SuspendLayout();
            // 
            // login
            // 
            login.Location = new Point(7, 8);
            login.Name = "login";
            login.Size = new Size(334, 23);
            login.TabIndex = 0;
            // 
            // password
            // 
            password.Location = new Point(7, 71);
            password.Name = "password";
            password.Size = new Size(334, 23);
            password.TabIndex = 1;
            // 
            // sign
            // 
            sign.Location = new Point(5, 122);
            sign.Name = "sign";
            sign.Size = new Size(75, 23);
            sign.TabIndex = 2;
            sign.Text = "Войти";
            sign.UseVisualStyleBackColor = true;
            sign.Click += sign_Click;
            // 
            // Autorisation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sign);
            Controls.Add(password);
            Controls.Add(login);
            Name = "Autorisation";
            Text = "Autorisation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox login;
        private TextBox password;
        private Button sign;
    }
}