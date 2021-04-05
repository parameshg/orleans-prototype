
namespace IoT.Server.Host
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.nPort = new System.Windows.Forms.NumericUpDown();
            this.pBanner = new System.Windows.Forms.Panel();
            this.tlpMain.SuspendLayout();
            this.tlpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPort)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpActions, 0, 1);
            this.tlpMain.Controls.Add(this.pBanner, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Size = new System.Drawing.Size(484, 241);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpActions
            // 
            this.tlpActions.ColumnCount = 3;
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpActions.Controls.Add(this.btnStartStop, 2, 0);
            this.tlpActions.Controls.Add(this.nPort, 0, 0);
            this.tlpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpActions.Location = new System.Drawing.Point(3, 204);
            this.tlpActions.Name = "tlpActions";
            this.tlpActions.RowCount = 1;
            this.tlpActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.Size = new System.Drawing.Size(478, 34);
            this.tlpActions.TabIndex = 1;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.Location = new System.Drawing.Point(398, 0);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(80, 34);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "START";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.OnStartStop);
            // 
            // nPort
            // 
            this.nPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nPort.Location = new System.Drawing.Point(3, 3);
            this.nPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nPort.Name = "nPort";
            this.nPort.Size = new System.Drawing.Size(84, 29);
            this.nPort.TabIndex = 2;
            this.nPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // pBanner
            // 
            this.pBanner.BackgroundImage = global::IoT.Server.Host.Properties.Resources.orleans;
            this.pBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBanner.Location = new System.Drawing.Point(3, 3);
            this.pBanner.Name = "pBanner";
            this.pBanner.Size = new System.Drawing.Size(478, 195);
            this.pBanner.TabIndex = 2;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 241);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.tlpMain.ResumeLayout(false);
            this.tlpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpActions;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.NumericUpDown nPort;
        private System.Windows.Forms.Panel pBanner;
    }
}

