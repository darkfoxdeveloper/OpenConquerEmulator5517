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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.listNPCs = new MetroFramework.Controls.MetroComboBox();
            this.lblSelectNPC = new MetroFramework.Controls.MetroLabel();
            this.panelNPC = new MetroFramework.Controls.MetroPanel();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.panelAction = new MetroFramework.Controls.MetroPanel();
            this.lblMainDialogText = new MetroFramework.Controls.MetroTextBox();
            this.lblAction5 = new System.Windows.Forms.Label();
            this.lblAction6 = new System.Windows.Forms.Label();
            this.lblAction3 = new System.Windows.Forms.Label();
            this.lblAction4 = new System.Windows.Forms.Label();
            this.lblAction2 = new System.Windows.Forms.Label();
            this.lblAction1 = new System.Windows.Forms.Label();
            this.lblSelectAction = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.txtSearchItems = new MetroFramework.Controls.MetroTextBox();
            this.lblItems = new MetroFramework.Controls.MetroLabel();
            this.listItems = new MetroFramework.Controls.MetroComboBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.lblSelectItem = new MetroFramework.Controls.MetroLabel();
            this.DynamicInputs = new MetroFramework.Controls.MetroLabel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.panelNPC.SuspendLayout();
            this.panelAction.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
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
            this.panelAction.Controls.Add(this.lblAction5);
            this.panelAction.Controls.Add(this.lblAction6);
            this.panelAction.Controls.Add(this.lblAction3);
            this.panelAction.Controls.Add(this.lblAction4);
            this.panelAction.Controls.Add(this.lblAction2);
            this.panelAction.Controls.Add(this.lblAction1);
            this.panelAction.Controls.Add(this.lblSelectAction);
            this.panelAction.HorizontalScrollbarBarColor = true;
            this.panelAction.HorizontalScrollbarHighlightOnWheel = false;
            this.panelAction.HorizontalScrollbarSize = 10;
            this.panelAction.Location = new System.Drawing.Point(13, 193);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(456, 199);
            this.panelAction.TabIndex = 3;
            this.panelAction.VerticalScrollbarBarColor = true;
            this.panelAction.VerticalScrollbarHighlightOnWheel = false;
            this.panelAction.VerticalScrollbarSize = 10;
            // 
            // lblMainDialogText
            // 
            // 
            // 
            // 
            this.lblMainDialogText.CustomButton.Image = null;
            this.lblMainDialogText.CustomButton.Location = new System.Drawing.Point(376, 2);
            this.lblMainDialogText.CustomButton.Name = "";
            this.lblMainDialogText.CustomButton.Size = new System.Drawing.Size(59, 59);
            this.lblMainDialogText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblMainDialogText.CustomButton.TabIndex = 1;
            this.lblMainDialogText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lblMainDialogText.CustomButton.UseSelectable = true;
            this.lblMainDialogText.CustomButton.Visible = false;
            this.lblMainDialogText.Lines = new string[] {
        "lblMainDialogText"};
            this.lblMainDialogText.Location = new System.Drawing.Point(9, 51);
            this.lblMainDialogText.MaxLength = 32767;
            this.lblMainDialogText.Multiline = true;
            this.lblMainDialogText.Name = "lblMainDialogText";
            this.lblMainDialogText.PasswordChar = '\0';
            this.lblMainDialogText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblMainDialogText.SelectedText = "";
            this.lblMainDialogText.SelectionLength = 0;
            this.lblMainDialogText.SelectionStart = 0;
            this.lblMainDialogText.ShortcutsEnabled = true;
            this.lblMainDialogText.Size = new System.Drawing.Size(438, 64);
            this.lblMainDialogText.TabIndex = 10;
            this.lblMainDialogText.Text = "lblMainDialogText";
            this.lblMainDialogText.UseSelectable = true;
            this.lblMainDialogText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.lblMainDialogText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblAction5
            // 
            this.lblAction5.AutoSize = true;
            this.lblAction5.Location = new System.Drawing.Point(187, 172);
            this.lblAction5.Name = "lblAction5";
            this.lblAction5.Size = new System.Drawing.Size(53, 13);
            this.lblAction5.TabIndex = 9;
            this.lblAction5.Text = "Action #5";
            this.lblAction5.Visible = false;
            this.lblAction5.Click += new System.EventHandler(this.LblActionLink_Click);
            // 
            // lblAction6
            // 
            this.lblAction6.AutoSize = true;
            this.lblAction6.Location = new System.Drawing.Point(367, 172);
            this.lblAction6.Name = "lblAction6";
            this.lblAction6.Size = new System.Drawing.Size(53, 13);
            this.lblAction6.TabIndex = 8;
            this.lblAction6.Text = "Action #6";
            this.lblAction6.Visible = false;
            this.lblAction6.Click += new System.EventHandler(this.LblActionLink_Click);
            // 
            // lblAction3
            // 
            this.lblAction3.AutoSize = true;
            this.lblAction3.Location = new System.Drawing.Point(367, 129);
            this.lblAction3.Name = "lblAction3";
            this.lblAction3.Size = new System.Drawing.Size(53, 13);
            this.lblAction3.TabIndex = 7;
            this.lblAction3.Text = "Action #3";
            this.lblAction3.Visible = false;
            this.lblAction3.Click += new System.EventHandler(this.LblActionLink_Click);
            // 
            // lblAction4
            // 
            this.lblAction4.AutoSize = true;
            this.lblAction4.Location = new System.Drawing.Point(20, 172);
            this.lblAction4.Name = "lblAction4";
            this.lblAction4.Size = new System.Drawing.Size(53, 13);
            this.lblAction4.TabIndex = 6;
            this.lblAction4.Text = "Action #4";
            this.lblAction4.Visible = false;
            this.lblAction4.Click += new System.EventHandler(this.LblActionLink_Click);
            // 
            // lblAction2
            // 
            this.lblAction2.AutoSize = true;
            this.lblAction2.Location = new System.Drawing.Point(187, 129);
            this.lblAction2.Name = "lblAction2";
            this.lblAction2.Size = new System.Drawing.Size(53, 13);
            this.lblAction2.TabIndex = 5;
            this.lblAction2.Text = "Action #2";
            this.lblAction2.Visible = false;
            this.lblAction2.Click += new System.EventHandler(this.LblActionLink_Click);
            // 
            // lblAction1
            // 
            this.lblAction1.AutoSize = true;
            this.lblAction1.Location = new System.Drawing.Point(20, 129);
            this.lblAction1.Name = "lblAction1";
            this.lblAction1.Size = new System.Drawing.Size(53, 13);
            this.lblAction1.TabIndex = 4;
            this.lblAction1.Text = "Action #1";
            this.lblAction1.Visible = false;
            this.lblAction1.Click += new System.EventHandler(this.LblActionLink_Click);
            // 
            // lblSelectAction
            // 
            this.lblSelectAction.AutoSize = true;
            this.lblSelectAction.Location = new System.Drawing.Point(9, 13);
            this.lblSelectAction.Name = "lblSelectAction";
            this.lblSelectAction.Size = new System.Drawing.Size(215, 19);
            this.lblSelectAction.TabIndex = 2;
            this.lblSelectAction.Text = "Configure a Action. Select any NPC";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.txtSearchItems);
            this.metroPanel1.Controls.Add(this.lblItems);
            this.metroPanel1.Controls.Add(this.listItems);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(254, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(215, 109);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // txtSearchItems
            // 
            // 
            // 
            // 
            this.txtSearchItems.CustomButton.Image = null;
            this.txtSearchItems.CustomButton.Location = new System.Drawing.Point(175, 1);
            this.txtSearchItems.CustomButton.Name = "";
            this.txtSearchItems.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearchItems.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearchItems.CustomButton.TabIndex = 1;
            this.txtSearchItems.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearchItems.CustomButton.UseSelectable = true;
            this.txtSearchItems.CustomButton.Visible = false;
            this.txtSearchItems.Lines = new string[0];
            this.txtSearchItems.Location = new System.Drawing.Point(9, 37);
            this.txtSearchItems.MaxLength = 32767;
            this.txtSearchItems.Name = "txtSearchItems";
            this.txtSearchItems.PasswordChar = '\0';
            this.txtSearchItems.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearchItems.SelectedText = "";
            this.txtSearchItems.SelectionLength = 0;
            this.txtSearchItems.SelectionStart = 0;
            this.txtSearchItems.ShortcutsEnabled = true;
            this.txtSearchItems.Size = new System.Drawing.Size(197, 23);
            this.txtSearchItems.TabIndex = 2;
            this.txtSearchItems.UseSelectable = true;
            this.txtSearchItems.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearchItems.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearchItems.TextChanged += new System.EventHandler(this.TxtSearchItems_TextChanged);
            this.txtSearchItems.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.txtSearchItems.Leave += new System.EventHandler(this.TxtSearch_Leave);
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(9, 9);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(84, 19);
            this.lblItems.TabIndex = 1;
            this.lblItems.Text = "Select a Item";
            // 
            // listItems
            // 
            this.listItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listItems.FormattingEnabled = true;
            this.listItems.ItemHeight = 23;
            this.listItems.Location = new System.Drawing.Point(9, 66);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(197, 29);
            this.listItems.TabIndex = 0;
            this.listItems.TabStop = false;
            this.listItems.UseSelectable = true;
            this.listItems.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.btnSave);
            this.metroPanel2.Controls.Add(this.DynamicInputs);
            this.metroPanel2.Controls.Add(this.lblSelectItem);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(475, 63);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(489, 706);
            this.metroPanel2.TabIndex = 5;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // lblSelectItem
            // 
            this.lblSelectItem.AutoSize = true;
            this.lblSelectItem.Location = new System.Drawing.Point(30, 10);
            this.lblSelectItem.Name = "lblSelectItem";
            this.lblSelectItem.Size = new System.Drawing.Size(246, 19);
            this.lblSelectItem.TabIndex = 11;
            this.lblSelectItem.Text = "Change a Item Atributes. Select any Item";
            // 
            // DynamicInputs
            // 
            this.DynamicInputs.AutoSize = true;
            this.DynamicInputs.Location = new System.Drawing.Point(30, 57);
            this.DynamicInputs.Name = "DynamicInputs";
            this.DynamicInputs.Size = new System.Drawing.Size(15, 19);
            this.DynamicInputs.TabIndex = 12;
            this.DynamicInputs.Text = "-";
            this.DynamicInputs.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(398, 669);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 779);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.panelNPC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Resizable = false;
            this.Text = "Source Tools - OpenConquerEmulator 5517";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelNPC.ResumeLayout(false);
            this.panelNPC.PerformLayout();
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox listNPCs;
        private MetroFramework.Controls.MetroLabel lblSelectNPC;
        private MetroFramework.Controls.MetroPanel panelNPC;
        private MetroFramework.Controls.MetroTextBox txtSearch;
        private MetroFramework.Controls.MetroPanel panelAction;
        private MetroFramework.Controls.MetroLabel lblSelectAction;
        private Label lblAction1;
        private Label lblAction3;
        private Label lblAction4;
        private Label lblAction2;
        private Label lblAction5;
        private Label lblAction6;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txtSearchItems;
        private MetroFramework.Controls.MetroLabel lblItems;
        private MetroFramework.Controls.MetroComboBox listItems;
        private MetroFramework.Controls.MetroTextBox lblMainDialogText;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel lblSelectItem;
        private MetroFramework.Controls.MetroLabel DynamicInputs;
        private MetroFramework.Controls.MetroButton btnSave;
    }
}