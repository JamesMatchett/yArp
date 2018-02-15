namespace yArp
{
    partial class Form1
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
            this.Devices = new System.Windows.Forms.ListView();
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelectAll = new System.Windows.Forms.Button();
            this.DeselectAll = new System.Windows.Forms.Button();
            this.scan = new System.Windows.Forms.Button();
            this.SubnetLabel = new System.Windows.Forms.Label();
            this.subnetTextBox = new System.Windows.Forms.TextBox();
            this.AutoDetect = new System.Windows.Forms.CheckBox();
            this.NetworkAdapterLabel = new System.Windows.Forms.Label();
            this.AdapterList = new System.Windows.Forms.ListBox();
            this.RefreshAdapters = new System.Windows.Forms.Button();
            this.DCON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Devices
            // 
            this.Devices.CheckBoxes = true;
            this.Devices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.HostName,
            this.MAC});
            this.Devices.Location = new System.Drawing.Point(12, 12);
            this.Devices.Name = "Devices";
            this.Devices.Size = new System.Drawing.Size(384, 331);
            this.Devices.TabIndex = 0;
            this.Devices.UseCompatibleStateImageBehavior = false;
            this.Devices.View = System.Windows.Forms.View.Details;
            this.Devices.SelectedIndexChanged += new System.EventHandler(this.Devices_SelectedIndexChanged);
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 77;
            // 
            // HostName
            // 
            this.HostName.Text = "Hostname";
            this.HostName.Width = 119;
            // 
            // MAC
            // 
            this.MAC.Text = "MAC";
            this.MAC.Width = 226;
            // 
            // SelectAll
            // 
            this.SelectAll.Location = new System.Drawing.Point(22, 349);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(75, 23);
            this.SelectAll.TabIndex = 1;
            this.SelectAll.Text = "Select All";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // DeselectAll
            // 
            this.DeselectAll.Location = new System.Drawing.Point(131, 349);
            this.DeselectAll.Name = "DeselectAll";
            this.DeselectAll.Size = new System.Drawing.Size(75, 23);
            this.DeselectAll.TabIndex = 2;
            this.DeselectAll.Text = "Deselect All";
            this.DeselectAll.UseVisualStyleBackColor = true;
            this.DeselectAll.Click += new System.EventHandler(this.DeselectAll_Click);
            // 
            // scan
            // 
            this.scan.Location = new System.Drawing.Point(415, 286);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(139, 23);
            this.scan.TabIndex = 3;
            this.scan.Text = "Scan Network";
            this.scan.UseVisualStyleBackColor = true;
            this.scan.Click += new System.EventHandler(this.Scan_Click);
            // 
            // SubnetLabel
            // 
            this.SubnetLabel.AutoSize = true;
            this.SubnetLabel.Location = new System.Drawing.Point(412, 12);
            this.SubnetLabel.Name = "SubnetLabel";
            this.SubnetLabel.Size = new System.Drawing.Size(44, 13);
            this.SubnetLabel.TabIndex = 4;
            this.SubnetLabel.Text = "Subnet:";
            // 
            // subnetTextBox
            // 
            this.subnetTextBox.Location = new System.Drawing.Point(415, 28);
            this.subnetTextBox.Name = "subnetTextBox";
            this.subnetTextBox.Size = new System.Drawing.Size(139, 20);
            this.subnetTextBox.TabIndex = 5;
            // 
            // AutoDetect
            // 
            this.AutoDetect.AutoSize = true;
            this.AutoDetect.Checked = true;
            this.AutoDetect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoDetect.Location = new System.Drawing.Point(415, 54);
            this.AutoDetect.Name = "AutoDetect";
            this.AutoDetect.Size = new System.Drawing.Size(120, 17);
            this.AutoDetect.TabIndex = 6;
            this.AutoDetect.Text = "Auto-Detect Subnet";
            this.AutoDetect.UseVisualStyleBackColor = true;
            // 
            // NetworkAdapterLabel
            // 
            this.NetworkAdapterLabel.AutoSize = true;
            this.NetworkAdapterLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NetworkAdapterLabel.Location = new System.Drawing.Point(412, 76);
            this.NetworkAdapterLabel.Name = "NetworkAdapterLabel";
            this.NetworkAdapterLabel.Size = new System.Drawing.Size(87, 13);
            this.NetworkAdapterLabel.TabIndex = 7;
            this.NetworkAdapterLabel.Text = "Network Adapter";
            // 
            // AdapterList
            // 
            this.AdapterList.FormattingEnabled = true;
            this.AdapterList.Location = new System.Drawing.Point(415, 93);
            this.AdapterList.Name = "AdapterList";
            this.AdapterList.Size = new System.Drawing.Size(120, 69);
            this.AdapterList.TabIndex = 8;
            // 
            // RefreshAdapters
            // 
            this.RefreshAdapters.Location = new System.Drawing.Point(415, 170);
            this.RefreshAdapters.Name = "RefreshAdapters";
            this.RefreshAdapters.Size = new System.Drawing.Size(120, 23);
            this.RefreshAdapters.TabIndex = 9;
            this.RefreshAdapters.Text = "Refresh Adapters";
            this.RefreshAdapters.UseVisualStyleBackColor = true;
            this.RefreshAdapters.Click += new System.EventHandler(this.RefreshAdapters_Click);
            // 
            // DCON
            // 
            this.DCON.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.DCON.Location = new System.Drawing.Point(415, 320);
            this.DCON.Name = "DCON";
            this.DCON.Size = new System.Drawing.Size(139, 23);
            this.DCON.TabIndex = 10;
            this.DCON.Text = "Disconnect Devices";
            this.DCON.UseVisualStyleBackColor = false;
            this.DCON.Click += new System.EventHandler(this.DCON_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 424);
            this.Controls.Add(this.DCON);
            this.Controls.Add(this.RefreshAdapters);
            this.Controls.Add(this.AdapterList);
            this.Controls.Add(this.NetworkAdapterLabel);
            this.Controls.Add(this.AutoDetect);
            this.Controls.Add(this.subnetTextBox);
            this.Controls.Add(this.SubnetLabel);
            this.Controls.Add(this.scan);
            this.Controls.Add(this.DeselectAll);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.Devices);
            this.Name = "Form1";
            this.Text = "yArp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Devices;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader HostName;
        private System.Windows.Forms.ColumnHeader MAC;
        private System.Windows.Forms.Button SelectAll;
        private System.Windows.Forms.Button DeselectAll;
        private System.Windows.Forms.Button scan;
        private System.Windows.Forms.Label SubnetLabel;
        private System.Windows.Forms.TextBox subnetTextBox;
        private System.Windows.Forms.CheckBox AutoDetect;
        private System.Windows.Forms.Label NetworkAdapterLabel;
        private System.Windows.Forms.ListBox AdapterList;
        private System.Windows.Forms.Button RefreshAdapters;
        private System.Windows.Forms.Button DCON;
    }
}

