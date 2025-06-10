namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.loadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.copyAndPasteSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.deleteSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.clearCanvasSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawElipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawCirlceSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawTriangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawStarSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawColorPickerSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawStrokeColorPickerSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawGradientSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.rotateSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.groupSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.ungroupSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.scaleUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.scaleDownSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.renameSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.drawStrokeWidthSpeedTracker = new System.Windows.Forms.TrackBar();
            this.drawFiguraIzpitSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawStrokeWidthSpeedTracker)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(924, 28);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 499);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(924, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.loadToolStripButton,
            this.pickUpSpeedButton,
            this.copyAndPasteSpeedButton,
            this.deleteSpeedButton,
            this.clearCanvasSpeedButton,
            this.drawRectangleSpeedButton,
            this.drawElipseSpeedButton,
            this.drawCirlceSpeedButton,
            this.drawTriangleSpeedButton,
            this.drawStarSpeedButton,
            this.drawFiguraIzpitSpeedButton,
            this.drawColorPickerSpeedButton,
            this.drawStrokeColorPickerSpeedButton,
            this.drawGradientSpeedButton,
            this.rotateSpeedButton,
            this.groupSpeedButton,
            this.ungroupSpeedButton,
            this.scaleUpSpeedButton,
            this.scaleDownSpeedButton,
            this.toolStripLabel1,
            this.renameSpeedButton,
            this.toolStripLabel2});
            this.speedMenu.Location = new System.Drawing.Point(0, 28);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(924, 27);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.saveToolStripButton.Text = "saveToolStripButton";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // loadToolStripButton
            // 
            this.loadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripButton.Image")));
            this.loadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadToolStripButton.Name = "loadToolStripButton";
            this.loadToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.loadToolStripButton.Text = "loadToolStripButton";
            this.loadToolStripButton.Click += new System.EventHandler(this.loadToolStripButton_Click);
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.pickUpSpeedButton.Text = "toolStripButton1";
            // 
            // copyAndPasteSpeedButton
            // 
            this.copyAndPasteSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyAndPasteSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("copyAndPasteSpeedButton.Image")));
            this.copyAndPasteSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyAndPasteSpeedButton.Name = "copyAndPasteSpeedButton";
            this.copyAndPasteSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.copyAndPasteSpeedButton.Text = "copyAndPasteSpeedButton";
            this.copyAndPasteSpeedButton.Click += new System.EventHandler(this.copyAndPasteSpeedButton_Click);
            // 
            // deleteSpeedButton
            // 
            this.deleteSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteSpeedButton.Image")));
            this.deleteSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSpeedButton.Name = "deleteSpeedButton";
            this.deleteSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.deleteSpeedButton.Text = "deleteSpeedButton";
            this.deleteSpeedButton.Click += new System.EventHandler(this.deleteSpeedButton_Click);
            // 
            // clearCanvasSpeedButton
            // 
            this.clearCanvasSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearCanvasSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("clearCanvasSpeedButton.Image")));
            this.clearCanvasSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearCanvasSpeedButton.Name = "clearCanvasSpeedButton";
            this.clearCanvasSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.clearCanvasSpeedButton.Text = "clearCanvasSpeedButton";
            this.clearCanvasSpeedButton.Click += new System.EventHandler(this.clearCanvasSpeedButton_Click);
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawRectangleSpeedButton.Text = "DrawRectangleButton";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // drawElipseSpeedButton
            // 
            this.drawElipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawElipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawElipseSpeedButton.Image")));
            this.drawElipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawElipseSpeedButton.Name = "drawElipseSpeedButton";
            this.drawElipseSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawElipseSpeedButton.Text = "drawElipseSpeedButton";
            this.drawElipseSpeedButton.Click += new System.EventHandler(this.drawElipseSpeedButton_Click);
            // 
            // drawCirlceSpeedButton
            // 
            this.drawCirlceSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawCirlceSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawCirlceSpeedButton.Image")));
            this.drawCirlceSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawCirlceSpeedButton.Name = "drawCirlceSpeedButton";
            this.drawCirlceSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawCirlceSpeedButton.Text = "drawCirlceSpeedButton";
            this.drawCirlceSpeedButton.Click += new System.EventHandler(this.drawCirlceSpeedButton_Click);
            // 
            // drawTriangleSpeedButton
            // 
            this.drawTriangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawTriangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawTriangleSpeedButton.Image")));
            this.drawTriangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawTriangleSpeedButton.Name = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawTriangleSpeedButton.Text = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Click += new System.EventHandler(this.drawTriangleSpeedButton_Click);
            // 
            // drawStarSpeedButton
            // 
            this.drawStarSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawStarSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawStarSpeedButton.Image")));
            this.drawStarSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawStarSpeedButton.Name = "drawStarSpeedButton";
            this.drawStarSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawStarSpeedButton.Text = "drawStarSpeedButton";
            this.drawStarSpeedButton.Click += new System.EventHandler(this.drawStarSpeedButton_Click);
            // 
            // drawColorPickerSpeedButton
            // 
            this.drawColorPickerSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawColorPickerSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawColorPickerSpeedButton.Image")));
            this.drawColorPickerSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawColorPickerSpeedButton.Name = "drawColorPickerSpeedButton";
            this.drawColorPickerSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawColorPickerSpeedButton.Text = "drawColorPickerSpeedButton";
            this.drawColorPickerSpeedButton.Click += new System.EventHandler(this.drawColorPickerSpeedButton_Click);
            // 
            // drawStrokeColorPickerSpeedButton
            // 
            this.drawStrokeColorPickerSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawStrokeColorPickerSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawStrokeColorPickerSpeedButton.Image")));
            this.drawStrokeColorPickerSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawStrokeColorPickerSpeedButton.Name = "drawStrokeColorPickerSpeedButton";
            this.drawStrokeColorPickerSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawStrokeColorPickerSpeedButton.Text = "drawStrokeColorPickerSpeedButton";
            this.drawStrokeColorPickerSpeedButton.Click += new System.EventHandler(this.drawStrokeColorPickerSpeedButton_Click);
            // 
            // drawGradientSpeedButton
            // 
            this.drawGradientSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawGradientSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawGradientSpeedButton.Image")));
            this.drawGradientSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawGradientSpeedButton.Name = "drawGradientSpeedButton";
            this.drawGradientSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawGradientSpeedButton.Text = "drawGradientSpeedButton";
            this.drawGradientSpeedButton.Click += new System.EventHandler(this.drawGradientSpeedButton_Click);
            // 
            // rotateSpeedButton
            // 
            this.rotateSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("rotateSpeedButton.Image")));
            this.rotateSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateSpeedButton.Name = "rotateSpeedButton";
            this.rotateSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.rotateSpeedButton.Text = "rotateSpeedButton";
            this.rotateSpeedButton.Click += new System.EventHandler(this.rotateSpeedButton_Click);
            // 
            // groupSpeedButton
            // 
            this.groupSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.groupSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("groupSpeedButton.Image")));
            this.groupSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.groupSpeedButton.Name = "groupSpeedButton";
            this.groupSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.groupSpeedButton.Text = "toolStripButton1";
            this.groupSpeedButton.ToolTipText = "groupSpeedButton";
            this.groupSpeedButton.Click += new System.EventHandler(this.groupSpeedButton_Click);
            // 
            // ungroupSpeedButton
            // 
            this.ungroupSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ungroupSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("ungroupSpeedButton.Image")));
            this.ungroupSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ungroupSpeedButton.Name = "ungroupSpeedButton";
            this.ungroupSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.ungroupSpeedButton.Text = "ungroupSpeedButton";
            this.ungroupSpeedButton.Click += new System.EventHandler(this.ungroupSpeedButton_Click);
            // 
            // scaleUpSpeedButton
            // 
            this.scaleUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.scaleUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("scaleUpSpeedButton.Image")));
            this.scaleUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scaleUpSpeedButton.Name = "scaleUpSpeedButton";
            this.scaleUpSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.scaleUpSpeedButton.Text = "scaleUpSpeedButton";
            this.scaleUpSpeedButton.Click += new System.EventHandler(this.scaleUpSpeedButton_Click);
            // 
            // scaleDownSpeedButton
            // 
            this.scaleDownSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.scaleDownSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("scaleDownSpeedButton.Image")));
            this.scaleDownSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scaleDownSpeedButton.Name = "scaleDownSpeedButton";
            this.scaleDownSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.scaleDownSpeedButton.Text = "scaleDownSpeedButton";
            this.scaleDownSpeedButton.Click += new System.EventHandler(this.scaleDownSpeedButton_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 24);
            // 
            // renameSpeedButton
            // 
            this.renameSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("renameSpeedButton.Image")));
            this.renameSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameSpeedButton.Name = "renameSpeedButton";
            this.renameSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.renameSpeedButton.Text = "renameSpeedButton";
            this.renameSpeedButton.Click += new System.EventHandler(this.renameSpeedButton_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(91, 24);
            this.toolStripLabel2.Text = "StrokeWidth";
            // 
            // drawStrokeWidthSpeedTracker
            // 
            this.drawStrokeWidthSpeedTracker.Location = new System.Drawing.Point(780, 28);
            this.drawStrokeWidthSpeedTracker.Name = "drawStrokeWidthSpeedTracker";
            this.drawStrokeWidthSpeedTracker.Size = new System.Drawing.Size(104, 56);
            this.drawStrokeWidthSpeedTracker.TabIndex = 5;
            this.drawStrokeWidthSpeedTracker.Scroll += new System.EventHandler(this.drawStrokeWidthSpeedTracker_Scroll);
            // 
            // drawFiguraIzpitSpeedButton
            // 
            this.drawFiguraIzpitSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawFiguraIzpitSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawFiguraIzpitSpeedButton.Image")));
            this.drawFiguraIzpitSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawFiguraIzpitSpeedButton.Name = "drawFiguraIzpitSpeedButton";
            this.drawFiguraIzpitSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawFiguraIzpitSpeedButton.Text = "drawFiguraIzpitSpeedButton";
            this.drawFiguraIzpitSpeedButton.Click += new System.EventHandler(this.drawFiguraIzpitSpeedButton_Click);
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 55);
            this.viewPort.Margin = new System.Windows.Forms.Padding(5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(924, 444);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 521);
            this.Controls.Add(this.drawStrokeWidthSpeedTracker);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawStrokeWidthSpeedTracker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton drawElipseSpeedButton;
        private System.Windows.Forms.ToolStripButton drawTriangleSpeedButton;
        private System.Windows.Forms.ToolStripButton drawColorPickerSpeedButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.TrackBar drawStrokeWidthSpeedTracker;
        private System.Windows.Forms.ToolStripButton drawStarSpeedButton;
        private System.Windows.Forms.ToolStripButton drawStrokeColorPickerSpeedButton;
        private System.Windows.Forms.ToolStripButton drawGradientSpeedButton;
        private System.Windows.Forms.ToolStripButton rotateSpeedButton;
        private System.Windows.Forms.ToolStripButton deleteSpeedButton;
        private System.Windows.Forms.ToolStripButton copyAndPasteSpeedButton;
        private System.Windows.Forms.ToolStripButton groupSpeedButton;
        private System.Windows.Forms.ToolStripButton ungroupSpeedButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton loadToolStripButton;
        private System.Windows.Forms.ToolStripButton clearCanvasSpeedButton;
        private System.Windows.Forms.ToolStripButton scaleUpSpeedButton;
        private System.Windows.Forms.ToolStripButton scaleDownSpeedButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton renameSpeedButton;
        private System.Windows.Forms.ToolStripButton drawCirlceSpeedButton;
        private System.Windows.Forms.ToolStripButton drawFiguraIzpitSpeedButton;
    }
}
