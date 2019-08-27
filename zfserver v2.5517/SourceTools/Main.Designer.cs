using System.Windows.Forms;

namespace SourceTools
{
    partial class Main
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
            this.listNPCs = new MetroFramework.Controls.MetroComboBox();
            this.lblSelectNPC = new MetroFramework.Controls.MetroLabel();
            this.panelNPC = new MetroFramework.Controls.MetroPanel();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.panelAction = new MetroFramework.Controls.MetroPanel();
            this.lblAction = new MetroFramework.Controls.MetroLabel();
            this.lblMainDialogText = new System.Windows.Forms.Label();
            this.panelNPC.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // listNPCs
            // 
            this.listNPCs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listNPCs.FormattingEnabled = true;
            this.listNPCs.ItemHeight = 23;
            this.listNPCs.Location = new System.Drawing.Point(9, 66);
            this.listNPCs.Name = "listNPCs";
            this.listNPCs.Size = new System.Drawing.Size(197, 29);
            this.listNPCs.TabIndex = 0;
            this.listNPCs.TabStop = false;
            this.listNPCs.UseSelectable = true;
            this.listNPCs.SelectedIndexChanged += new System.EventHandler(this.ListNPCs_SelectedIndexChanged);
            // 
            // lblSelectNPC
            // 
            this.lblSelectNPC.AutoSize = true;
            this.lblSelectNPC.Location = new System.Drawing.Point(9, 9);
            this.lblSelectNPC.Name = "lblSelectNPC";
            this.lblSelectNPC.Size = new System.Drawing.Size(85, 19);
            this.lblSelectNPC.TabIndex = 1;
            this.lblSelectNPC.Text = "Select a NPC";
            // 
            // panelNPC
            // 
            this.panelNPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNPC.Controls.Add(this.txtSearch);
            this.panelNPC.Controls.Add(this.lblSelectNPC);
            this.panelNPC.Controls.Add(this.listNPCs);
            this.panelNPC.HorizontalScrollbarBarColor = true;
            this.panelNPC.HorizontalScrollbarHighlightOnWheel = false;
            this.panelNPC.HorizontalScrollbarSize = 10;
            this.panelNPC.Location = new System.Drawing.Point(13, 63);
            this.panelNPC.Name = "panelNPC";
            this.panelNPC.Size = new System.Drawing.Size(215, 109);
            this.panelNPC.TabIndex = 2;
            this.panelNPC.VerticalScrollbarBarColor = true;
            this.panelNPC.VerticalScrollbarHighlightOnWheel = false;
            this.panelNPC.VerticalScrollbarSize = 10;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.CustomButton.Image = null;
            this.txtSearch.CustomButton.Location = new System.Drawing.Point(175, 1);
            this.txtSearch.CustomButton.Name = "";
            this.txtSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearch.CustomButton.TabIndex = 1;
            this.txtSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearch.CustomButton.UseSelectable = true;
            this.txtSearch.CustomButton.Visible = false;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(9, 37);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(197, 23);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.UseSelectable = true;
            this.txtSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);
            // 
            // panelAction
            // 
            this.panelAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAction.Controls.Add(this.lblMainDialogText);
            this.panelAction.Controls.Add(this.lblAction);
            this.panelAction.HorizontalScrollbarBarColor = true;
            this.panelAction.HorizontalScrollbarHighlightOnWheel = false;
            this.panelAction.HorizontalScrollbarSize = 10;
            this.panelAction.Location = new System.Drawing.Point(13, 193);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(488, 155);
            this.panelAction.TabIndex = 3;
            this.panelAction.VerticalScrollbarBarColor = true;
            this.panelAction.VerticalScrollbarHighlightOnWheel = false;
            this.panelAction.VerticalScrollbarSize = 10;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(9, 13);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(119, 19);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "Configure a Action";
            // 
            // lblMainDialogText
            // 
            this.lblMainDialogText.AutoSize = true;
            this.lblMainDialogText.Location = new System.Drawing.Point(13, 57);
            this.lblMainDialogText.Name = "lblMainDialogText";
            this.lblMainDialogText.Size = new System.Drawing.Size(105, 13);
            this.lblMainDialogText.TabIndex = 3;
            this.lblMainDialogText.Text = "Main dialog text here";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 371);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.panelNPC);
            this.Name = "Main";
            this.Text = "Source Tools - OpenConquerEmulator 5517";
            this.panelNPC.ResumeLayout(false);
            this.panelNPC.PerformLayout();
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox listNPCs;
        private MetroFramework.Controls.MetroLabel lblSelectNPC;
        private MetroFramework.Controls.MetroPanel panelNPC;
        private MetroFramework.Controls.MetroTextBox txtSearch;
        private MetroFramework.Controls.MetroPanel panelAction;
        private MetroFramework.Controls.MetroLabel lblAction;
        private Label lblMainDialogText;
    }
}