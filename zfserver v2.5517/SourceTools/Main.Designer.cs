namespace SourceTools
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Drawing.Drawing2D.GraphicsPath graphicsPath2 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath1 = new System.Drawing.Drawing2D.GraphicsPath();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.materialPanel1 = new MaterialSkin.Controls.MaterialPanel();
            this.btnLoadNPCs = new MaterialSkin.Controls.MaterialFlatButton();
            this.lblSelectNPC = new MaterialSkin.Controls.MaterialLabel();
            this.listNPCs = new MaterialSkin.Controls.MaterialListView();
            this.materialPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialPanel1
            // 
            this.materialPanel1.Controls.Add(this.btnLoadNPCs);
            this.materialPanel1.Controls.Add(this.lblSelectNPC);
            this.materialPanel1.Controls.Add(this.listNPCs);
            this.materialPanel1.Depth = 0;
            this.materialPanel1.Location = new System.Drawing.Point(1, 64);
            this.materialPanel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialPanel1.Name = "materialPanel1";
            this.materialPanel1.Primary = false;
            this.materialPanel1.RoundedCornerRadius = 2;
            this.materialPanel1.Shadow = null;
            graphicsPath2.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.materialPanel1.ShadowShape = graphicsPath2;
            this.materialPanel1.Size = new System.Drawing.Size(799, 384);
            this.materialPanel1.TabIndex = 2;
            // 
            // btnLoadNPCs
            // 
            this.btnLoadNPCs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoadNPCs.Depth = 0;
            this.btnLoadNPCs.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnLoadNPCs.FontSize = 9;
            this.btnLoadNPCs.Icon = null;
            this.btnLoadNPCs.Location = new System.Drawing.Point(690, 342);
            this.btnLoadNPCs.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLoadNPCs.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLoadNPCs.Name = "btnLoadNPCs";
            this.btnLoadNPCs.Primary = false;
            this.btnLoadNPCs.RoundedCornerRadius = 2;
            this.btnLoadNPCs.Shadow = null;
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btnLoadNPCs.ShadowShape = graphicsPath1;
            this.btnLoadNPCs.Size = new System.Drawing.Size(96, 28);
            this.btnLoadNPCs.TabIndex = 2;
            this.btnLoadNPCs.Text = "Load NPCs";
            this.btnLoadNPCs.Click += new System.EventHandler(this.BtnLoadNPCs_Click);
            // 
            // lblSelectNPC
            // 
            this.lblSelectNPC.AutoSize = true;
            this.lblSelectNPC.Depth = 0;
            this.lblSelectNPC.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblSelectNPC.FontSize = 11;
            this.lblSelectNPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSelectNPC.Location = new System.Drawing.Point(11, 13);
            this.lblSelectNPC.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSelectNPC.Name = "lblSelectNPC";
            this.lblSelectNPC.Primary = false;
            this.lblSelectNPC.Shadow = null;
            this.lblSelectNPC.ShadowShape = null;
            this.lblSelectNPC.Size = new System.Drawing.Size(97, 19);
            this.lblSelectNPC.TabIndex = 1;
            this.lblSelectNPC.Text = "Select a NPC";
            // 
            // listNPCs
            // 
            this.listNPCs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listNPCs.Depth = 0;
            this.listNPCs.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listNPCs.FullRowSelect = true;
            this.listNPCs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listNPCs.HideSelection = false;
            this.listNPCs.Location = new System.Drawing.Point(11, 40);
            this.listNPCs.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listNPCs.MouseState = MaterialSkin.MouseState.OUT;
            this.listNPCs.Name = "listNPCs";
            this.listNPCs.OwnerDraw = true;
            this.listNPCs.Shadow = null;
            this.listNPCs.ShadowShape = null;
            this.listNPCs.Size = new System.Drawing.Size(108, 330);
            this.listNPCs.TabIndex = 0;
            this.listNPCs.UseCompatibleStateImageBehavior = false;
            this.listNPCs.View = System.Windows.Forms.View.Details;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Source Tools - OpenConquerEmulator 5517";
            this.Load += new System.EventHandler(this.Main_Load);
            this.materialPanel1.ResumeLayout(false);
            this.materialPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialPanel materialPanel1;
        private MaterialSkin.Controls.MaterialLabel lblSelectNPC;
        private MaterialSkin.Controls.MaterialListView listNPCs;
        private MaterialSkin.Controls.MaterialFlatButton btnLoadNPCs;
    }
}

