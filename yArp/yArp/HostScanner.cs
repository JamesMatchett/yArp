using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yArp
{
    class HostScanner
    {
        public static async Task ScanHosts(bool AutoDetect, TextBox subnetTextBox, ListBox AdapterList, ListView Devices)
        {
            if (AutoDetect)
            {
                subnetTextBox.Text = SubnetHandler.GetSubnet(AdapterList);
            }
            string root = subnetTextBox.Text + ".";
            var tasks = new List<Task>();
            for (int i = 0; i <= 255; i++)
            {
                var task = PingAsync(root + i, Devices);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }

        private static async Task PingAsync(string address, ListView Devices)
        {
            Ping ping = new Ping();
            var reply = await ping.SendPingAsync(address);
            if (reply.Status == IPStatus.Success)
            {
                string[] rows = { address, "Resolving", MAC_Helper.GetMacAddress(address) };
                var listViewItem = new ListViewItem(rows);
                Devices.Items.Add(listViewItem);
            }
            getHostName(address, Devices);
        }

        private static async void getHostName(string Address, ListView Devices)
        {
            try
            {
                var hostnameTask = System.Net.Dns.GetHostEntryAsync(Address);
                await hostnameTask;
                foreach (ListViewItem x in Devices.Items)
                {
                    if (hostnameTask.Result.AddressList.First().ToString() == x.SubItems[0].Text)
                    {
                        x.SubItems[1].Text = hostnameTask.Result.HostName;
                    }
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                foreach (ListViewItem x in Devices.Items)
                {
                    if (Address == x.SubItems[0].Text)
                    {
                        x.SubItems[1].Text = "Not found";
                    }
                }
            }
        }
    }
}
