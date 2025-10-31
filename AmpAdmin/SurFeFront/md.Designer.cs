namespace SurFeFront
{
    partial class md
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(md));
            menuStrip = new MenuStrip();
            vENTAToolStripMenuItem = new ToolStripMenuItem();
            puntoDeVentaToolStripMenuItem = new ToolStripMenuItem();
            notaDeCreditoToolStripMenuItem = new ToolStripMenuItem();
            iNFORMESToolStripMenuItem = new ToolStripMenuItem();
            ventasRealizadasToolStripMenuItem = new ToolStripMenuItem();
            consultarVentaToolStripMenuItem = new ToolStripMenuItem();
            emitirInformeVentasToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { vENTAToolStripMenuItem, iNFORMESToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(1350, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // vENTAToolStripMenuItem
            // 
            vENTAToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { puntoDeVentaToolStripMenuItem, notaDeCreditoToolStripMenuItem });
            vENTAToolStripMenuItem.Name = "vENTAToolStripMenuItem";
            vENTAToolStripMenuItem.Size = new Size(55, 20);
            vENTAToolStripMenuItem.Text = "VENTA";
            vENTAToolStripMenuItem.Click += vENTAToolStripMenuItem_Click;
            // 
            // puntoDeVentaToolStripMenuItem
            // 
            puntoDeVentaToolStripMenuItem.Name = "puntoDeVentaToolStripMenuItem";
            puntoDeVentaToolStripMenuItem.Size = new Size(180, 22);
            puntoDeVentaToolStripMenuItem.Text = "Punto de venta";
            puntoDeVentaToolStripMenuItem.Click += puntoDeVentaToolStripMenuItem_Click;
            // 
            // notaDeCreditoToolStripMenuItem
            // 
            notaDeCreditoToolStripMenuItem.Name = "notaDeCreditoToolStripMenuItem";
            notaDeCreditoToolStripMenuItem.Size = new Size(180, 22);
            notaDeCreditoToolStripMenuItem.Text = "Nota de credito";
            notaDeCreditoToolStripMenuItem.Click += notaDeCreditoToolStripMenuItem_Click;
            // 
            // iNFORMESToolStripMenuItem
            // 
            iNFORMESToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ventasRealizadasToolStripMenuItem });
            iNFORMESToolStripMenuItem.Name = "iNFORMESToolStripMenuItem";
            iNFORMESToolStripMenuItem.Size = new Size(76, 20);
            iNFORMESToolStripMenuItem.Text = "INFORMES";
            // 
            // ventasRealizadasToolStripMenuItem
            // 
            ventasRealizadasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { consultarVentaToolStripMenuItem, emitirInformeVentasToolStripMenuItem });
            ventasRealizadasToolStripMenuItem.Name = "ventasRealizadasToolStripMenuItem";
            ventasRealizadasToolStripMenuItem.Size = new Size(165, 22);
            ventasRealizadasToolStripMenuItem.Text = "Ventas Realizadas";
            ventasRealizadasToolStripMenuItem.Click += ventasRealizadasToolStripMenuItem_Click;
            // 
            // consultarVentaToolStripMenuItem
            // 
            consultarVentaToolStripMenuItem.Name = "consultarVentaToolStripMenuItem";
            consultarVentaToolStripMenuItem.Size = new Size(187, 22);
            consultarVentaToolStripMenuItem.Text = "Consultar Venta";
            consultarVentaToolStripMenuItem.Click += consultarVentaToolStripMenuItem_Click;
            // 
            // emitirInformeVentasToolStripMenuItem
            // 
            emitirInformeVentasToolStripMenuItem.Name = "emitirInformeVentasToolStripMenuItem";
            emitirInformeVentasToolStripMenuItem.Size = new Size(187, 22);
            emitirInformeVentasToolStripMenuItem.Text = "Emitir Informe Ventas";
            emitirInformeVentasToolStripMenuItem.Click += emitirInformeVentasToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 707);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1350, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(42, 17);
            toolStripStatusLabel.Text = "Estado";
            // 
            // md
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1350, 729);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            DoubleBuffered = true;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "md";
            Text = "AmpAdmin ®";
            WindowState = FormWindowState.Maximized;
            Load += md_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion


        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolTip toolTip;
        private ToolStripMenuItem vENTAToolStripMenuItem;
        private ToolStripMenuItem iNFORMESToolStripMenuItem;
        private ToolStripMenuItem ventasRealizadasToolStripMenuItem;
        private ToolStripMenuItem puntoDeVentaToolStripMenuItem;
        private ToolStripMenuItem notaDeCreditoToolStripMenuItem;
        private ToolStripMenuItem consultarVentaToolStripMenuItem;
        private ToolStripMenuItem emitirInformeVentasToolStripMenuItem;
    }
}



