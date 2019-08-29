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
            this.noFilterNPCSearch = new MetroFramework.Controls.MetroCheckBox();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.noFilterItemSearch = new MetroFramework.Controls.MetroCheckBox();
            this.txtSearchItems = new MetroFramework.Controls.MetroTextBox();
            this.lblItems = new MetroFramework.Controls.MetroLabel();
            this.listItems = new MetroFramework.Controls.MetroComboBox();
            this.DynamicInputs = new MetroFramework.Controls.MetroLabel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.lblHelperItemtypeItems = new MetroFramework.Controls.MetroLabel();
            this.panelAttributes = new System.Windows.Forms.FlowLayoutPanel();
            this.panelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.dynamicInputsNPC = new MetroFramework.Controls.MetroLabel();
            this.lblHelperNPCs = new MetroFramework.Controls.MetroLabel();
            this.btnSaveMainAction = new MetroFramework.Controls.MetroButton();
            this.btnManageActions = new MetroFramework.Controls.MetroButton();
            this.panelNPC.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.panelAttributes.SuspendLayout();
            this.panelActions.SuspendLayout();
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
            this.panelNPC.Controls.Add(this.noFilterNPCSearch);
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
            // noFilterNPCSearch
            // 
            this.noFilterNPCSearch.AutoSize = true;
            this.noFilterNPCSearch.Location = new System.Drawing.Point(135, 41);
            this.noFilterNPCSearch.Name = "noFilterNPCSearch";
            this.noFilterNPCSearch.Size = new System.Drawing.Size(66, 15);
            this.noFilterNPCSearch.TabIndex = 2;
            this.noFilterNPCSearch.Text = "No filter";
            this.noFilterNPCSearch.UseSelectable = true;
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.CustomButton.Image = null;
            this.txtSearch.CustomButton.Location = new System.Drawing.Point(95, 1);
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
            this.txtSearch.Size = new System.Drawing.Size(117, 23);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.UseSelectable = true;
            this.txtSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.TxtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.TxtSearch_Leave);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.noFilterItemSearch);
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
            // noFilterItemSearch
            // 
            this.noFilterItemSearch.AutoSize = true;
            this.noFilterItemSearch.Location = new System.Drawing.Point(135, 41);
            this.noFilterItemSearch.Name = "noFilterItemSearch";
            this.noFilterItemSearch.Size = new System.Drawing.Size(66, 15);
            this.noFilterItemSearch.TabIndex = 3;
            this.noFilterItemSearch.Text = "No filter";
            this.noFilterItemSearch.UseSelectable = true;
            // 
            // txtSearchItems
            // 
            // 
            // 
            // 
            this.txtSearchItems.CustomButton.Image = null;
            this.txtSearchItems.CustomButton.Location = new System.Drawing.Point(95, 1);
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
            this.txtSearchItems.Size = new System.Drawing.Size(117, 23);
            this.txtSearchItems.TabIndex = 1;
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
            // DynamicInputs
            // 
            this.DynamicInputs.AutoSize = true;
            this.DynamicInputs.Location = new System.Drawing.Point(18, 10);
            this.DynamicInputs.Name = "DynamicInputs";
            this.DynamicInputs.Size = new System.Drawing.Size(15, 19);
            this.DynamicInputs.TabIndex = 12;
            this.DynamicInputs.Text = "-";
            this.DynamicInputs.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(977, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblHelperItemtypeItems
            // 
            this.lblHelperItemtypeItems.AutoSize = true;
            this.lblHelperItemtypeItems.Location = new System.Drawing.Point(645, 200);
            this.lblHelperItemtypeItems.Name = "lblHelperItemtypeItems";
            this.lblHelperItemtypeItems.Size = new System.Drawing.Size(246, 19);
            this.lblHelperItemtypeItems.TabIndex = 11;
            this.lblHelperItemtypeItems.Text = "Change a Item Atributes. Select any Item";
            // 
            // panelAttributes
            // 
            this.panelAttributes.AutoScroll = true;
            this.panelAttributes.BackColor = System.Drawing.Color.Transparent;
            this.panelAttributes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAttributes.Controls.Add(this.DynamicInputs);
            this.panelAttributes.Location = new System.Drawing.Point(526, 229);
            this.panelAttributes.Name = "panelAttributes";
            this.panelAttributes.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelAttributes.Size = new System.Drawing.Size(506, 341);
            this.panelAttributes.TabIndex = 13;
            // 
            // panelActions
            // 
            this.panelActions.AutoScroll = true;
            this.panelActions.BackColor = System.Drawing.Color.Transparent;
            this.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActions.Controls.Add(this.dynamicInputsNPC);
            this.panelActions.Location = new System.Drawing.Point(14, 229);
            this.panelActions.Name = "panelActions";
            this.panelActions.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.panelActions.Size = new System.Drawing.Size(506, 341);
            this.panelActions.TabIndex = 14;
            // 
            // dynamicInputsNPC
            // 
            this.dynamicInputsNPC.AutoSize = true;
            this.dynamicInputsNPC.Location = new System.Drawing.Point(18, 10);
            this.dynamicInputsNPC.Name = "dynamicInputsNPC";
            this.dynamicInputsNPC.Size = new System.Drawing.Size(15, 19);
            this.dynamicInputsNPC.TabIndex = 12;
            this.dynamicInputsNPC.Text = "-";
            this.dynamicInputsNPC.Visible = false;
            // 
            // lblHelperNPCs
            // 
            this.lblHelperNPCs.AutoSize = true;
            this.lblHelperNPCs.Location = new System.Drawing.Point(169, 200);
            this.lblHelperNPCs.Name = "lblHelperNPCs";
            this.lblHelperNPCs.Size = new System.Drawing.Size(192, 19);
            this.lblHelperNPCs.TabIndex = 15;
            this.lblHelperNPCs.Text = "Change a NPC. Select any NPC";
            // 
            // btnSaveMainAction
            // 
            this.btnSaveMainAction.Location = new System.Drawing.Point(465, 196);
            this.btnSaveMainAction.Name = "btnSaveMainAction";
            this.btnSaveMainAction.Size = new System.Drawing.Size(55, 23);
            this.btnSaveMainAction.TabIndex = 16;
            this.btnSaveMainAction.Text = "Save";
            this.btnSaveMainAction.UseSelectable = true;
            this.btnSaveMainAction.Click += new System.EventHandler(this.BtnSaveMainAction_Click);
            // 
            // btnManageActions
            // 
            this.btnManageActions.Location = new System.Drawing.Point(13, 200);
            this.btnManageActions.Name = "btnManageActions";
            this.btnManageActions.Size = new System.Drawing.Size(95, 23);
            this.btnManageActions.TabIndex = 17;
            this.btnManageActions.Text = "Manage Actions";
            this.btnManageActions.UseSelectable = true;
            this.btnManageActions.Click += new System.EventHandler(this.BtnManageActions_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 576);
            this.Controls.Add(this.btnManageActions);
            this.Controls.Add(this.btnSaveMainAction);
            this.Controls.Add(this.lblHelperNPCs);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelAttributes);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.lblHelperItemtypeItems);
            this.Controls.Add(this.panelNPC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Resizable = false;
            this.Text = "Source Tools - OpenConquerEmulator 5517";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelNPC.ResumeLayout(false);
            this.panelNPC.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.panelAttributes.ResumeLayout(false);
            this.panelAttributes.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox listNPCs;
        private MetroFramework.Controls.MetroLabel lblSelectNPC;
        private MetroFramework.Controls.MetroPanel panelNPC;
        private MetroFramework.Controls.MetroTextBox txtSearch;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox txtSearchItems;
        private MetroFramework.Controls.MetroLabel lblItems;
        private MetroFramework.Controls.MetroComboBox listItems;
        private MetroFramework.Controls.MetroLabel lblHelperItemtypeItems;
        private MetroFramework.Controls.MetroLabel DynamicInputs;
        private MetroFramework.Controls.MetroButton btnSave;
        private FlowLayoutPanel panelAttributes;
        private FlowLayoutPanel panelActions;
        private MetroFramework.Controls.MetroLabel dynamicInputsNPC;
        private MetroFramework.Controls.MetroLabel lblHelperNPCs;
        private MetroFramework.Controls.MetroButton btnSaveMainAction;
        private MetroFramework.Controls.MetroButton btnManageActions;
        private MetroFramework.Controls.MetroCheckBox noFilterNPCSearch;
        private MetroFramework.Controls.MetroCheckBox noFilterItemSearch;
    }
}