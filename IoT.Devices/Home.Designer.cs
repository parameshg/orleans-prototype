
namespace IoT.Devices
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gMinimum = new System.Windows.Forms.GroupBox();
            this.nMinimum = new System.Windows.Forms.NumericUpDown();
            this.gMaximum = new System.Windows.Forms.GroupBox();
            this.nMaximum = new System.Windows.Forms.NumericUpDown();
            this.gInterval = new System.Windows.Forms.GroupBox();
            this.nInterval = new System.Windows.Forms.NumericUpDown();
            this.gType = new System.Windows.Forms.GroupBox();
            this.cType = new System.Windows.Forms.ComboBox();
            this.pBanner = new System.Windows.Forms.Panel();
            this.tCounter = new System.Windows.Forms.Timer(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpActions.SuspendLayout();
            this.gMinimum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinimum)).BeginInit();
            this.gMaximum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMaximum)).BeginInit();
            this.gInterval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nInterval)).BeginInit();
            this.gType.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Controls.Add(this.tlpActions, 0, 2);
            this.tlpMain.Controls.Add(this.gMinimum, 0, 0);
            this.tlpMain.Controls.Add(this.gMaximum, 1, 0);
            this.tlpMain.Controls.Add(this.gInterval, 2, 0);
            this.tlpMain.Controls.Add(this.gType, 3, 0);
            this.tlpMain.Controls.Add(this.pBanner, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(484, 241);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpActions
            // 
            this.tlpActions.ColumnCount = 2;
            this.tlpMain.SetColumnSpan(this.tlpActions, 4);
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpActions.Controls.Add(this.btnStartStop, 1, 0);
            this.tlpActions.Controls.Add(this.lblMessage, 0, 0);
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
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(3, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(392, 34);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Idle";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gMinimum
            // 
            this.gMinimum.Controls.Add(this.nMinimum);
            this.gMinimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMinimum.Location = new System.Drawing.Point(3, 3);
            this.gMinimum.Name = "gMinimum";
            this.gMinimum.Size = new System.Drawing.Size(115, 44);
            this.gMinimum.TabIndex = 2;
            this.gMinimum.TabStop = false;
            this.gMinimum.Text = "Minimum";
            // 
            // nMinimum
            // 
            this.nMinimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nMinimum.Location = new System.Drawing.Point(3, 16);
            this.nMinimum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nMinimum.Name = "nMinimum";
            this.nMinimum.Size = new System.Drawing.Size(109, 20);
            this.nMinimum.TabIndex = 0;
            // 
            // gMaximum
            // 
            this.gMaximum.Controls.Add(this.nMaximum);
            this.gMaximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMaximum.Location = new System.Drawing.Point(124, 3);
            this.gMaximum.Name = "gMaximum";
            this.gMaximum.Size = new System.Drawing.Size(115, 44);
            this.gMaximum.TabIndex = 3;
            this.gMaximum.TabStop = false;
            this.gMaximum.Text = "Maximum";
            // 
            // nMaximum
            // 
            this.nMaximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nMaximum.Location = new System.Drawing.Point(3, 16);
            this.nMaximum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nMaximum.Name = "nMaximum";
            this.nMaximum.Size = new System.Drawing.Size(109, 20);
            this.nMaximum.TabIndex = 0;
            this.nMaximum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // gInterval
            // 
            this.gInterval.Controls.Add(this.nInterval);
            this.gInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gInterval.Location = new System.Drawing.Point(245, 3);
            this.gInterval.Name = "gInterval";
            this.gInterval.Size = new System.Drawing.Size(115, 44);
            this.gInterval.TabIndex = 4;
            this.gInterval.TabStop = false;
            this.gInterval.Text = "Interval";
            // 
            // nInterval
            // 
            this.nInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nInterval.Location = new System.Drawing.Point(3, 16);
            this.nInterval.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nInterval.Name = "nInterval";
            this.nInterval.Size = new System.Drawing.Size(109, 20);
            this.nInterval.TabIndex = 0;
            this.nInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // gType
            // 
            this.gType.Controls.Add(this.cType);
            this.gType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gType.Location = new System.Drawing.Point(366, 3);
            this.gType.Name = "gType";
            this.gType.Size = new System.Drawing.Size(115, 44);
            this.gType.TabIndex = 5;
            this.gType.TabStop = false;
            this.gType.Text = "Type";
            // 
            // cType
            // 
            this.cType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cType.FormattingEnabled = true;
            this.cType.Location = new System.Drawing.Point(3, 16);
            this.cType.Name = "cType";
            this.cType.Size = new System.Drawing.Size(109, 21);
            this.cType.TabIndex = 0;
            // 
            // pBanner
            // 
            this.pBanner.BackgroundImage = global::IoT.Devices.Properties.Resources.device;
            this.pBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlpMain.SetColumnSpan(this.pBanner, 4);
            this.pBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBanner.Location = new System.Drawing.Point(3, 53);
            this.pBanner.Name = "pBanner";
            this.pBanner.Size = new System.Drawing.Size(478, 145);
            this.pBanner.TabIndex = 6;
            // 
            // tCounter
            // 
            this.tCounter.Interval = 500;
            this.tCounter.Tick += new System.EventHandler(this.OnTimer);
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
            this.Text = "Device";
            this.Load += new System.EventHandler(this.OnLoad);
            this.tlpMain.ResumeLayout(false);
            this.tlpActions.ResumeLayout(false);
            this.tlpActions.PerformLayout();
            this.gMinimum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nMinimum)).EndInit();
            this.gMaximum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nMaximum)).EndInit();
            this.gInterval.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nInterval)).EndInit();
            this.gType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpActions;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Timer tCounter;
        private System.Windows.Forms.GroupBox gMinimum;
        private System.Windows.Forms.GroupBox gMaximum;
        private System.Windows.Forms.GroupBox gInterval;
        private System.Windows.Forms.GroupBox gType;
        private System.Windows.Forms.NumericUpDown nMinimum;
        private System.Windows.Forms.NumericUpDown nMaximum;
        private System.Windows.Forms.NumericUpDown nInterval;
        private System.Windows.Forms.ComboBox cType;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pBanner;
    }
}

