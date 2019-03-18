using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace yArp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Devices.ItemCheck += Devices_ItemCheck;
        }

        private void Devices_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked)
            {
                SelectDeselect(Devices.Items[e.Index], false);
            }
            else
            {
                SelectDeselect(Devices.Items[e.Index], true);
            }

        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem I in Devices.Items)
            {
                I.Checked = true;
                SelectDeselect(I, true);
            }
        }

        private void DeselectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem I in Devices.Items)
            {
                I.Checked = false;
                SelectDeselect(I, false);
            }
        }

        private void SelectDeselect(ListViewItem I, bool select)
        {

            if (select)
            {
                I.BackColor = SystemColors.MenuHighlight;
            }
            else
            {
                I.BackColor = SystemColors.Window;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdapterHandler.GetAdapters(AdapterList);
        }

        private async void Scan_ClickAsync(object sender, EventArgs e)
        {
            await HostScanner.ScanHosts(AutoDetect.Checked, subnetTextBox, AdapterList, Devices, RemoveDuplicatesCheckBox.Checked);
        }

        private void RefreshAdapters_Click(object sender, EventArgs e)
        {
            AdapterHandler.GetAdapters(AdapterList);
        }

        private void DCON_Click(object sender, EventArgs e)
        {
            DCONHandler.DCON(Devices, AutoDetect.Checked, subnetTextBox, AdapterList);
        }
        {
            if (RemoveDuplicatesCheckBox.Checked)
            {
                Devices.Items.Clear();
                Scan_ClickAsync(null, null);
            }
        }
    }
}
