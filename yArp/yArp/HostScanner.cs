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
        public static async Task ScanHosts(bool AutoDetect, TextBox subnetTextBox, ListBox AdapterList, ListView Devices, bool removeDupes)
        {
            if (AutoDetect)
            {
                subnetTextBox.Text = SubnetHandler.GetSubnet(AdapterList);
            }
            string root = subnetTextBox.Text + ".";
            var tasks = new List<Task>();
            for (int i = 0; i <= 255; i++)
            {
                var task = PingAsync(root + i, Devices, removeDupes);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }

        private static async Task PingAsync(string address, ListView Devices, bool removeDupes)
        {
            Ping ping = new Ping();
            var reply = await ping.SendPingAsync(address);
            if (reply.Status == IPStatus.Success)
            {
                string[] rows = { address, "Resolving", MAC_Helper.GetMacAddress(address) };
                var listViewItem = new ListViewItem(rows);
                AddHost(Devices, listViewItem, removeDupes);
            }

        }

        private static void AddHost(ListView Devices, ListViewItem newHost, bool removeDupes)
        {
            int index = HostExists(Devices, newHost);
            if (!removeDupes || index == -1)
            {
               Devices.Items.Add(newHost);
            }
            else
            {
               Devices.Items[index] = newHost;
            }
            getHostName(newHost);
        }

        private static int HostExists(ListView Devices, ListViewItem newHost)
        {
            int index = -1;
            foreach (ListViewItem t in Devices.Items)
            {
                if (t.SubItems[2].Text == newHost.SubItems[2].Text)
                {
                    index = Devices.Items.IndexOf(t);
                }
            }
            return index;
        }

        private static async void getHostName(ListViewItem host)
        {
            try
            {
                string Address = host.SubItems[0].Text;
                var hostnameTask = System.Net.Dns.GetHostEntryAsync(Address);
                await hostnameTask;
                host.SubItems[1].Text = hostnameTask.Result.HostName;
            }
            catch (System.Net.Sockets.SocketException)
            {
                host.SubItems[1].Text = "Not found";
            }
        }
    }
}
