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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 424);
            this.Controls.Add(this.DeselectAll);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.Devices);
            this.Name = "Form1";
            this.Text = "yArp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Devices;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader HostName;
        private System.Windows.Forms.ColumnHeader MAC;
        private System.Windows.Forms.Button SelectAll;
        private System.Windows.Forms.Button DeselectAll;
    }
}

