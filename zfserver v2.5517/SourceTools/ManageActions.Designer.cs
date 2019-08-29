﻿namespace SourceTools
{
    partial class ManageActions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageActions));
            this.txtMainActionParam = new MetroFramework.Controls.MetroTextBox();
            this.panelActions = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMainActionParam
            // 
            // 
            // 
            // 
            this.txtMainActionParam.CustomButton.Image = null;
            this.txtMainActionParam.CustomButton.Location = new System.Drawing.Point(508, 1);
            this.txtMainActionParam.CustomButton.Name = "";
            this.txtMainActionParam.CustomButton.Size = new System.Drawing.Size(107, 107);
            this.txtMainActionParam.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMainActionParam.CustomButton.TabIndex = 1;
            this.txtMainActionParam.CustomButton.Text = "SAVE";
            this.txtMainActionParam.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMainActionParam.CustomButton.UseSelectable = true;
            this.txtMainActionParam.DisplayIcon = true;
            this.txtMainActionParam.Icon = global::SourceTools.Properties.Resources.conquer_icon;
            this.txtMainActionParam.Lines = new string[] {
        "txtMainActionParam"};
            this.txtMainActionParam.Location = new System.Drawing.Point(23, 86);
            this.txtMainActionParam.MaxLength = 32767;
            this.txtMainActionParam.Multiline = true;
            this.txtMainActionParam.Name = "txtMainActionParam";
            this.txtMainActionParam.PasswordChar = '\0';
            this.txtMainActionParam.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMainActionParam.SelectedText = "";
            this.txtMainActionParam.SelectionLength = 0;
            this.txtMainActionParam.SelectionStart = 0;
            this.txtMainActionParam.ShortcutsEnabled = true;
            this.txtMainActionParam.ShowButton = true;
            this.txtMainActionParam.Size = new System.Drawing.Size(616, 109);
            this.txtMainActionParam.TabIndex = 0;
            this.txtMainActionParam.Text = "txtMainActionParam";
            this.txtMainActionParam.UseSelectable = true;
            this.txtMainActionParam.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMainActionParam.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.dataGridView1);
            this.panelActions.Location = new System.Drawing.Point(23, 212);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(616, 215);
            this.panelActions.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(612, 212);
            this.dataGridView1.TabIndex = 0;
            // 
            // ManageActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 450);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.txtMainActionParam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageActions";
            this.Resizable = false;
            this.Text = "ManageActions";
            this.Load += new System.EventHandler(this.ManageActions_Load);
            this.panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtMainActionParam;
        private System.Windows.Forms.FlowLayoutPanel panelActions;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}