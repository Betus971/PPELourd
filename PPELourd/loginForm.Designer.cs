namespace PPELourd
{
    partial class loginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            TextBoxPseudo = new Guna.UI2.WinForms.Guna2TextBox();
            TextBoxMdp = new Guna.UI2.WinForms.Guna2TextBox();
            InscriptionButton = new Guna.UI2.WinForms.Guna2Button();
            labelPseudo = new Label();
            labelMdp = new Label();
            ButtonLogin = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // TextBoxPseudo
            // 
            TextBoxPseudo.CustomizableEdges = customizableEdges9;
            TextBoxPseudo.DefaultText = "";
            TextBoxPseudo.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TextBoxPseudo.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TextBoxPseudo.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TextBoxPseudo.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TextBoxPseudo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBoxPseudo.Font = new Font("Segoe UI", 9F);
            TextBoxPseudo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBoxPseudo.Location = new Point(290, 120);
            TextBoxPseudo.Name = "TextBoxPseudo";
            TextBoxPseudo.PlaceholderText = "";
            TextBoxPseudo.SelectedText = "";
            TextBoxPseudo.ShadowDecoration.CustomizableEdges = customizableEdges10;
            TextBoxPseudo.Size = new Size(200, 36);
            TextBoxPseudo.TabIndex = 2;
            // 
            // TextBoxMdp
            // 
            TextBoxMdp.CustomizableEdges = customizableEdges11;
            TextBoxMdp.DefaultText = "";
            TextBoxMdp.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TextBoxMdp.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TextBoxMdp.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TextBoxMdp.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TextBoxMdp.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBoxMdp.Font = new Font("Segoe UI", 9F);
            TextBoxMdp.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TextBoxMdp.Location = new Point(290, 194);
            TextBoxMdp.Name = "TextBoxMdp";
            TextBoxMdp.PlaceholderText = "";
            TextBoxMdp.SelectedText = "";
            TextBoxMdp.ShadowDecoration.CustomizableEdges = customizableEdges12;
            TextBoxMdp.Size = new Size(200, 36);
            TextBoxMdp.TabIndex = 3;
            // 
            // InscriptionButton
            // 
            InscriptionButton.CustomizableEdges = customizableEdges13;
            InscriptionButton.DisabledState.BorderColor = Color.DarkGray;
            InscriptionButton.DisabledState.CustomBorderColor = Color.DarkGray;
            InscriptionButton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            InscriptionButton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            InscriptionButton.FillColor = Color.Red;
            InscriptionButton.Font = new Font("Segoe UI", 9F);
            InscriptionButton.ForeColor = Color.Black;
            InscriptionButton.Location = new Point(290, 359);
            InscriptionButton.Name = "InscriptionButton";
            InscriptionButton.ShadowDecoration.CustomizableEdges = customizableEdges14;
            InscriptionButton.Size = new Size(200, 45);
            InscriptionButton.TabIndex = 5;
            InscriptionButton.Text = "Inscription";
            InscriptionButton.Click += InscriptionButton_Click;
            // 
            // labelPseudo
            // 
            labelPseudo.AutoSize = true;
            labelPseudo.Location = new Point(290, 102);
            labelPseudo.Name = "labelPseudo";
            labelPseudo.Size = new Size(46, 15);
            labelPseudo.TabIndex = 8;
            labelPseudo.Text = "Pseudo";
            labelPseudo.TextAlign = ContentAlignment.BottomLeft;
            labelPseudo.Click += label2_Click;
            // 
            // labelMdp
            // 
            labelMdp.AutoSize = true;
            labelMdp.Location = new Point(290, 174);
            labelMdp.Name = "labelMdp";
            labelMdp.Size = new Size(82, 15);
            labelMdp.TabIndex = 9;
            labelMdp.Text = "Mots de Passe";
            labelMdp.Click += label3_Click;
            // 
            // ButtonLogin
            // 
            ButtonLogin.CustomizableEdges = customizableEdges15;
            ButtonLogin.DisabledState.BorderColor = Color.DarkGray;
            ButtonLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            ButtonLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ButtonLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ButtonLogin.FillColor = Color.FromArgb(0, 0, 64);
            ButtonLogin.Font = new Font("Segoe UI", 9F);
            ButtonLogin.ForeColor = Color.White;
            ButtonLogin.Location = new Point(290, 278);
            ButtonLogin.Name = "ButtonLogin";
            ButtonLogin.ShadowDecoration.CustomizableEdges = customizableEdges16;
            ButtonLogin.Size = new Size(200, 45);
            ButtonLogin.TabIndex = 10;
            ButtonLogin.Text = "Login";
            ButtonLogin.Click += ButtonLogin_Click;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 634);
            Controls.Add(ButtonLogin);
            Controls.Add(labelMdp);
            Controls.Add(labelPseudo);
            Controls.Add(InscriptionButton);
            Controls.Add(TextBoxMdp);
            Controls.Add(TextBoxPseudo);
            Name = "loginForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox TextBoxPseudo;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxMdp;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox5;
        private Guna.UI2.WinForms.Guna2Button InscriptionButton;
        private Label labelPseudo;
        private Label labelMdp;
        private Guna.UI2.WinForms.Guna2Button ButtonLogin;
        private Label label4;
    }
}
