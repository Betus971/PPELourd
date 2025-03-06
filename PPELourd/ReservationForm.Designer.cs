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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ButtonReservation = new Guna.UI2.WinForms.Guna2Button();
            ComboBoxEquipement = new Guna.UI2.WinForms.Guna2ComboBox();
            DateReservation = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            guna2ContextMenuStrip2 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            dashboardToolStripMenuItem1 = new ToolStripMenuItem();
            label1 = new Label();
            labelUtilisateur = new Label();
            guna2ContextMenuStrip1.SuspendLayout();
            guna2ContextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonReservation
            // 
            ButtonReservation.BorderRadius = 15;
            ButtonReservation.CustomizableEdges = customizableEdges13;
            ButtonReservation.DisabledState.BorderColor = Color.DarkGray;
            ButtonReservation.DisabledState.CustomBorderColor = Color.DarkGray;
            ButtonReservation.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            ButtonReservation.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            ButtonReservation.FillColor = Color.Red;
            ButtonReservation.Font = new Font("Segoe UI", 9F);
            ButtonReservation.ForeColor = Color.White;
            ButtonReservation.Location = new Point(319, 305);
            ButtonReservation.Name = "ButtonReservation";
            ButtonReservation.ShadowDecoration.CustomizableEdges = customizableEdges14;
            ButtonReservation.Size = new Size(200, 45);
            ButtonReservation.TabIndex = 0;
            ButtonReservation.Text = "Reservation";
            ButtonReservation.Click += ButtonReservation_Click;
            // 
            // ComboBoxEquipement
            // 
            ComboBoxEquipement.BackColor = Color.Transparent;
            ComboBoxEquipement.CustomizableEdges = customizableEdges15;
            ComboBoxEquipement.DrawMode = DrawMode.OwnerDrawFixed;
            ComboBoxEquipement.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxEquipement.FocusedColor = Color.FromArgb(94, 148, 255);
            ComboBoxEquipement.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            ComboBoxEquipement.Font = new Font("Segoe UI", 10F);
            ComboBoxEquipement.ForeColor = Color.FromArgb(68, 88, 112);
            ComboBoxEquipement.ItemHeight = 30;
            ComboBoxEquipement.Location = new Point(319, 217);
            ComboBoxEquipement.Name = "ComboBoxEquipement";
            ComboBoxEquipement.ShadowDecoration.CustomizableEdges = customizableEdges16;
            ComboBoxEquipement.Size = new Size(200, 36);
            ComboBoxEquipement.TabIndex = 1;
            // 
            // DateReservation
            // 
            DateReservation.Checked = true;
            DateReservation.CustomizableEdges = customizableEdges17;
            DateReservation.FillColor = Color.Navy;
            DateReservation.Font = new Font("Segoe UI", 9F);
            DateReservation.Format = DateTimePickerFormat.Long;
            DateReservation.Location = new Point(319, 109);
            DateReservation.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            DateReservation.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            DateReservation.Name = "DateReservation";
            DateReservation.ShadowDecoration.CustomizableEdges = customizableEdges18;
            DateReservation.Size = new Size(200, 36);
            DateReservation.TabIndex = 2;
            DateReservation.Value = new DateTime(2025, 3, 6, 18, 41, 18, 218);
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
            label1.Location = new Point(345, 182);
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
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}