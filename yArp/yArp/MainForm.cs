using PacketDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            }else
            {
                SelectDeselect(Devices.Items[e.Index], true);
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
            GetAdapters();

        }

        private async void Scan_Click(object sender, EventArgs e)
        {
            if (AutoDetect.Checked)
            {
                subnetTextBox.Text = GetSubnet();
            }
            string root = subnetTextBox.Text + ".";
            var tasks = new List<Task>();
            for (int i =0; i<=255; i++)
            {
                var task = PingAsync(root+i);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
 
      private async Task PingAsync(string address)
      {
        Ping ping = new Ping();
        var reply = await ping.SendPingAsync(address);
            if (reply.Status == IPStatus.Success)
            {
                //get host name
                //IPAddress ip = Dns.GetHostEntry(address).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
                string[] rows = { address, "", MAC_Helper.GetMacAddress(address) };
            
            
                var listViewItem = new ListViewItem(rows);
                Devices.Items.Add(listViewItem);
            }
      }
  
    
      private string GetSubnet()
        {
            if(AdapterList.SelectedItem == null)
            {
                //check adapter list, if any exist pick the first
                //else show message showing an adapter needs to be found
                if(AdapterList.Items.Count == 0)
                {
                    if (!GetAdapters())
                    {
                        MessageBox.Show("Can't automatically derive subnet as no adapters could be found");
                        return null;
                    }
                }
                AdapterList.SelectedItem = AdapterList.Items[0];
            }

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

        private bool GetAdapters()
        {
            //returns a boolean if adapters were found
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (!AdapterList.Items.Contains(nic.Name))
                {
                    AdapterList.Items.Add(nic.Name);
                }
            }

            return AdapterList.Items.Count > 0; 
        }

        private void RefreshAdapters_Click(object sender, EventArgs e)
        {
            GetAdapters();
        }

        private void DCON_Click(object sender, EventArgs e)
        {
            
            //check valid config
            if(Devices.CheckedItems.Count > 0)
            {
                if((AutoDetect.Checked || ValidIP(subnetTextBox.Text)) && AdapterList.SelectedItems.Count > 1)
                {
                    foreach(ListViewItem LV in Devices.CheckedItems)
                    {
                       string targetIP = LV.SubItems[0].Text; //IP
                        string targetMAC = LV.SubItems[2].Text;

                        EthernetPacket Q = ARP_Sender.MakeArpRequest(PhysicalAddress.Parse("ABABABAB"), IPAddress.Parse(targetIP), IPAddress.Parse(subnetTextBox.Text), targetMAC);
                        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                        {
                            if ((string)AdapterList.SelectedItem == (nic.Name))
                            {
                               //send packet q using some voodoo

                            }
                        }

                    }
                }
            }

        }

        private bool ValidIP(string input)
        {
            IPAddress temp;
            return (IPAddress.TryParse(input,out temp));
        }
    }
}
