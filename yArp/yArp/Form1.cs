﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yArp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Devices.MouseClick += Devices_MouseClick;

            string[] rows = { "test", "test2", "test3" };
            var listViewItem = new ListViewItem(rows);
            Devices.Items.Add(listViewItem);

        }

        private void Devices_MouseClick(object sender, MouseEventArgs e)
        {

            foreach (ListViewItem I in Devices.Items)
            {
                SelectDeselect(I, !I.Checked);
            }
        }

        private void Devices_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            getSubnet();
            GetAdapters();
        }

        private void scan_Click(object sender, EventArgs e)
        {
            if (AutoDetect.Checked)
            {
                subnetTextBox.Text = getSubnet();
            }
            //get subnet
        }

        private string getSubnet()
        {// add if adapter == null exception
            if (AdapterList.SelectedItem != null)
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
                    {
                        if (nic.Name == AdapterList.SelectedItem.ToString())
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                return FilterToSubnet(ip.Address.ToString());
                            }
                        }
                    }
                }
            }
            return "not found";
        }

        private string FilterToSubnet(string input)
        {
            //example 192.16.0.1 -> 192.16.0.
            return input.Substring(0, input.LastIndexOf("."));
        }

        private void GetAdapters()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (!AdapterList.Items.Contains(nic.Name))
                {
                    
                    AdapterList.Items.Add(nic.Name);
                }
            }
        }

        private void RefreshAdapters_Click(object sender, EventArgs e)
        {
            GetAdapters();
        }
    }
}
