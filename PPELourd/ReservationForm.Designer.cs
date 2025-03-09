namespace PPELourd
{
    partial class ReservationForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ButtonReservation = new Guna.UI2.WinForms.Guna2Button();
            ComboBoxEquipement = new Guna.UI2.WinForms.Guna2ComboBox();
            DateReservation = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            dashboardToolStripMenuItem1 = new ToolStripMenuItem();
            label1 = new Label();
            labelUtilisateur = new Label();
            guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            ComboBoxCategorieEquipement = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2ContextMenuStrip1.SuspendLayout();
            guna2ContextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonReservation
            // 
            ButtonReservation.BorderRadius = 15;
            ButtonReservation.CustomizableEdges = customizableEdges1;
            ButtonReservation.DisabledState.BorderColor = Color.DarkGray;
            ButtonReservation.DisabledState.CustomBorderColor = Color.DarkGray;
            ButtonReservation.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ButtonReservation.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ButtonReservation.FillColor = Color.Red;
            ButtonReservation.Font = new Font("Segoe UI", 9F);
            ButtonReservation.ForeColor = Color.White;
            ButtonReservation.Location = new Point(319, 362);
            ButtonReservation.Name = "ButtonReservation";
            ButtonReservation.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ButtonReservation.Size = new Size(200, 45);
            ButtonReservation.TabIndex = 0;
            ButtonReservation.Text = "Reservation";
            ButtonReservation.Click += ButtonReservation_Click;
            // 
            // ComboBoxEquipement
            // 
            ComboBoxEquipement.BackColor = Color.Transparent;
            ComboBoxEquipement.CustomizableEdges = customizableEdges3;
            ComboBoxEquipement.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBoxEquipement.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxEquipement.FocusedColor = Color.FromArgb(94, 148, 255);
            ComboBoxEquipement.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ComboBoxEquipement.Font = new Font("Segoe UI", 10F);
            ComboBoxEquipement.ForeColor = Color.FromArgb(68, 88, 112);
            ComboBoxEquipement.ItemHeight = 30;
            ComboBoxEquipement.Location = new Point(319, 250);
            ComboBoxEquipement.Name = "ComboBoxEquipement";
            ComboBoxEquipement.ShadowDecoration.CustomizableEdges = customizableEdges4;
            ComboBoxEquipement.Size = new Size(200, 36);
            ComboBoxEquipement.TabIndex = 1;
            ComboBoxEquipement.SelectedIndexChanged += ComboBoxEquipement_SelectedIndexChanged;
            // 
            // DateReservation
            // 
            DateReservation.Checked = true;
            DateReservation.CustomizableEdges = customizableEdges5;
            DateReservation.FillColor = Color.Navy;
            DateReservation.Font = new Font("Segoe UI", 9F);
            DateReservation.Format = DateTimePickerFormat.Long;
            DateReservation.Location = new Point(319, 20);
            DateReservation.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            DateReservation.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            DateReservation.Name = "DateReservation";
            DateReservation.ShadowDecoration.CustomizableEdges = customizableEdges6;
            DateReservation.Size = new Size(200, 36);
            DateReservation.TabIndex = 2;
            DateReservation.Value = new DateTime(2025, 3, 6, 18, 41, 18, 218);
            DateReservation.ValueChanged += DateReservation_ValueChanged;
            // 
            // guna2ContextMenuStrip1
            // 
            guna2ContextMenuStrip1.Items.AddRange(new ToolStripItem[] { dashboardToolStripMenuItem });
            guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            guna2ContextMenuStrip1.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            guna2ContextMenuStrip1.RenderStyle.BorderColor = Color.Gainsboro;
            guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = Color.White;
            guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = Color.White;
            guna2ContextMenuStrip1.RenderStyle.SeparatorColor = Color.Gainsboro;
            guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            guna2ContextMenuStrip1.Size = new Size(132, 26);
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(131, 22);
            dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // guna2ContextMenuStrip2
            // 
            guna2ContextMenuStrip2.Items.AddRange(new ToolStripItem[] { dashboardToolStripMenuItem1 });
            guna2ContextMenuStrip2.Name = "guna2ContextMenuStrip2";
            guna2ContextMenuStrip2.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            guna2ContextMenuStrip2.RenderStyle.BorderColor = Color.Gainsboro;
            guna2ContextMenuStrip2.RenderStyle.ColorTable = null;
            guna2ContextMenuStrip2.RenderStyle.RoundedEdges = true;
            guna2ContextMenuStrip2.RenderStyle.SelectionArrowColor = Color.White;
            guna2ContextMenuStrip2.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            guna2ContextMenuStrip2.RenderStyle.SelectionForeColor = Color.White;
            guna2ContextMenuStrip2.RenderStyle.SeparatorColor = Color.Gainsboro;
            guna2ContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            guna2ContextMenuStrip2.Size = new Size(132, 26);
            // 
            // dashboardToolStripMenuItem1
            // 
            dashboardToolStripMenuItem1.Name = "dashboardToolStripMenuItem1";
            dashboardToolStripMenuItem1.Size = new Size(131, 22);
            dashboardToolStripMenuItem1.Text = "Dashboard";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 250);
            label1.Name = "label1";
            label1.Size = new Size(143, 15);
            label1.TabIndex = 5;
            label1.Text = "choisissez un equipement";
            // 
            // labelUtilisateur
            // 
            labelUtilisateur.AutoSize = true;
            labelUtilisateur.Location = new Point(687, 20);
            labelUtilisateur.Name = "labelUtilisateur";
            labelUtilisateur.Size = new Size(0, 15);
            labelUtilisateur.TabIndex = 6;
            labelUtilisateur.Click += label2_Click;
            // 
            // guna2DateTimePicker1
            // 
            guna2DateTimePicker1.Checked = true;
            guna2DateTimePicker1.CustomizableEdges = customizableEdges7;
            guna2DateTimePicker1.Font = new Font("Segoe UI", 9F);
            guna2DateTimePicker1.Format = DateTimePickerFormat.Long;
            guna2DateTimePicker1.Location = new Point(319, 81);
            guna2DateTimePicker1.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            guna2DateTimePicker1.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            guna2DateTimePicker1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2DateTimePicker1.Size = new Size(200, 36);
            guna2DateTimePicker1.TabIndex = 7;
            guna2DateTimePicker1.Value = new DateTime(2025, 3, 9, 10, 18, 17, 44);
            guna2DateTimePicker1.ValueChanged += guna2DateTimePicker1_ValueChanged;
            // 
            // ComboBoxCategorieEquipement
            // 
            ComboBoxCategorieEquipement.BackColor = Color.Transparent;
            ComboBoxCategorieEquipement.CustomizableEdges = customizableEdges9;
            ComboBoxCategorieEquipement.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBoxCategorieEquipement.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxCategorieEquipement.FocusedColor = Color.FromArgb(94, 148, 255);
            ComboBoxCategorieEquipement.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ComboBoxCategorieEquipement.Font = new Font("Segoe UI", 10F);
            ComboBoxCategorieEquipement.ForeColor = Color.FromArgb(68, 88, 112);
            ComboBoxCategorieEquipement.ItemHeight = 30;
            ComboBoxCategorieEquipement.Location = new Point(319, 165);
            ComboBoxCategorieEquipement.Name = "ComboBoxCategorieEquipement";
            ComboBoxCategorieEquipement.ShadowDecoration.CustomizableEdges = customizableEdges10;
            ComboBoxCategorieEquipement.Size = new Size(200, 36);
            ComboBoxCategorieEquipement.TabIndex = 8;
            ComboBoxCategorieEquipement.SelectedIndexChanged += ComboBoxCategorieEquipement_SelectedIndexChanged;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 528);
            Controls.Add(ComboBoxCategorieEquipement);
            Controls.Add(guna2DateTimePicker1);
            Controls.Add(labelUtilisateur);
            Controls.Add(label1);
            Controls.Add(DateReservation);
            Controls.Add(ComboBoxEquipement);
            Controls.Add(ButtonReservation);
            Name = "ReservationForm";
            Text = "Reservation";
            guna2ContextMenuStrip1.ResumeLayout(false);
            guna2ContextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button ButtonReservation;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxEquipement;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateReservation;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private ToolStripMenuItem dashboardToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip2;
        private ToolStripMenuItem dashboardToolStripMenuItem1;
        private Label label1;
        private Label labelUtilisateur;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxCategorieEquipement;
    }
}